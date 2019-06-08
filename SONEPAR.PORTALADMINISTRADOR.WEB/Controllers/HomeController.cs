using SONEPAR.PORTALADMINISTRADOR.WEB.HELPER;
using SONEPAR.PORTALADMINISTRADOR.WEB.MODEL;
using SONEPAR.PORTALADMINISTRADOR.WEB.VIEWMODEL.General;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using SONEPAR.PORTALADMINISTRADOR.WEB.LOGIC.Administracion;
using SONEPAR.PORTALADMINISTRADOR.WEB.EXCEPTION;

namespace SONEPAR.PORTALADMINISTRADOR.WEB.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                /*
                Session.Set(SessionKey.NombresUsuario, "gabiantezana");
                Session.Set(SessionKey.UserName, "gabiantezana");
                Session.Set(SessionKey.UsuarioId, "gabiantezana");
                Session.Set(SessionKey.CompanyName, "gabiantezana");
                Session.Set(SessionKey.CompanyId, "gabiantezana");
                return RedirectToAction(nameof(this.Index));
                */
                //-----------------------TEST---------------------------
                /*
                Usuario _usuario = GetDataContext().Context.Usuario.Include(x => x.Rol.VistaRol.Select(y => y.Vista)).FirstOrDefault(x => x.Username == model.Codigo);
                Session.Set(SessionKey.NombresUsuario, _usuario.Username);
                Session.Set(SessionKey.Rol, (AppRol)Enum.Parse(typeof(AppRol), _usuario.Rol.Codigo));
                Session.Set(SessionKey.Vistas, context.Vista.Select(x => x.Codigo).ToArray());
                return RedirectToAction(nameof(ChangePassword));
                */
                //-----------------------TEST---------------------------

                Usuario usuario = GetDataContext().Context.Usuario.Include(x => x.Rol.VistaRol.Select(y => y.Vista)).FirstOrDefault(x => x.Username == model.Codigo);
                if (usuario != null)
                {
                    if (usuario.Rol.Codigo != AppRol.SUPERADMIN.ToString())
                    {
                        usuario = GetDataContext().Context.Usuario.Include(x => x.Rol.VistaRol.Select(y => y.Vista))
                            .FirstOrDefault(x => x.Username == model.Codigo);
                        if (usuario == null)
                        {
                            PostMessage(MessageType.Error, "Su usuario no tiene permiso para esta compañía.");
                            return RedirectToAction(nameof(this.Login));
                        }
                    }
                    if (!new UsuarioLogic().PasswordIsCorrect(GetDataContext(), model.Codigo, model.Password))
                    {
                        PostMessage(MessageType.Error, "Contraseña incorrecta");
                        return RedirectToAction(nameof(this.Login));
                    }
                    if (usuario.IsActive != true)
                    {
                        PostMessage(MessageType.Error, "Su usuario no se encuentra activo");
                        return RedirectToAction(nameof(this.Login));
                    }

                    Session.Set(SessionKey.NombresUsuario, usuario.Username);
                    Session.Set(SessionKey.UserName, usuario.Username);
                    Session.Set(SessionKey.UsuarioId, usuario.UsuarioId);

                    if (usuario.Rol.Codigo == ConstantHelper.CODIGOROLSUPERADMINISTRADOR)
                    {
                        Session.Set(SessionKey.Rol, AppRol.SUPERADMIN);
                        Session.Set(SessionKey.Vistas, GetDataContext().Context.Vista.Select(x => x.Codigo).ToArray());
                    }
                    else
                    {
                        Session.Set(SessionKey.Rol, Enum.Parse(typeof(AppRol), usuario.Rol.Codigo));
                        Session.Set(SessionKey.Vistas, usuario.Rol.VistaRol.Where(x => x.Estado).Select(x => x.Vista.Codigo).ToArray());
                        if (usuario.Rol.Codigo == ConstantHelper.CODIGOROLGESTORDOCUMENTOS)
                        {
                            var vistasDeRolesUsuario = GetDataContext().Context.UsuarioRoles
                                 .Where(x => x.UsuarioId == usuario.UsuarioId && x.Estado).SelectMany(x => x.Rol.VistaRol).Select(y => y.Vista.Codigo).ToArray();

                            Session.Set(SessionKey.Vistas, vistasDeRolesUsuario);
                        }
                    }

                    var defaultEncryptPassword = EncryptionHelper.EncryptTextToMemory(ConstantHelper.PASSWORD_DEFAULT, ConstantHelper.ENCRIPT_KEY, ConstantHelper.ENCRIPT_METHOD);
                    return RedirectToAction(nameof(this.Index));
                }

                PostMessage(MessageType.Error, "Su usuario no existe");
                return RedirectToAction(nameof(this.Login));
            }
            catch (CustomException ex)
            {
                PostMessage(MessageType.Error, ex.Message);
            }
            return RedirectToAction(nameof(this.Login));
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction(nameof(this.Login));
        }

        public ContentResult KeepAlive()
        {
            return Content(String.Empty);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                new UsuarioLogic().ChangePassword(GetDataContext(), model);

                PostMessage(MessageType.Success, "Su contraseña se cambio exitosamente");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Session.Clear();
                PostMessage(MessageType.Error, ex.ToString());
                return RedirectToAction(nameof(this.Login));
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult PermisoInsuficiente()
        {
            return View();
        }
    }
}