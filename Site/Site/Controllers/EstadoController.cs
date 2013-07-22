using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Models.BL;

namespace Site.Controllers
{
    public class EstadoController : Controller
    {
        public const string TituloEditar = "Editar Estado";
        public const string TituloCadastrar = "Cadastrar Estado";

        public ActionResult ListarEstados()
        {
            List<Site.Models.Estado> lstEstado = null;
            BLEstado blEstado = null;

            try
            {
                blEstado = new BLEstado();
                lstEstado = blEstado.ListarEstados();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (blEstado != null)
                    blEstado = null;
            }

            return View(lstEstado);
        }

        public ActionResult EditarEstado(int codigo)
        {
            Site.Models.Estado estado = null;
            BLEstado blEstado = null;
            try
            {
                if (codigo != 0)
                {
                    ViewBag.Title = TituloEditar;
                    blEstado = new BLEstado();
                    estado = blEstado.ObterEstado(codigo);

                }
                else
                {
                    ViewBag.Title = TituloCadastrar;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (blEstado != null)
                    blEstado = null;
            }
            
            return View(estado);
        }

        [HttpPost, ActionName("EditarEstado")]
        public ActionResult Salvar(Site.Models.Estado estado, FormCollection formCollection)
        {
            BLEstado blEstado = null;

            try
            {
                if (estado.Codigo == 0)
                {
                    ViewBag.Title = TituloCadastrar;

                    if (ModelState.IsValid)
                    {
                        blEstado = new BLEstado();
                        blEstado.IncluirEstado(estado);
                    }
                }
                else
                {
                    ViewBag.Title = TituloEditar;

                    if (ModelState.IsValid)
                    {
                        blEstado = new BLEstado();
                        blEstado.AlterarEstado(estado);
                    }
                }
                ViewData["MensagemSucesso"] = "Operação realizada com sucesso!";
            }
            catch (Exception ex)
            {
                ViewData["MensagemErro"] = "Não foi possível concluir. Ocorreu o seguinte erro:" + ex.Message;
            }
            finally
            {
                if (blEstado != null)
                    blEstado = null;
            }

            return View(estado);
        }

        public ActionResult CadastrarEstado()
        {
            ViewBag.Title = TituloCadastrar;
            Site.Models.Estado estado = new Models.Estado();
            return RedirectToAction("EditarEstado", new { codigo = 0});
        }

        [HttpDelete]
        public ActionResult DeletarEstado(int codigo)
        {
            BLEstado blEstado = new BLEstado();
            try
            {
                blEstado.DeletarEstado(codigo);
                ViewData["MensagemSucesso"] = "Operação realizada com sucesso!";
            }
            catch(Exception ex)
            {
                ViewData["MensagemErro"] = "Não foi possível completar a operação: " + ex.Message;
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
