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
namespace BackOffice.Web.Areas.Web.Controllers
{
    public partial class PatientController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public PatientController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected PatientController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult Search()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Search);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult PatientUpsert()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PatientUpsert);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult AppointmentList()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AppointmentList);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult PatientDelete()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PatientDelete);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult PatientNotes()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PatientNotes);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult PatientNotesUpsert()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PatientNotesUpsert);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public PatientController Actions { get { return MVC.Web.Patient; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Web";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Patient";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Patient";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Search = "Search";
            public readonly string PatientUpsert = "PatientUpsert";
            public readonly string AppointmentList = "AppointmentList";
            public readonly string PatientDelete = "PatientDelete";
            public readonly string PatientNotes = "PatientNotes";
            public readonly string PatientNotesUpsert = "PatientNotesUpsert";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Search = "Search";
            public const string PatientUpsert = "PatientUpsert";
            public const string AppointmentList = "AppointmentList";
            public const string PatientDelete = "PatientDelete";
            public const string PatientNotes = "PatientNotes";
            public const string PatientNotesUpsert = "PatientNotesUpsert";
        }


        static readonly ActionParamsClass_Search s_params_Search = new ActionParamsClass_Search();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Search SearchParams { get { return s_params_Search; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Search
        {
            public readonly string SearchParam = "SearchParam";
        }
        static readonly ActionParamsClass_PatientUpsert s_params_PatientUpsert = new ActionParamsClass_PatientUpsert();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_PatientUpsert PatientUpsertParams { get { return s_params_PatientUpsert; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_PatientUpsert
        {
            public readonly string PatientPublicId = "PatientPublicId";
        }
        static readonly ActionParamsClass_AppointmentList s_params_AppointmentList = new ActionParamsClass_AppointmentList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AppointmentList AppointmentListParams { get { return s_params_AppointmentList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AppointmentList
        {
            public readonly string PatientPublicId = "PatientPublicId";
        }
        static readonly ActionParamsClass_PatientDelete s_params_PatientDelete = new ActionParamsClass_PatientDelete();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_PatientDelete PatientDeleteParams { get { return s_params_PatientDelete; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_PatientDelete
        {
            public readonly string PatientPublicId = "PatientPublicId";
        }
        static readonly ActionParamsClass_PatientNotes s_params_PatientNotes = new ActionParamsClass_PatientNotes();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_PatientNotes PatientNotesParams { get { return s_params_PatientNotes; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_PatientNotes
        {
            public readonly string PatientPublicId = "PatientPublicId";
        }
        static readonly ActionParamsClass_PatientNotesUpsert s_params_PatientNotesUpsert = new ActionParamsClass_PatientNotesUpsert();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_PatientNotesUpsert PatientNotesUpsertParams { get { return s_params_PatientNotesUpsert; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_PatientNotesUpsert
        {
            public readonly string PatientPublicId = "PatientPublicId";
            public readonly string Name = "Name";
            public readonly string LastName = "LastName";
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
                public readonly string AppointmentList = "AppointmentList";
                public readonly string PatientNotes = "PatientNotes";
                public readonly string PatientUpsert = "PatientUpsert";
                public readonly string Search = "Search";
            }
            public readonly string AppointmentList = "~/Areas/Web/Views/Patient/AppointmentList.cshtml";
            public readonly string PatientNotes = "~/Areas/Web/Views/Patient/PatientNotes.cshtml";
            public readonly string PatientUpsert = "~/Areas/Web/Views/Patient/PatientUpsert.cshtml";
            public readonly string Search = "~/Areas/Web/Views/Patient/Search.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_PatientController : BackOffice.Web.Areas.Web.Controllers.PatientController
    {
        public T4MVC_PatientController() : base(Dummy.Instance) { }

        [NonAction]
        partial void SearchOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string SearchParam);

        [NonAction]
        public override System.Web.Mvc.ActionResult Search(string SearchParam)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Search);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "SearchParam", SearchParam);
            SearchOverride(callInfo, SearchParam);
            return callInfo;
        }

        [NonAction]
        partial void PatientUpsertOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string PatientPublicId);

        [NonAction]
        public override System.Web.Mvc.ActionResult PatientUpsert(string PatientPublicId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PatientUpsert);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "PatientPublicId", PatientPublicId);
            PatientUpsertOverride(callInfo, PatientPublicId);
            return callInfo;
        }

        [NonAction]
        partial void AppointmentListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string PatientPublicId);

        [NonAction]
        public override System.Web.Mvc.ActionResult AppointmentList(string PatientPublicId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AppointmentList);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "PatientPublicId", PatientPublicId);
            AppointmentListOverride(callInfo, PatientPublicId);
            return callInfo;
        }

        [NonAction]
        partial void PatientDeleteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string PatientPublicId);

        [NonAction]
        public override System.Web.Mvc.ActionResult PatientDelete(string PatientPublicId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PatientDelete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "PatientPublicId", PatientPublicId);
            PatientDeleteOverride(callInfo, PatientPublicId);
            return callInfo;
        }

        [NonAction]
        partial void PatientNotesOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string PatientPublicId);

        [NonAction]
        public override System.Web.Mvc.ActionResult PatientNotes(string PatientPublicId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PatientNotes);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "PatientPublicId", PatientPublicId);
            PatientNotesOverride(callInfo, PatientPublicId);
            return callInfo;
        }

        [NonAction]
        partial void PatientNotesUpsertOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string PatientPublicId, string Name, string LastName);

        [NonAction]
        public override System.Web.Mvc.ActionResult PatientNotesUpsert(string PatientPublicId, string Name, string LastName)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PatientNotesUpsert);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "PatientPublicId", PatientPublicId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "Name", Name);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "LastName", LastName);
            PatientNotesUpsertOverride(callInfo, PatientPublicId, Name, LastName);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
