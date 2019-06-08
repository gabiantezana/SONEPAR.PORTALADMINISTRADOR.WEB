using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using SONEPAR.PORTALADMINISTRADOR.WEB.DATAACCESS.Administracion;
using SONEPAR.PORTALADMINISTRADOR.WEB.EXCEPTION;
using SONEPAR.PORTALADMINISTRADOR.WEB.HELPER;
using SONEPAR.PORTALADMINISTRADOR.WEB.VIEWMODEL.Administracion.Usuario;
using SONEPAR.PORTALADMINISTRADOR.WEB.VIEWMODEL.General;
using SONEPAR.PORTALADMINISTRADOR.WEB.MODEL;
using System.DirectoryServices;

namespace SONEPAR.PORTALADMINISTRADOR.WEB.LOGIC.Administracion
{
    public class UsuarioLogic
    {
        private IEnumerable<Usuario> GetQueryUsuariosList(DataContext dataContext, string filtro = null, int? usuarioId = null)
        {
            return new UsuarioDataAccess(dataContext).GetList(filtro, usuarioId);
        }

        public ListUsuariosViewModel GetListUsuariosViewModel(DataContext dataContext, string query, int? page)
        {
            var model = new ListUsuariosViewModel()
            {
                ListUsuarios = GetUsuariosPagedList(dataContext, query, page),
                Filter = string.Empty,
                ListUsuariosDefault = new List<Usuario>()
            };
            return model;
        }

        public IPagedList<Usuario> GetUsuariosPagedList(DataContext dataContext, string query, int? page)
        {
            return GetQueryUsuariosList(dataContext, query).ToList().ToPagedList(page ?? 1, ConstantHelper.NUMEROFILASPORPAGINA);
        }

        public void FillJLists(DataContext dataContext, ref UsuarioViewModel model)
        {
            //Fill select
            model.RolJList = RolLogic.GetJList(dataContext, RolNivel.Principal);
            //Fill all secundary roles
            model.RolList = new RolDataAccess(dataContext).GetList(RolNivel.Secundario);
            //Fill all user roles
            model.RolUserList = new UsuarioDataAccess(dataContext).GetUsuarioRolesList(model.UsuarioId);
        }

        public UsuarioViewModel GetUsuario(DataContext dataContext, int? usuarioId)
        {
            Usuario usuario = new UsuarioDataAccess(dataContext).GetUsuario(usuarioId);
            return GetUsuarioViewModel(dataContext, usuario);
        }

        public void AddUpdateUsuario(DataContext dataContext, UsuarioViewModel model, FormCollection formCollection)
        {

            ValidarDuplicado(dataContext, model);

            model.RolUserList = new List<UsuarioRoles>();
            var rolesUsuarioKey = formCollection.AllKeys.Where(x => x.StartsWith("chk-"));
            var nivelesAprobacionIds = formCollection.AllKeys.Where(x => x.StartsWith("chkNivelAprobacion-"));
            var listadoRolesActivos = new List<Rol>();
            var listadoNivelesDeAprobacion = new List<int>();

            model.RolList = listadoRolesActivos;
            new UsuarioDataAccess(dataContext).AddUpdateUsuario(model);
        }
        [Obsolete]
        public void ChangePassword(DataContext dataContext, ChangePasswordViewModel model)
        {
            //new UsuarioDataAccess(dataContext).ChangePassword(model);
        }

        public bool PasswordIsCorrect(DataContext dataContext, string user, string pass)
        {
            var path = ConfigLogic.GetCONFIGValue(dataContext, ConstantHelper.CONFIG.DIRECTORY_PATH);
            var domain = ConfigLogic.GetCONFIGValue(dataContext, ConstantHelper.CONFIG.DIRECTORY_DOMAIN);
            var _user = domain + "\\" + user.ToSafeString().Substring(0, user.IndexOf('@'));
            using (DirectoryEntry _entry = new DirectoryEntry())
            {
                _entry.Username = _user;
                _entry.Password = pass;
                DirectorySearcher _searcher = new DirectorySearcher(_entry);
                _searcher.Filter = "(objectclass=user)";
                try
                {
                    SearchResult _sr = _searcher.FindOne();
                    //string _name = _sr.Properties["displayname"][0].ToString();
                    return true;
                }
                catch (Exception ex)
                { throw new CustomException("Usuario y/o contraseña incorrectos"); }
            }
        }

        private UsuarioViewModel GetUsuarioViewModel(DataContext dataContext, Usuario usuario)
        {
            UsuarioViewModel model = usuario?.ConvertTo(typeof(UsuarioViewModel));
            model = model ?? new UsuarioViewModel();

            if (usuario == null)
                FillDataInicial(dataContext, ref model);
            FillJLists(dataContext, ref model);
            return model;
        }

        private void FillDataInicial(DataContext dataContext, ref UsuarioViewModel model)
        {
        }

        private void ValidarDuplicado(DataContext dataContext, UsuarioViewModel model)
        {
            /*
            const string message = "El nombre de usuario ya existe para otro usuario en la misma compañía.";
            var usuario = dataContext.Context.Usuario.FirstOrDefault(x => x.UserName == model.UserName
                                                                         && x.CompanyId == model.CompanyId
                                                                         && x.UsuarioId != model.UsuarioId
                                                                         );
            if (usuario != null)
                throw new CustomException(new TempDataEntityException { Mensaje = message, TipoMensaje = MessageTypeException.Warning }, dataContext);
            */
        }

        private UsuarioRolesViewModel GetUsuarioRolViewModel(DataContext dataContext, UsuarioRoles usuarioRoles)
        {
            UsuarioRolesViewModel model = usuarioRoles?.ConvertTo(typeof(UsuarioRolesViewModel));
            model = model ?? new UsuarioRolesViewModel();
            return model;
        }

        public void DisableUsuario(DataContext dataContext, int? usuarioId)
        {
            new UsuarioDataAccess(dataContext).DisableUsuario(usuarioId);
        }

        /// <summary>
        /// Filtrar listado de usuarios por nombres y usuario
        /// </summary>
        public IEnumerable<JsonEntity> GetUsuariosJsonList(DataContext dataContext, string filtro)
        {
            /*
            var query = GetQueryUsuariosList(dataContext);
            if (!string.IsNullOrEmpty(filtro))
            {
                query = filtro.ToLower().Split(' ').Aggregate(query,
                    (current, token) => current.Where(x => x.Apellidos.ToLower().Contains(token)
                                         || x.Nombres.ToLower().Contains(token)
                                         || x.UserName.ToLower().Contains(token)));
            }
            var jsonEntities = query?.Select(x => new JsonEntity()
            {
                id = x.UsuarioId,
                text = x.GetNombreCompleto(),
            });

            return jsonEntities;*/
            return null;
        }

        public IEnumerable<JsonEntity> GetUsuariosJsonList(DataContext dataContext, int? usuarioId)
        {
            /*
            var query = GetQueryUsuariosList(dataContext).Where(x => x.UsuarioId == usuarioId);
            var jsonEntities = query?.Select(x => new JsonEntity()
            {
                id = x.UsuarioId,
                text = x.GetNombreCompleto(),
            });

            return jsonEntities;*/
            return null;
        }

    }

}

