﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SONEPAR.WEB.MODEL;
using SONEPAR.WEB.VIEWMODEL.Administracion.NivelAprobacion;

namespace SONEPAR.WEB.DATAACCESS.Administracion
{
    public class NivelAprobacionDataAccess
    {
        private DataContext DataContext { get; set; }

        public NivelAprobacionDataAccess(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public IEnumerable<NivelAprobacion> GetList(string filter)
        {
            return null;/*
            var query = DataContext.Context.NivelAprobacion.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                query = filter.ToLower().Split(' ').Aggregate(query, (current, token) 
                                                    => current.Where(x => x.Descripcion.ToLower().Contains(token)
                                                    || x.TipoDocumento.Descripcion.ToLower().Contains(token)));
            }
            return query;*/
        }

        public NivelAprobacion GetEntity(int? nivelAprobacionId)
        {
            return null;
            //return DataContext.Context.NivelAprobacion.Find(nivelAprobacionId);
        }

        public int AddUpdate(NivelAprobacionViewModel model)
        {
            return 0;
            /*
            var entity = DataContext.Context.NivelAprobacion.Find(model.NivelAprobacionId);
            var isUpdate = entity != null;

            if (!isUpdate)
                entity = new NivelAprobacion();

            entity.TipoDocumentoId = model.TipoDocumentoId;
            entity.NumeroNivel = model.NumeroNivel;
            entity.Descripcion = model.Descripcion;

            if (isUpdate)
                DataContext.Context.Entry(entity);
            else
                DataContext.Context.NivelAprobacion.Add(entity);

            return DataContext.Context.SaveChanges();*/
        }
    }
}
