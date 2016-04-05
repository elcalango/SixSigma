using System.Web;
using System.Web.Optimization;

namespace View
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/AdminLTE-2.3.0/plugins/jQuery/jQuery-2.1.4.min.js"));

           
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js" ));

            bundles.Add(new ScriptBundle("~/bundles/AdminLTE-2.3.0/js").Include(
                      "~/Scripts/AdminLTE-2.3.0/app.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/bootstrap.css" ));

            bundles.Add(new StyleBundle("~/AdminLTE-2.3.0/css").Include(
                      "~/Content/AdminLTE-2.3.0/AdminLTE.min.css",
                      "~/Content/AdminLTE-2.3.0/skins/skin-blue.min.css"));
        }
    }
}
