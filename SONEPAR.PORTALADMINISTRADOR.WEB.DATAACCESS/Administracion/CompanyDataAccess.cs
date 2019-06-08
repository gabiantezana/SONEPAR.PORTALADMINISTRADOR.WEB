using System.Collections.Generic;
using SONEPAR.WEB.MODEL;

namespace SONEPAR.WEB.DATAACCESS.Administracion
{
    public class CompanyDataAccess
    {
        private DataContext DataContext { get; set; }

        public CompanyDataAccess(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public IEnumerable<MODEL.Company> GetList(string filter)
        {
            /*
            var query = DataContext.Context.Company.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                query = filter.ToLower().Split(' ').Aggregate(query, (current, token) => current.Where(x => x.DbName.ToLower().Contains(token)));
            }
            return query;*/
            return null;
        }

        public MODEL.Company GetItem(int? CompanyId)
        {
            //return DataContext.Context.Company.Find(CompanyId);
            return null;
        }
    }
}
