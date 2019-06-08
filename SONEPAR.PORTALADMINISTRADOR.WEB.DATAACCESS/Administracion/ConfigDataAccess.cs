using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using PagedList;
using SONEPAR.PORTALADMINISTRADOR.WEB.EXCEPTION;
using SONEPAR.PORTALADMINISTRADOR.WEB.HELPER;
using SONEPAR.PORTALADMINISTRADOR.WEB.MODEL;
using SONEPAR.PORTALADMINISTRADOR.WEB.VIEWMODEL.Administracion.Config;

namespace SONEPAR.PORTALADMINISTRADOR.WEB.DATAACCESS.Administracion
{
    public class ConfigDataAccess
    {
        private DataContext DataContext { get; set; }
        public ConfigDataAccess(DataContext DataContext)
        {
            this.DataContext = DataContext;
        }

        public IPagedList<CONFIG> LstConfigs(String CampoBuscar, Int32? page)
        {
            var query = DataContext.Context.CONFIG.AsQueryable();
            var p = page ?? 1;
            if (!string.IsNullOrEmpty(CampoBuscar))
            {
                foreach (var token in CampoBuscar.Split(' '))
                {
                    query = query.Where(x => x.Descripcion.Contains(token));
                }
            }
            return query.OrderBy(x => x.CONFIGId).ToPagedList(p, query.Count());
        }

        public IPagedList<CONFIG> LstConfigs(Int32? page)
        {
            var query = DataContext.Context.CONFIG.AsQueryable();
            var p = page ?? 1;
            return query.OrderBy(x => x.CONFIGId).ToPagedList(p, !query.Any() ? 1 : query.Count());
        }

        public List<JsonEntityTwoString> GetConfigs(String CampoBuscar)
        {
            var query = DataContext.Context.CONFIG.AsQueryable();

            if (!string.IsNullOrEmpty(CampoBuscar))
            {
                foreach (var token in CampoBuscar.Split(' '))
                {
                    query = query.Where(x => x.Descripcion.Contains(token));
                }
            }

            return query.Select(x => new JsonEntityTwoString
            {
                id = x.CONFIGId,
                text = x.Descripcion
            }).ToList();
        }

        public IPagedList<CONFIG> GetConfigs(String ConfigId, Int32? p)
        {
            var query = DataContext.Context.CONFIG.AsQueryable();
            var page = p ?? 1;

            if (!String.IsNullOrEmpty(ConfigId))
                query = query.Where(x => x.Descripcion == ConfigId);

            return query.OrderBy(a => a.Descripcion).ToPagedList(page, query.Count());
        }

        public ConfigViewModel GetConfig(string ConfigId)
        {
            CONFIG config = DataContext.Context.CONFIG.FirstOrDefault(x => x.CONFIGId == ConfigId);
            ConfigViewModel model = new ConfigViewModel();

            if (config != null)
            {
                model.id = config.CONFIGId;
                model.valor = config.Valor;
                model.descripcion = config.Descripcion;
            }

            return model;
        }

        public String GetCONFIGValue(String idConfig)
        {
            String valor = null;

            var data = DataContext.Context.CONFIG.Where(x => x.CONFIGId == idConfig).FirstOrDefault();
            var data2 = DataContext.Context.CONFIG.ToList();
            if (data != null)
                return valor = data.Valor;
            else
                throw new Exception("No se encontró el valor " + idConfig + " en las configuraciones");
        }

        public String SaveConfig(ConfigViewModel model)
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    CONFIG config = DataContext.Context.CONFIG.FirstOrDefault(x => x.CONFIGId == model.id);


                    bool existe = true;

                    if (config == null)
                    {
                        config = new CONFIG();
                        existe = false;
                    }

                    bool configrepetido = false;
                    if (!existe)
                        configrepetido = ValidateConfigRepetido(model);

                    if (configrepetido)
                    {
                        throw new CustomException(new TempDataEntityException { Mensaje = "El parámetro ya se encuentra registrado", TipoMensaje = MessageTypeException.Warning }, DataContext);
                    }
                    config.CONFIGId = model.id;
                    config.Descripcion = model.descripcion;
                    config.Valor = model.valor;

                    if (!existe)
                        DataContext.Context.CONFIG.Add(config);

                    DataContext.Context.SaveChanges();
                    transaction.Complete();

                    return config.CONFIGId;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public bool ValidateConfigRepetido(ConfigViewModel model)
        {
            return true;
            /*
            bool repetido = false;

            var config = DataContext.Context.CONFIG.FirstOrDefault(x => x.Id.ToUpper() == model.id.ToUpper());

            if (config != null)
                repetido = true;

            return repetido;
            */
        }

        public void FillListsFromOtherModel(ConfigViewModel fromModel, ref ConfigViewModel model)
        {
            model.id = fromModel.id;
            model.valor = fromModel.valor;
            model.descripcion = fromModel.descripcion;

        }
    }
}
