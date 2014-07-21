﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SaludGuru.Notifications.Models;

namespace SaludGuru.Notification.Test
{
    [TestClass]
    public class NotificationTest
    {
        [TestMethod]
        public void NotificationCreateTest()
        {
            //int oProfile = SaludGuru.Notifications.Controller.Notification.NotificationCreate("12345678", "", , "Test", "Método de prueba");
            //Assert.AreEqual(oProfile > 0, true);
        }

        [TestMethod]
        public void NotificationGetByUserNameAndStatusTest()
        {
            List<SaludGuru.Notifications.Models.NotificationModel> models = new List<Notifications.Models.NotificationModel>();
            models = SaludGuru.Notifications.Controller.Notification.Notifiation_GetByUserAndStatus("17B1EF7E", enumNotificationStatus.No_Leida);
            Assert.AreEqual(models.Count > 0, true);
        }
    }
}
