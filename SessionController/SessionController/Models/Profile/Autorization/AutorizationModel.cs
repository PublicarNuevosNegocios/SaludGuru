﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionController.Models.Profile.Autorization
{
    public class AutorizationModel
    {
        public string UserEmail { get; set; }

        public enumRole? Role { get; set; }

        public bool Selected { get; set; }

        public List<SessionController.Models.Profile.Profile.ProfileModel> RelatedProfile { get; set; }

    }
}
