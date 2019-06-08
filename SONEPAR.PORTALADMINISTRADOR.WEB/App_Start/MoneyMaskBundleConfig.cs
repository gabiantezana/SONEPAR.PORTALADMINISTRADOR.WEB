using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(SONEPAR.PORTALADMINISTRADOR.WEB.App_Start.MoneyMaskBundleConfig), "RegisterBundles")]

namespace SONEPAR.PORTALADMINISTRADOR.WEB.App_Start
{
	public class MoneyMaskBundleConfig
	{
		public static void RegisterBundles()
		{
			BundleTable.Bundles.Add(new ScriptBundle("~/bundles/moneymask").Include("~/Scripts/jquery.moneymask.js"));
		}
	}
}