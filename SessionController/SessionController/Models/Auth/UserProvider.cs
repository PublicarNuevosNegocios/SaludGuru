﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionController.Models.Auth
{
    public class UserProvider
    {
        public string ProviderId { get; set; }
        public enumLoginType? LoginType { get; set; }
        public DateTime CreateDate { get; set; }
    }
}