﻿using System.Web;
using System.Web.Optimization;

namespace Auth.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            if (Auth.Web.Controllers.BaseController.AreaName == Auth.Models.Constants.C_WebAreaName)
            {
                //bundle for web scripts

                #region JQery
                bundles.Add(new ScriptBundle("~/" + Auth.Models.Constants.C_WebAreaName + "/bundles/jquery").Include(
                            "~/Areas/Web/Scripts/jquery-{version}.js"));

                bundles.Add(new ScriptBundle("~/" + Auth.Models.Constants.C_WebAreaName + "/bundles/jqueryval").Include(
                            "~/Areas/Web/Scripts/jquery.validate*"));
                #endregion

                #region Modernizr
                bundles.Add(new ScriptBundle("~/" + Auth.Models.Constants.C_WebAreaName + "/bundles/modernizr").Include(
                            "~/Areas/Web/Scripts/modernizr-*"));
                #endregion

                #region Bootstrap
                bundles.Add(new ScriptBundle("~/" + Auth.Models.Constants.C_WebAreaName + "/bundles/bootstrap").Include(
                          "~/Areas/Web/Scripts/bootstrap.js",
                          "~/Areas/Web/Scripts/respond.js"));
                #endregion

                #region SiteScripts
                bundles.Add(new ScriptBundle("~/" + Auth.Models.Constants.C_WebAreaName + "/sitescripts").IncludeDirectory(
                          "~/Areas/Web/Scripts/Site",
                          "*.js",
                          true));
                #endregion

                #region Styles
                bundles.Add(new StyleBundle("~/" + Auth.Models.Constants.C_WebAreaName + "/content/css").IncludeDirectory(
                          "~/Areas/Web/Content/Styles",
                          "*.css",
                          true));
                #endregion
            }
            else if (Auth.Web.Controllers.BaseController.AreaName == Auth.Models.Constants.C_MobileAreaName)
            {
                //bundle for mobile scirpts
            }

        }
    }
}
