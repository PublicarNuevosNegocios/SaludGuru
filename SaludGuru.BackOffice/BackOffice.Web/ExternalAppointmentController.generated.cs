// <auto-generated />
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
namespace BackOffice.Web.Controllers
{
    public partial class ExternalAppointmentController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ExternalAppointmentController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ExternalAppointmentController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Index()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Confirm()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Confirm);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Cancel()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Cancel);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ExternalAppointmentController Actions { get { return MVC.ExternalAppointment; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "ExternalAppointment";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "ExternalAppointment";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Confirm = "Confirm";
            public readonly string Cancel = "Cancel";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Confirm = "Confirm";
            public const string Cancel = "Cancel";
        }


        static readonly ActionParamsClass_Index s_params_Index = new ActionParamsClass_Index();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Index IndexParams { get { return s_params_Index; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Index
        {
            public readonly string AppointmentPublicId = "AppointmentPublicId";
        }
        static readonly ActionParamsClass_Confirm s_params_Confirm = new ActionParamsClass_Confirm();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Confirm ConfirmParams { get { return s_params_Confirm; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Confirm
        {
            public readonly string AppointmentPublicId = "AppointmentPublicId";
        }
        static readonly ActionParamsClass_Cancel s_params_Cancel = new ActionParamsClass_Cancel();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Cancel CancelParams { get { return s_params_Cancel; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Cancel
        {
            public readonly string AppointmentPublicId = "AppointmentPublicId";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_ExternalAppointmentController : BackOffice.Web.Controllers.ExternalAppointmentController
    {
        public T4MVC_ExternalAppointmentController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string AppointmentPublicId);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index(string AppointmentPublicId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "AppointmentPublicId", AppointmentPublicId);
            IndexOverride(callInfo, AppointmentPublicId);
            return callInfo;
        }

        [NonAction]
        partial void ConfirmOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string AppointmentPublicId);

        [NonAction]
        public override System.Web.Mvc.ActionResult Confirm(string AppointmentPublicId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Confirm);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "AppointmentPublicId", AppointmentPublicId);
            ConfirmOverride(callInfo, AppointmentPublicId);
            return callInfo;
        }

        [NonAction]
        partial void CancelOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string AppointmentPublicId);

        [NonAction]
        public override System.Web.Mvc.ActionResult Cancel(string AppointmentPublicId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Cancel);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "AppointmentPublicId", AppointmentPublicId);
            CancelOverride(callInfo, AppointmentPublicId);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591