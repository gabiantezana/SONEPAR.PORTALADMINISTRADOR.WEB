using SONEPAR.PORTALADMINISTRADOR.WEB.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICER.DATAACCESS.Authorization
{
    public class AuthorizationDataAccess
    {
        public List<Authorizationn> GetAuthorizationnList(DataContext dataContext, int userId)
        {
            return null;
        }

        public int MyProperty { get; set; }
        private void GetAprovalTypeLevelsIdFromUser(string sapUsername)
        {
            var list = new DB_SAPAUTHORIZATIONEntities().SapUsersPerAprovalTypeLevel
                .Where(x => x.sapUsername == sapUsername)
                .Select(x => x.AprovalSubTypeId)
                .Distinct()
                .ToList();
        }

        private Authorizationn AddNewAuthorization(int SapObjectType, int sapKey, int aprovalTypeId)
        {
            var approvalTypeLevels = new DB_SAPAUTHORIZATIONEntities().AprovalSubType
                .Where(x => x.AprovalTypeId == aprovalTypeId)
                .OrderBy(x => x.NumberOrder)
                .Select(x => x.AprovalTypeId);

            var maxAprovalSubTypeId = approvalTypeLevels.Max();
            var nextAprovalSubTypeId = approvalTypeLevels.Min();

            var context = new DB_SAPAUTHORIZATIONEntities();
            var authorization = new Authorizationn();
            authorization.SapObjectType = SapObjectType;
            authorization.SapKey = sapKey;
            authorization.AprovalTypeId = aprovalTypeId;
            authorization.MaxAprovalSubTypeId = maxAprovalSubTypeId;
            authorization.CurrentAprovalSubTypeId = null;
            authorization.NextAprovalSubTypeId = nextAprovalSubTypeId;
            context.Authorizationn.Add(authorization);
            context.SaveChanges();

            return authorization;
        }

        private int GetNextApprovalTypeLevel(int authorizationId)
        {
            var authorizationn = new DB_SAPAUTHORIZATIONEntities().Authorizationn.Find(authorizationId);
            var aprovalSubTypes = new DB_SAPAUTHORIZATIONEntities().AprovalSubType
                                    .Where(x => x.AprovalTypeId == authorizationn.AprovalTypeId);

            var nextaprovalSubType = aprovalSubTypes.Where(x => x.NumberOrder > (authorizationn.CurrentAprovalSubTypeId ?? 0)
                                                                    && authorizationn.MaxAprovalSubTypeId.HasValue || x.NumberOrder <= authorizationn.NextAprovalSubTypeId)
                                                         .OrderBy(x => x.NumberOrder)
                                                         .FirstOrDefault().AprovalSubTypeId;

            return nextaprovalSubType;
        }

        //Addon:
        //Si tiene alguna autorización, no permitir grabar. 
        //Luego mostrar una ventana preguntando si desea pedir una autorización.
        //En backend grabar el borrador e insertarlo a la tabla de autorizaciones.

    }
}
