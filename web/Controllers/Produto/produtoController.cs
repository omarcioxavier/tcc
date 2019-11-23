using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using web.Models.Estabelecimento;
using web.Models.Produto;
using web.Repository.DBConn;
using web.ViewModel.Produto;

namespace web.Controllers.Produto
{
    public class produtoController : Controller
    {
        private DBConn _context;

        public produtoController()
        {
            _context = new DBConn();
        }

        public ActionResult listar()
        {
            try
            {
                var produtos = getProdutosEstabelecimento();

                var viewModel = new produtoListarViewModel()
                {
                    produtos = produtos,
                    produtoCategorias = getProdutosCategorias()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult novo()
        {
            try
            {
                var viewModel = new produtoFormViewModel()
                {
                    produtoCategorias = _context.produtosCategorias.ToList()
                };
                return View("form", viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult editar(int id)
        {
            try
            {
                var viewModel = new produtoFormViewModel()
                {
                    produto = _context.produtos.Where(p => p.produtoID == id).SingleOrDefault(),
                    produtoCategorias = _context.produtosCategorias.ToList()
                };
                return View("form", viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult salvar(produto produto)
        {
            try
            {
                if (produto.produtoID > 0)
                {
                    atualizar(produto);
                }
                else
                {
                    inserir(produto);
                }

                return RedirectToAction("listar");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public void inserir(produto produto)
        {
            // Insere na tabela produto
            _context.produtos.Add(produto);
            _context.SaveChanges();

            // Insere na tabela estabelecimentoProduto
            estabelecimentoProduto estabelecimentoProduto = new estabelecimentoProduto()
            {
                estabelecimentoID = int.Parse(Session["EstabelecimentoId"].ToString()),
                produtoID = produto.produtoID
            };
            _context.estabelecimentosProdutos.Add(estabelecimentoProduto);
            _context.SaveChanges();
        }

        [HttpPut]
        public void atualizar(produto produto)
        {
            var produtoAtual = _context.produtos.Where(p => p.produtoID == produto.produtoID).SingleOrDefault();
            produtoAtual.descricao = produto.descricao;
            produtoAtual.precoUnitario = produto.precoUnitario;
            produtoAtual.ativo = produto.ativo;
            produtoAtual.produtoCategoriaID = produto.produtoCategoriaID;

            _context.SaveChanges();
        }

        public ActionResult pesquisar(produtoListarViewModel produtoPesquisa)
        {
            try
            {
                // Obtém os produtos do estabelecimento
                var produtos = getProdutosEstabelecimento();

                if (produtoPesquisa.descricao != null)
                {
                    produtos = produtos.Where(p => p.descricao.Contains(produtoPesquisa.descricao)).ToList();
                }

                if (produtoPesquisa.produtoCategoriaID > 0)
                {
                    produtos = produtos.Where(p => p.produtoCategoriaID == produtoPesquisa.produtoCategoriaID).ToList();
                }

                var viewModel = new produtoListarViewModel()
                {
                    produtos = produtos,
                    produtoCategorias = getProdutosCategorias()
                };

                return View("listar", viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Obtém o ID do estabelecimento
        private int getEstabelecimentoID()
        {
            return int.Parse(Session["EstabelecimentoId"].ToString());
        }

        // Obtém os produtos do estabelecimento
        private IEnumerable<produto> getProdutosEstabelecimento()
        {
            int estabelecimentoId = getEstabelecimentoID();

            // Obtém os IDs dos produtos do estabelecimento
            var produtosIds = _context.estabelecimentosProdutos.Where(e => e.estabelecimentoID == estabelecimentoId).Select(e => e.produtoID).ToArray();

            return _context.produtos.Where(p => produtosIds.Contains(p.produtoID)).OrderBy(p => p.descricao).ToList();
        }

        // Obtém as categorias do estabelecimento
        private IEnumerable<produtoCategoria> getProdutosCategorias()
        {
            return _context.produtosCategorias.ToList();
        }
    }
}