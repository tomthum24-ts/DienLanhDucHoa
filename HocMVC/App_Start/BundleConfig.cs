using System.Web;
using System.Web.Optimization;

namespace HocMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/Js").Include(
                      "~/Public/Layout/Js/fullpage.extensions.min.js",
                      "~/Public/Layout/Js/jquery.slim.min.js",
                      "~/Public/Layout/Js/bootstrap.bundle.min.js",
                      "~/Public/Layout/Js/jquery.min.js",
                      "~/Public/Layout/Js/owl.carousel.min.js",
                      "~/Public/Layout/Js/smooth-scrollbar.js",
                      "~/Public/Layout/Js/aos.js",
                      "~/Public/Layout/Js/pageload.js",
                      "~/Public/Layout/Js/animation.js",
                      "~/Public/Layout/Js/app.js",
                      "~/Public/Layout/Js/project.js",
                      "~/Public/Layout/Js/bootstrap.bundle.min.js",
                      "~/Public/Layout/Js/scroll-animation.js"
                      ));
            bundles.Add(new StyleBundle("~/Styles").Include(
                     "~/Public/Layout/Scss/aos.css",
                     "~/Public/Layout/Scss/fullpage.min.css",
                     "~/Public/Layout/Scss/examples.css",
                     //"~/Public/Layout/Scss/bootstrap.min.css",
                     "~/Public/Layout/Scss/owl.carousel.min.css",
                     "~/Public/Layout/Scss/owl.theme.default.min.css",
                     "~/Public/Layout/Scss/smooth-scrollbar.css",
                     "~/Public/Layout/Scss/style.css"
                     ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
