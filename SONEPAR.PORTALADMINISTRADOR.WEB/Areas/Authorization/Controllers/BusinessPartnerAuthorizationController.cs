using SONEPAR.PORTALADMINISTRADOR.WEB.Controllers;
using SONEPAR.PORTALADMINISTRADOR.WEB.Filters;
using SONEPAR.PORTALADMINISTRADOR.WEB.HELPER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SICER.Areas.Authorization.Controllers
{
    public class AuthorizationController : BaseController
    {
        public ActionResult List()
        {
            var model = string.Empty;
            return View(model);
        }
    }
}