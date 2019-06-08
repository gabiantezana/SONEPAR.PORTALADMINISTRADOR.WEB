using SONEPAR.PORTALADMINISTRADOR.WEB.Controllers;
using SONEPAR.PORTALADMINISTRADOR.WEB.EXCEPTION;
using SONEPAR.PORTALADMINISTRADOR.WEB.Filters;
using SONEPAR.PORTALADMINISTRADOR.WEB.HELPER;
using SONEPAR.PORTALADMINISTRADOR.WEB.VIEWMODEL.Administracion.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SONEPAR.PORTALADMINISTRADOR.WEB.LOGIC.Administracion;

namespace SONEPAR.PORTALADMINISTRADOR.WEB.Areas.Administracion.Controllers
{
    public class UsuarioController : BaseController
    {
        #region Get

        [AppViewAuthorize(ConstantHelper.Vistas.Administracion.Usuario.LISTAR)]
        public ActionResult ListUsuarios()
        {
            var model = new UsuarioLogic().GetListUsuariosViewModel(GetDataContext(), null, null);
            return View(model);
        }

        [AppViewAuthorize(ConstantHelper.Vistas.Administracion.Usuario.LISTAR)]
        public ActionResult _ListUsuariosPaged(ListUsuariosViewModel model, int? page)
        {
            ViewBag.filter = model.Filter;
            model.ListUsuarios = new UsuarioLogic().GetUsuariosPagedList(GetDataContext(), model.Filter, page);
            return PartialView("PartialView/_ListUsuariosPartialView", model.ListUsuarios);
        }

        [AppViewAuthorize(ConstantHelper.Vistas.Administracion.Usuario.LISTAR)]
        public ActionResult _ListUsuariosPartialView(string filter)
        {
            ViewBag.filter = filter;
            var list = new UsuarioLogic().GetUsuariosPagedList(GetDataContext(), filter, null);
            return PartialView("PartialView/_ListUsuariosPartialView", list);
        }

        [AppViewAuthorize(ConstantHelper.Vistas.Administracion.Usuario.CREAR)]
        public ActionResult AddUpdateUsuario(int? usuarioId)
        {
            var model = new UsuarioLogic().GetUsuario(GetDataContext(), usuarioId);
            return View(model);
        }

        [AppViewAuthorize(ConstantHelper.Vistas.Administracion.Usuario.CREAR)]
        public ActionResult DisableUsuario(int? usuarioId)
        {
            new UsuarioLogic().DisableUsuario(GetDataContext(), usuarioId);
            return RedirectToAction(nameof(ListUsuarios));
        }

        #endregion

        //TODO: SELECT * FROM OIDC - TIPO DOCUMENTOS
        #region Post
        [AppViewAuthorize(ConstantHelper.Vistas.Administracion.Usuario.CREAR)]
        [HttpPost]
        public ActionResult AddUpdateUsuario(UsuarioViewModel model, FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    new UsuarioLogic().AddUpdateUsuario(GetDataContext(), model, formCollection);
                    PostMessage(MessageType.Success);
                    return RedirectToAction(nameof(ListUsuarios));
                }
                catch (CustomException ex)
                {
                    PostMessage(ex);
                }
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();
            }

            new UsuarioLogic().FillJLists(GetDataContext(), ref model);
            return View(model);
        }

        #endregion

        #region JsonResult

        public JsonResult GetUsuariosJsonList(string filtro)
        {
            var model = new UsuarioLogic().GetUsuariosJsonList(GetDataContext(), filtro);
            return Json(model);
        }

        #endregion

    }
}