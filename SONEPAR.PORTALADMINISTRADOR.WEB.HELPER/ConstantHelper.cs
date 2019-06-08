using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList.Mvc;

namespace SONEPAR.PORTALADMINISTRADOR.WEB.HELPER
{
    public class ConstantHelper
    {
        public static readonly byte[] ENCRIPT_KEY = { 45, 12, 45, 78, 2, 45, 12, 65, 87, 12, 45, 32, 20, 58, 15, 36, 47, 85, 96, 20, 24, 23, 65, 24 };
        public static readonly byte[] ENCRIPT_METHOD = { 87, 10, 65, 35, 12, 66, 21, 65 };
        public static int NUMEROFILASPORPAGINA = 10;
        public static object MENSAJE_TABLA_VACIA = "No se encontraron registros.";
        public static int DefaulSuccessSAPNumber = 0;

        public const string MENSAJE_EXITO = "Operación  realizada exitosamente.";
        public const string MENSAJE_ERROR = "Ocurrió un error.";
        public const string SEPARADOR_NOMBRE_DESCRIPCION_SELECT = " - ";
        public const string PASSWORD_DEFAULT = "1234";
        public const string CODIGOROLSUPERADMINISTRADOR = "SUPERADMIN";
        public const string CODIGOROLGESTORDOCUMENTOS = "GESTORDOCUMENTOS";

        public const string CAJACHICA = "CAJACHICA";
        public const string ENTREGARENDIR = "ENTREGARENDIR";
        public const string REEMBOLSO = "REEMBOLSO";
        public const string SBO_TEST001 = "[SBO_TEST001]";

        public static class Rol
        {
            public const String SUPERADMIN = "SUPERADMIN";

        }

        public static class Vistas
        {
            public static class Administracion
            {
                private const string PARENTPREFIX = "ADMINISTRACION.";

                public static class Usuario
                {
                    private const string PREFIX = PARENTPREFIX + "USUARIO.";

                    public const string LISTAR = PREFIX + "LISTAR";
                    public const string CREAR = PREFIX + "CREAR";
                }

                public static class Rol
                {
                    private const string PREFIX = PARENTPREFIX + "ROL.";

                    public const string LISTAR = PREFIX + "LISTAR";
                    public const string CREAR = PREFIX + "CREAR";
                }

                public static class CONFIG
                {
                    private const string PREFIX = PARENTPREFIX + "CONFIG.";

                    public const string LISTAR = PREFIX + "LISTAR";
                    public const string CREAR = PREFIX + "CREAR";
                }


            }

            public static class AUTORIZACION
            {
                private const string PARENTPREFIX = "AUTORIZACION.";
                public const string LISTAR = PARENTPREFIX + "LISTAR";
                public const string VER = PARENTPREFIX + "VER";
                public const string AUTORIZAR = PARENTPREFIX + "AUTORIZAR";
            }

        }

        public static class Area
        {
            public const string ADMINISTRACION = "ADMINISTRACION";
        }

        public static class WEBCONFIG
        {
            public const String PORTAL_NAME = "PORTAL_NAME";
        }

        public const int DefaultFieldSize = 200;
        public const string ParameterPath = "../Parameters/ConnectionParameters.xml";

        public static PagedListRenderOptions Bootstrap3Pager
        {
            get
            {
                return new PagedListRenderOptions
                {
                    DisplayLinkToFirstPage = PagedListDisplayMode.IfNeeded,
                    DisplayLinkToLastPage = PagedListDisplayMode.IfNeeded,
                    DisplayLinkToPreviousPage = PagedListDisplayMode.IfNeeded,
                    DisplayLinkToNextPage = PagedListDisplayMode.IfNeeded,
                    DisplayLinkToIndividualPages = true,
                    DisplayPageCountAndCurrentLocation = false,
                    MaximumPageNumbersToDisplay = 10,
                    DisplayEllipsesWhenNotShowingAllPageNumbers = true,
                    EllipsesFormat = "&#8230;",
                    LinkToFirstPageFormat = "««",
                    LinkToPreviousPageFormat = "«",
                    LinkToIndividualPageFormat = "{0}",
                    LinkToNextPageFormat = "»",
                    LinkToLastPageFormat = "»»",
                    PageCountAndCurrentLocationFormat = "Page {0} of {1}.",
                    ItemSliceAndTotalFormat = "Showing items {0} through {1} of {2}.",
                    FunctionToDisplayEachPageNumber = null,
                    ClassToApplyToFirstListItemInPager = null,
                    ClassToApplyToLastListItemInPager = null,
                    ContainerDivClasses = new[] { "pagination-container" },
                    UlElementClasses = new[] { "pagination" },
                    LiElementClasses = Enumerable.Empty<string>(),
                };
            }
        }

        public static class CONFIG
        {
            public static string DIRECTORY_PATH = "USERS_DIRECTORY_PATH";
            public static string DIRECTORY_DOMAIN = "USERS_DIRECTORY_DOMAIN";
        }
    }
}
