using System.Collections.Generic;
using SONEPAR.WEB.MODEL;
using SONEPAR.WEB.VIEWMODEL.Administracion.Area;

namespace SONEPAR.WEB.DATAACCESS.Administracion
{
    public class AreaDataAccess
    {
        private DataContext DataContext { get; set; }
        public AreaDataAccess(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public IEnumerable<Area> GetList(string filter)
        {
            return null;
            /*
            var query = DataContext.Context.Area.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
               query =  filter.ToLower().Split(' ').Aggregate( query, (current, token) => current.Where(x=> x.Descripcion.ToLower().Contains(token)));
            }
            return query;*/
        }

        public Area GetEntity(int? AreaId)
        {
            return null;
            /*
            return DataContext.Context.Area.Find(AreaId);*/
        }

        public void AddUpdate(AreaViewModel model)
        {
            /*
            var area = DataContext.Context.Area.Find(model.AreaId);
            var isUpdate = area != null;

            if (!isUpdate)
            {
                area = new Area();
            }
            area.Descripcion = model.Descripcion;
            if (isUpdate)
                DataContext.Context.Entry(area);
            else
                DataContext.Context.Area.Add(area);
            DataContext.Context.SaveChanges();
            */
        }
    }
    
}
