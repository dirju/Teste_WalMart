using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Models.BL;

namespace Site.Controllers
{
    public class CidadeController : Controller
    {

        public const string TituloEditar = "Editar Cidade";
        public const string TituloCadastrar = "Cadastrar Cidade";

        public ActionResult ListarCidades()
        {
            List<Site.Models.Cidade> lstCidade = null;
            BLCidade blCidade = null;

            try
            {
                blCidade = new BLCidade();
                lstCidade = blCidade.ListarCidades();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (blCidade != null)
                    blCidade = null;
            }

            return View(lstCidade);
        }

        public ActionResult EditarCidade(int codigo)
        {
            Site.Models.Cidade cidade = null;
            BLCidade blCidade = new BLCidade();
            BLEstado blEstado = new BLEstado();
            try
            {
                if (codigo != 0)
                {
                    ViewBag.Title = TituloEditar;

                    cidade = blCidade.ObterCidade(codigo);
                    cidade.TodosEstados = blEstado.ListarEstados();

                }
                else
                {
                    ViewBag.Title = TituloCadastrar;

                    cidade = new Models.Cidade();
                    cidade.TodosEstados = blEstado.ListarEstados();

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (blCidade != null)
                    blCidade = null;
                if (blEstado != null)
                    blEstado = null;
            }

            return View(cidade);
        }

        [HttpPost, ActionName("EditarCidade")]
        public ActionResult Salvar(Site.Models.Cidade cidade, FormCollection formCollection)
        {
            BLCidade blCidade = new BLCidade();
            BLEstado blEstado = new BLEstado();
            try
            {
                if (cidade.Codigo == 0)
                {
                    ViewBag.Title = TituloCadastrar;

                    if (cidade.Estado.Codigo != null && cidade.Nome != null)
                    {
                        blCidade.IncluirCidade(cidade);
                        ViewData["MensagemSucesso"] = "Operação realizada com sucesso!";
                    }
                }
                else
                {
                    ViewBag.Title = TituloEditar;

                    if (cidade.Estado.Codigo != null && cidade.Nome != null)
                    {
                        blCidade.AlterarCidade(cidade);
                        ViewData["MensagemSucesso"] = "Operação realizada com sucesso!";
                    }
                }
                cidade.TodosEstados = blEstado.ListarEstados();
            }
            catch (Exception ex)
            {
                ViewData["MensagemErro"] = "Não foi possível concluir. Ocorreu o seguinte erro:" + ex.Message;
            }
            finally
            {
                if (blCidade != null)
                    blCidade = null;
                if (blEstado != null)
                    blEstado = null;
            }

            return View(cidade);
        }

        public ActionResult CadastrarCidade()
        {
            ViewBag.Title = TituloCadastrar;
            Site.Models.Cidade cidade = new Models.Cidade();
            return RedirectToAction("EditarCidade", new { codigo = 0 });
        }

        [HttpDelete]
        public PartialViewResult DeletarCidade(int codigo)
        {
            try
            {
                BLCidade blCidade = new BLCidade();
                blCidade.DeletarCidade(codigo);
            }
            catch (Exception ex)
            {
                
                throw;
            }

            return PartialView();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        [HttpPost]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPut]
        public ActionResult Update()
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Select()
        {
            return View();
        }
    }
}
