﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Web.Controllers
{
    public partial class ProfileController : BaseController
    {
        public virtual ActionResult Index(string ProfilePublicId)
        {
            


            return View();
        }
    }
}