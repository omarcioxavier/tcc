using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using web.Models.Enums;
using web.Models.Estabelecimento;
using web.Models.Produto;
using web.Models.Usuario;
using web.ModelsResponse;
using web.Repository.DBConn;
using web.ViewModel.Estabelecimento;

namespace web.Controllers.Estabelecimento
{
    public class estabelecimentoController : Controller
    {
        private DBConn _context;

        public estabelecimentoController()
        {
            _context = new DBConn();
        }

        #region Métodos View
        public ActionResult novo()
        {
            try
            {
                var categorias = _context.estabelecimentosCategorias.OrderBy(ec => ec.descricao).ToList();

                var viewModel = new estabelecimentoNovoViewModel()
                {
                    estabelecimentoCategorias = categorias
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
        #endregion

        #region Métodos Restful

        /// <summary>
        /// Obtém o estabelecimento pelo ID e se ele possui algum sabor e sua lista de produtos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sabor"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id, string sabor = null)
        {
            var estabelecimento = _context.estabelecimentos.Where(e => e.estabelecimentoID == id).SingleOrDefault();


            return Json("", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtém os estabelecimentos próximos (raio de 5 km)  
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="sabor"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getByCoordinates(double latitude, double longitude, string sabor = null)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tcc_dbConn"].ConnectionString);
            string sql;
            var retorno = new List<estabelecimentoResponse>();

            conn.Open();

            // Retorna os IDs dos estabelecimentos que estão dentro do raio de 5 KM com relação as coordenadas passadas
            sql = @"SELECT * FROM fnCalcularDistancia(@latitude, @longitude);";
            var estabelecimentosIds = conn.Query<int>(sql, new { latitude, longitude }).ToArray();

            // Obtém os estabelecimentos pelos IDs retornados da function
            var estabelecimentos = _context.estabelecimentos.Where(e => estabelecimentosIds.Contains(e.estabelecimentoID)).ToList();

            if (sabor != null)
            {
                // Se a pesquisa for por sabor, retorna estabelecimentos que tenham o sabor escolhido
                sabor = "%" + sabor + "%";
                sql = @"SELECT DISTINCT(E.estabelecimentoID) FROM estabelecimento E
	                        JOIN estabelecimentoProduto EP ON EP.estabelecimentoID = E.estabelecimentoID
	                        JOIN produto P ON P.produtoID = EP.produtoID
	                        WHERE 
		                        E.estabelecimentoID IN @estabelecimentosIds
		                        AND P.ativo = 1
                                AND (P.descricao LIKE @sabor OR P.nome LIKE @sabor);";

                var estabelecimentosFiltroProduto = conn.Query<int>(sql, new { estabelecimentosIds, sabor }).ToArray();

                estabelecimentos = estabelecimentos.Where(e => estabelecimentosFiltroProduto.Contains(e.estabelecimentoID)).ToList();
            }
            conn.Close();

            retorno = translateEstabelecimento(estabelecimentos);

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Formata o objeto de estabelecimento para receber no app
        /// </summary>
        /// <param name="estabelecimentos"></param>
        /// <returns></returns>
        private List<estabelecimentoResponse> translateEstabelecimento(List<estabelecimento> estabelecimentos)
        {
            var retornoObj = new List<estabelecimentoResponse>();
            
            string sql;

            int estabelecimentoId;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tcc_dbConn"].ConnectionString);
            conn.Open();
            foreach (var item in estabelecimentos)
            {
                var estabelecimentoResponse = new estabelecimentoResponse();
                var itens = new List<produto>();
                var drinks = new List<produto>();

                estabelecimentoId = item.estabelecimentoID;

                // Obtem os itens do tipo pizza
                sql = $@"SELECT P.* FROM estabelecimento E
                            JOIN estabelecimentoProduto EP ON EP.estabelecimentoID = E.estabelecimentoID
                            JOIN produto P ON P.produtoID = EP.produtoID
                            WHERE
                                E.estabelecimentoID = @estabelecimentoId
		                        AND P.produtoCategoriaID = {(int)enumProdutoCategoria.pizza}";
                itens = conn.Query<produto>(sql, new { estabelecimentoId }).ToList();

                // Obtem os itens do tipo drink
                sql = $@"SELECT P.* FROM estabelecimento E
                            JOIN estabelecimentoProduto EP ON EP.estabelecimentoID = E.estabelecimentoID
                            JOIN produto P ON P.produtoID = EP.produtoID
                            WHERE
                                E.estabelecimentoID = @estabelecimentoId
		                        AND P.produtoCategoriaID = {(int)enumProdutoCategoria.bebida}";
                drinks = conn.Query<produto>(sql, new { estabelecimentoId }).ToList();

                estabelecimentoResponse.id = item.estabelecimentoID;
                estabelecimentoResponse.name = item.nomeFantasia;
                estabelecimentoResponse.itens = translateItens(itens);
                estabelecimentoResponse.drinks = translateDrinks(drinks);

                retornoObj.Add(estabelecimentoResponse);
            }

            conn.Close();

            return retornoObj;
        }

        private List<itensResponse> translateItens(List<produto> produtos)
        {
            var itens = new List<itensResponse>();

            foreach (var item in produtos)
            {
                var obj = new itensResponse();
                obj.id = item.produtoID;
                obj.name = item.nome;
                obj.desc = item.descricao;
                obj.tam = item.tamanho;
                obj.value = item.precoUnitario;
                itens.Add(obj);
            }

            return itens;
        }

        private List<drinksResponse> translateDrinks(List<produto> produtos)
        {
            var drinks = new List<drinksResponse>();
            foreach (var item in produtos)
            {
                var obj = new drinksResponse();
                obj.id = item.produtoID;
                obj.name = item.nome;
                obj.desc = item.descricao;
                obj.value = item.precoUnitario;
                drinks.Add(obj);
            }

            return drinks;
        }
        #endregion
    }
}