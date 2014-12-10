using System.Web;
using System.Web.Optimization;

namespace MyBlog.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery*",
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));
        }
    }
}