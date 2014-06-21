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
    public partial class ProfileController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ProfileController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ProfileController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult EditProfile()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditProfile);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult EditImageProfile()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditImageProfile);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult UpsertOffice()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UpsertOffice);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Specialty()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Specialty);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Insurance()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Insurance);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ProfileController Actions { get { return MVC.Web.Profile; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Web";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Profile";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Profile";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Search = "Search";
            public readonly string Create = "Create";
            public readonly string EditProfile = "EditProfile";
            public readonly string EditImageProfile = "EditImageProfile";
            public readonly string UpsertOffice = "UpsertOffice";
            public readonly string Specialty = "Specialty";
            public readonly string Insurance = "Insurance";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Search = "Search";
            public const string Create = "Create";
            public const string EditProfile = "EditProfile";
            public const string EditImageProfile = "EditImageProfile";
            public const string UpsertOffice = "UpsertOffice";
            public const string Specialty = "Specialty";
            public const string Insurance = "Insurance";
        }


        static readonly ActionParamsClass_EditProfile s_params_EditProfile = new ActionParamsClass_EditProfile();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditProfile EditProfileParams { get { return s_params_EditProfile; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditProfile
        {
            public readonly string ProfilePublicId = "ProfilePublicId";
        }
        static readonly ActionParamsClass_EditImageProfile s_params_EditImageProfile = new ActionParamsClass_EditImageProfile();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditImageProfile EditImageProfileParams { get { return s_params_EditImageProfile; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditImageProfile
        {
            public readonly string ProfilePublicId = "ProfilePublicId";
        }
        static readonly ActionParamsClass_UpsertOffice s_params_UpsertOffice = new ActionParamsClass_UpsertOffice();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UpsertOffice UpsertOfficeParams { get { return s_params_UpsertOffice; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UpsertOffice
        {
            public readonly string ProfilePublicId = "ProfilePublicId";
            public readonly string OfficePublicId = "OfficePublicId";
        }
        static readonly ActionParamsClass_Specialty s_params_Specialty = new ActionParamsClass_Specialty();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Specialty SpecialtyParams { get { return s_params_Specialty; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Specialty
        {
            public readonly string ProfilePublicId = "ProfilePublicId";
        }
        static readonly ActionParamsClass_Insurance s_params_Insurance = new ActionParamsClass_Insurance();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Insurance InsuranceParams { get { return s_params_Insurance; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Insurance
        {
            public readonly string ProfilePublicId = "ProfilePublicId";
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
                public readonly string Create = "Create";
                public readonly string EditImageProfile = "EditImageProfile";
                public readonly string EditProfile = "EditProfile";
                public readonly string Insurance = "Insurance";
                public readonly string Search = "Search";
                public readonly string Specialty = "Specialty";
                public readonly string UpsertOffice = "UpsertOffice";
            }
            public readonly string Create = "~/Areas/Web/Views/Profile/Create.cshtml";
            public readonly string EditImageProfile = "~/Areas/Web/Views/Profile/EditImageProfile.cshtml";
            public readonly string EditProfile = "~/Areas/Web/Views/Profile/EditProfile.cshtml";
            public readonly string Insurance = "~/Areas/Web/Views/Profile/Insurance.cshtml";
            public readonly string Search = "~/Areas/Web/Views/Profile/Search.cshtml";
            public readonly string Specialty = "~/Areas/Web/Views/Profile/Specialty.cshtml";
            public readonly string UpsertOffice = "~/Areas/Web/Views/Profile/UpsertOffice.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_ProfileController : BackOffice.Web.Areas.Web.Controllers.ProfileController
    {
        public T4MVC_ProfileController() : base(Dummy.Instance) { }

        [NonAction]
        partial void SearchOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Search()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Search);
            SearchOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            CreateOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void EditProfileOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string ProfilePublicId);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditProfile(string ProfilePublicId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditProfile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "ProfilePublicId", ProfilePublicId);
            EditProfileOverride(callInfo, ProfilePublicId);
            return callInfo;
        }

        [NonAction]
        partial void EditImageProfileOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string ProfilePublicId);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditImageProfile(string ProfilePublicId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditImageProfile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "ProfilePublicId", ProfilePublicId);
            EditImageProfileOverride(callInfo, ProfilePublicId);
            return callInfo;
        }

        [NonAction]
        partial void UpsertOfficeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string ProfilePublicId, string OfficePublicId);

        [NonAction]
        public override System.Web.Mvc.ActionResult UpsertOffice(string ProfilePublicId, string OfficePublicId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UpsertOffice);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "ProfilePublicId", ProfilePublicId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "OfficePublicId", OfficePublicId);
            UpsertOfficeOverride(callInfo, ProfilePublicId, OfficePublicId);
            return callInfo;
        }

        [NonAction]
        partial void SpecialtyOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string ProfilePublicId);

        [NonAction]
        public override System.Web.Mvc.ActionResult Specialty(string ProfilePublicId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Specialty);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "ProfilePublicId", ProfilePublicId);
            SpecialtyOverride(callInfo, ProfilePublicId);
            return callInfo;
        }

        [NonAction]
        partial void InsuranceOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string ProfilePublicId);

        [NonAction]
        public override System.Web.Mvc.ActionResult Insurance(string ProfilePublicId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Insurance);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "ProfilePublicId", ProfilePublicId);
            InsuranceOverride(callInfo, ProfilePublicId);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
