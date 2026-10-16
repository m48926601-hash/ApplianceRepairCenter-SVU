using System;
using ApplianceProject.Enums;
using ApplianceProject.Models;

namespace ApplianceProject.Services
{
    // تعريف التفويض (Delegate) الخاص بالإشعار بتغير الحالة
    public delegate void ApplianceStatusChangedHandler(object sender, ApplianceStatusChangedEventArgs e);

    // كلاس لتمرير بيانات الحدث
    public class ApplianceStatusChangedEventArgs : EventArgs
    {
        public Appliance TargetAppliance { get; }
        public ApplianceStatus OldStatus { get; }
        public ApplianceStatus NewStatus { get; }
        public string Message { get; }

        public ApplianceStatusChangedEventArgs(Appliance appliance, ApplianceStatus oldStatus, ApplianceStatus newStatus, string message)
        {
            TargetAppliance = appliance;
            OldStatus = oldStatus;
            NewStatus = newStatus;
            Message = message;
        }
    }
}