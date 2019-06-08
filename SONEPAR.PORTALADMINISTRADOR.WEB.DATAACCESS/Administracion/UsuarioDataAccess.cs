using SONEPAR.PORTALADMINISTRADOR.WEB.VIEWMODEL.Administracion.Usuario;
using System.Collections.Generic;
using System.Linq;
using SONEPAR.PORTALADMINISTRADOR.WEB.MODEL;
using SONEPAR.PORTALADMINISTRADOR.WEB.VIEWMODEL.General;
using SONEPAR.PORTALADMINISTRADOR.WEB.HELPER;
using System;
using System.Transactions;

namespace SONEPAR.PORTALADMINISTRADOR.WEB.DATAACCESS.Administracion
{
    public class UsuarioDataAccess
    {
        private DataContext DataContext { get; set; }
        public UsuarioDataAccess(DataContext dataContext) { DataContext = dataContext; }

        private IQueryable<Usuario> QueryUsuarios(string filtro, int? usuarioId = null)
        {
            var query = DataContext.Context.Usuario.AsQueryable();

            switch (DataContext.Session.GetRol())
            {
                case AppRol.SUPERADMIN:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (usuarioId.HasValue)
                query = query.Where(x => x.UsuarioId == usuarioId);

            else if (!string.IsNullOrEmpty(filtro))
            {
                return filtro.ToLower().Split(' ').Aggregate(query, (current, token) =>
                current.Where(x => x.Username.ToLower().Contains(token)
                                || x.SapUsername.ToLower().Contains(token)
                                || x.Office365Mail.ToLower().Contains(token)
                    ));
            }


            //-----------------------Remove super admin from list-----------------------
            if (DataContext.Session.GetRol() != AppRol.SUPERADMIN)
                query = query.Where(x => x.RolId != (int)AppRol.SUPERADMIN);

            //-----------------------Remove current user from list/-----------------------
            var currentUserId = DataContext.Session.GetIdUsuario();
            query = query.Where(x => x.UsuarioId != currentUserId);

            return query;
        }

        public IEnumerable<Usuario> GetList(string filter, int? usuarioId)
        {
            return QueryUsuarios(filter, usuarioId);
        }

        public IEnumerable<UsuarioRoles> GetUsuarioRolesList(int? usuarioId)
        {
            return DataContext.Context.UsuarioRoles.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public Usuario GetUsuario(int? usuarioId)
        {
            return DataContext.Context.Usuario.Find(usuarioId);
        }

        public void AddUpdateUsuario(UsuarioViewModel model)
        {
            Usuario usuario = DataContext.Context.Usuario.Find(model.UsuarioId);
            bool isUpdate = usuario != null;

            using (var transacionScope = new TransactionScope())
            {
                if (!isUpdate)
                    usuario = new Usuario();
                usuario.Username = model.Username;

                usuario.IsActive = model.IsActive;
                usuario.Office365Mail = model.Office365Mail;
                usuario.RolId = model.RolId;
                usuario.SapUsername = model.SapUsername;
                usuario.Username = model.Username;

                if (isUpdate)
                    DataContext.Context.Entry(usuario);
                else
                    DataContext.Context.Usuario.Add(usuario);
                DataContext.Context.SaveChanges();

                #region SubRoles

                //Desactiva todos los subroles de usuario
                foreach (var usuarioRol in DataContext.Context.UsuarioRoles.Where(x => x.UsuarioId == model.UsuarioId))
                {
                    usuarioRol.Estado = false;
                }

                //Activa todos los subroles de usuario que estén contenidos en model.RolList
                foreach (var rol in model.RolList)
                {
                    var usuarioRol = DataContext.Context.UsuarioRoles.FirstOrDefault(x => x.Rol.Codigo == rol.Codigo && x.UsuarioId == model.UsuarioId);
                    if (usuarioRol == null)
                    {
                        usuarioRol = new UsuarioRoles()
                        {
                            UsuarioId = usuario.UsuarioId,
                            RolId = rol.RolId,
                            Estado = true,
                        };

                        DataContext.Context.UsuarioRoles.Add(usuarioRol);
                    }
                    else
                    {
                        usuarioRol.Estado = true;
                        DataContext.Context.Entry(usuarioRol);
                    }
                }

                DataContext.Context.SaveChanges();

                #endregion

                transacionScope.Complete();
            }
            return;
        }

        public void DisableUsuario(int? UsuarioId)
        {
            var usuario = DataContext.Context.Usuario.Find(UsuarioId);
            if (usuario == null) return;

            usuario.IsActive = !usuario.IsActive;
            DataContext.Context.Entry(usuario);
            DataContext.Context.SaveChanges();
        }
    }
}
