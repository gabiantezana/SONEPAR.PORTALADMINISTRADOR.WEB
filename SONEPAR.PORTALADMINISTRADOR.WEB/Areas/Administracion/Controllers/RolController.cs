﻿using SONEPAR.PORTALADMINISTRADOR.WEB.Controllers;
using SONEPAR.PORTALADMINISTRADOR.WEB.Filters;
using SONEPAR.PORTALADMINISTRADOR.WEB.HELPER;
using SONEPAR.PORTALADMINISTRADOR.WEB.VIEWMODEL.Administracion.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using SONEPAR.PORTALADMINISTRADOR.WEB.LOGIC.Administracion;
using SONEPAR.PORTALADMINISTRADOR.WEB.MODEL;

namespace SONEPAR.PORTALADMINISTRADOR.WEB.Areas.Administracion.Controllers
{
    public class RolController : BaseController
    {
        [AppViewAuthorize(ConstantHelper.Vistas.Administracion.Rol.LISTAR)]
        public ActionResult ListRoles()
        {
            var model = RolLogic.GetList(GetDataContext(), RolNivel.Principal);
            return View(model);
        }

        [AppViewAuthorize(ConstantHelper.Vistas.Administracion.Rol.CREAR)]
        public ActionResult EditPermisosPorRoles(int rolId)
        {
            var model = RolLogic.EditPermisosPorRoles(GetDataContext(), rolId);
            return View(model);
        }

        [AppViewAuthorize(ConstantHelper.Vistas.Administracion.Rol.CREAR)]
        public ActionResult AddUpdateRol(int? rolId)
        {
            var model = RolLogic.GetRol(GetDataContext(), rolId);
            return View(model);
        }

        [AppViewAuthorize(ConstantHelper.Vistas.Administracion.Rol.CREAR)]
        [HttpPost]
        public ActionResult AddUpdateRol(RolViewModel model)
        {
            RolLogic.AddUpdateRol(GetDataContext(), model);
            return RedirectToAction(nameof(ListRoles));
        }

        [AppViewAuthorize(ConstantHelper.Vistas.Administracion.Rol.CREAR)]
        [HttpPost]//TODO: REMOVE DATAACCESS
        public ActionResult ListRoles(LstRolUsuarioViewModel model, FormCollection collection)
        {
            try
            {
                var logic = new RolLogic();
                var rolId = model.RolId;
                List<VistaRol> vistasRoles = context.VistaRol.Where(x => x.RolId == rolId).ToList();

                using (var transaction = new TransactionScope())
                {
                    foreach (var vistaRol in vistasRoles)
                    {
                        vistaRol.Estado = false;
                        context.SaveChanges();
                    }
                    transaction.Complete();
                }

                var vistasUsariosKey = collection.AllKeys.Where(x => x.StartsWith("chk-"));
                using (var transaction = new TransactionScope())
                {
                    foreach (var vistaUsuarioKey in vistasUsariosKey)
                    {
                        var value = collection[vistaUsuarioKey.ToString()] == "on" || collection[vistaUsuarioKey.ToString()] == "true" ? true : false;

                        var vistaCodigo = vistaUsuarioKey.Split('-')[1];
                        VistaRol vistaRol = context.VistaRol.FirstOrDefault(x => x.RolId == rolId && x.Vista.Codigo.Equals(vistaCodigo));

                        if (vistaRol == null)
                        {
                            Vista vista = context.Vista.FirstOrDefault(x => x.Codigo.Equals(vistaCodigo));
                            vistaRol = new VistaRol
                            {
                                RolId = rolId,
                                VistaId = vista.VistaId,
                                Estado = value
                            };
                            context.VistaRol.Add(vistaRol);
                        }
                        else
                        {
                            vistaRol.Estado = value;
                        }
                        context.SaveChanges();

                    }
                    transaction.Complete();
                    PostMessage(MessageType.Success);
                }
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, "Ocurrio un error inesperado. " + ex.ToString());
            }

            return RedirectToAction(nameof(ListRoles));
        }

    }
}