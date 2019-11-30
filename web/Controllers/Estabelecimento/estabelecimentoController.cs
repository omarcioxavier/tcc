using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using web.Models.Estabelecimento;
using web.Models.Usuario;
using web.Repository.DBConn;
using web.ViewModel.Estabelecimento;
using Dapper;
using Dapper.Mapper;


namespace web.Controllers.Estabelecimento
{
    public class estabelecimentoController : Controller
    {
        private DBConn _context;

        public estabelecimentoController()
        {
            _context = new DBConn();
        }

        public ActionResult novo()
        {
            try
            {
                var viewModel = new estabelecimentoNovoViewModel()
                {
                    estabelecimentoCategorias = _context.estabelecimentosCategorias.OrderBy(ec => ec.descricao).ToList()
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult editar()
        {
            try
            {
                var estabelecimentoID = int.Parse(Session["EstabelecimentoId"].ToString());

                var viewModel = new estabelecimentoEditarViewModel
                {
                    estabelecimento = _context.estabelecimentos.Where(e => e.estabelecimentoID == estabelecimentoID).SingleOrDefault(),
                    estabelecimentoCategorias = _context.estabelecimentosCategorias.OrderBy(ec => ec.descricao).ToList()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult salvar(estabelecimento estabelecimento, usuario usuario = null)
        {
            try
            {
                if (estabelecimento.estabelecimentoID > 0)
                {
                    // Editar
                    atualizar(estabelecimento);
                    return RedirectToAction("listar", "produto");
                }
                else
                {
                    // Novo
                    inserir(estabelecimento, usuario);
                    return RedirectToAction("Default", "usuario");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        private void inserir(estabelecimento estabelecimento, usuario usuario)
        {
            // Insere o estabelecimento
            _context.estabelecimentos.Add(estabelecimento);
            _context.SaveChanges();

            // Insere o usuário
            usuario.ativo = true;
            usuario.estabelecimentoID = estabelecimento.estabelecimentoID;
            _context.usuarios.Add(usuario);
            _context.SaveChanges();
        }

        [HttpPut]
        private void atualizar(estabelecimento estabelecimento)
        {
            // Trata o estabelecimento
            var estabelecimentoAtual = _context.estabelecimentos.Where(e => e.estabelecimentoID == estabelecimento.estabelecimentoID).SingleOrDefault();
            estabelecimentoAtual.razaoSocial = estabelecimento.razaoSocial;
            estabelecimentoAtual.nomeFantasia = estabelecimento.nomeFantasia;
            estabelecimentoAtual.cnpj = estabelecimento.cnpj;
            estabelecimentoAtual.inscricaoEstadual = estabelecimento.inscricaoEstadual;
            estabelecimentoAtual.ativo = estabelecimento.ativo;
            estabelecimentoAtual.estabelecimentoCategoriaID = estabelecimento.estabelecimentoCategoriaID;
            _context.SaveChanges();
        }

        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.estabelecimentos.Where(e => e.estabelecimentoID == id), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult getByCoordinates(double latitude, double longitude, string sabor = null)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tcc_dbConn"].ConnectionString);
            string sql;

            conn.Open();
            // Retorna os IDs dos estabelecimentos que estão dentro do raio de 5 KM com relação as coordenadas passadas
            sql = $"SELECT * FROM fnCalcularDistancia({latitude.ToString().Replace(",", ".")}, {longitude.ToString().Replace(",", ".")});";
            var estabelecimentosIds = conn.Query<int>(sql).ToArray();


            // Obtem os estabelecimentos pelos IDs retornados da function
            var estabelecimentos = _context.estabelecimentos.Where(e => estabelecimentosIds.Contains(e.estabelecimentoID)).ToList();

            if (sabor != null)
            {
                sabor = "%" + sabor + "%";

                sql = @"SELECT DISTINCT(E.estabelecimentoID) FROM estabelecimento E
	                        JOIN estabelecimentoProduto EP ON EP.estabelecimentoID = E.estabelecimentoID
	                        JOIN produto P ON P.produtoID = EP.produtoID
	                        WHERE 
		                        E.estabelecimentoID IN @estabelecimentosIds
		                        AND P.descricao LIKE @sabor;";

                var estabelecimentosFiltroProduto = conn.Query<int>(sql, new { estabelecimentosIds, sabor }).ToArray();

                estabelecimentos = estabelecimentos.Where(e => estabelecimentosFiltroProduto.Contains(e.estabelecimentoID)).ToList();
            }

            conn.Close();
            return Json(estabelecimentos, JsonRequestBehavior.AllowGet);
        }
    }
}