﻿using System.Web.Optimization;

namespace Annytab.Blogsite
{
    /// <summary>
    /// This class handles bundling of static files
    /// </summary>
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Add references to jquery script
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery.mousewheel.js",
                        "~/Scripts/spin.min.js",
                        "~/Scripts/jquery.spin.js"));

            // Add references to annytab back-end scripts
            bundles.Add(new ScriptBundle("~/bundles/annytab_admin").Include(
                        "~/Scripts/annytab_admin/annytab.default.js"));

            // Add references to admin css files
            bundles.Add(new StyleBundle("~/Content/admin_css").Include(
                "~/Content/annytab_css/admin_default.css",
                "~/Content/annytab_css/admin_layout.css"));

        } // End of the RegisterBundles method

    } // End of the class

} // End of the namespace