﻿// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
public static partial class MVC
{
    static readonly MobileClass s_Mobile = new MobileClass();
    public static MobileClass Mobile { get { return s_Mobile; } }
    static readonly WebClass s_Web = new WebClass();
    public static WebClass Web { get { return s_Web; } }
    public static BackOffice.Web.Controllers.AppointmentController Appointment = new BackOffice.Web.Controllers.T4MVC_AppointmentController();
    public static BackOffice.Web.Controllers.BaseController Base = new BackOffice.Web.Controllers.T4MVC_BaseController();
    public static BackOffice.Web.Controllers.HomeController Home = new BackOffice.Web.Controllers.T4MVC_HomeController();
    public static BackOffice.Web.Controllers.InsuranceController Insurance = new BackOffice.Web.Controllers.T4MVC_InsuranceController();
    public static BackOffice.Web.Controllers.PatientController Patient = new BackOffice.Web.Controllers.T4MVC_PatientController();
    public static BackOffice.Web.Controllers.ProfileController Profile = new BackOffice.Web.Controllers.T4MVC_ProfileController();
    public static BackOffice.Web.Controllers.SpecialtyController Specialty = new BackOffice.Web.Controllers.T4MVC_SpecialtyController();
    public static BackOffice.Web.Controllers.TreatmentController Treatment = new BackOffice.Web.Controllers.T4MVC_TreatmentController();
}

namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class MobileClass
    {
        public readonly string Name = "Mobile";
        public BackOffice.Web.Areas.Mobile.Controllers.HomeController Home = new BackOffice.Web.Areas.Mobile.Controllers.T4MVC_HomeController();
        public T4MVC.Mobile.SharedController Shared = new T4MVC.Mobile.SharedController();
    }
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class WebClass
    {
        public readonly string Name = "Web";
        public BackOffice.Web.Areas.Web.Controllers.AppointmentController Appointment = new BackOffice.Web.Areas.Web.Controllers.T4MVC_AppointmentController();
        public BackOffice.Web.Areas.Web.Controllers.HomeController Home = new BackOffice.Web.Areas.Web.Controllers.T4MVC_HomeController();
        public BackOffice.Web.Areas.Web.Controllers.InsuranceController Insurance = new BackOffice.Web.Areas.Web.Controllers.T4MVC_InsuranceController();
        public BackOffice.Web.Areas.Web.Controllers.PatientController Patient = new BackOffice.Web.Areas.Web.Controllers.T4MVC_PatientController();
        public BackOffice.Web.Areas.Web.Controllers.ProfileController Profile = new BackOffice.Web.Areas.Web.Controllers.T4MVC_ProfileController();
        public BackOffice.Web.Areas.Web.Controllers.SpecialtyController Specialty = new BackOffice.Web.Areas.Web.Controllers.T4MVC_SpecialtyController();
        public BackOffice.Web.Areas.Web.Controllers.TreatmentController Treatment = new BackOffice.Web.Areas.Web.Controllers.T4MVC_TreatmentController();
        public T4MVC.Web.AppointmentController Appointment = new T4MVC.Web.AppointmentController();
        public T4MVC.Web.PatientController Patient = new T4MVC.Web.PatientController();
        public T4MVC.Web.SharedController Shared = new T4MVC.Web.SharedController();
    }
}

namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class Dummy
    {
        private Dummy() { }
        public static Dummy Instance = new Dummy();
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ActionResult : System.Web.Mvc.ActionResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ActionResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_PartialViewResult : System.Web.Mvc.PartialViewResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_PartialViewResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}



namespace Links
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static partial class Bundles
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static partial class Scripts {}
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static partial class Styles {}
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal static class T4MVCHelpers {
    // You can change the ProcessVirtualPath method to modify the path that gets returned to the client.
    // e.g. you can prepend a domain, or append a query string:
    //      return "http://localhost" + path + "?foo=bar";
    private static string ProcessVirtualPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and must first be made absolute
        string path = VirtualPathUtility.ToAbsolute(virtualPath);
        
        // Add your own modifications here before returning the path
        return path;
    }

    // Calling ProcessVirtualPath through delegate to allow it to be replaced for unit testing
    public static Func<string, string> ProcessVirtualPath = ProcessVirtualPathDefault;

    // Calling T4Extension.TimestampString through delegate to allow it to be replaced for unit testing and other purposes
    public static Func<string, string> TimestampString = System.Web.Mvc.T4Extensions.TimestampString;

    // Logic to determine if the app is running in production or dev environment
    public static bool IsProduction() { 
        return (HttpContext.Current != null && !HttpContext.Current.IsDebuggingEnabled); 
    }
}





#endregion T4MVC
#pragma warning restore 1591


