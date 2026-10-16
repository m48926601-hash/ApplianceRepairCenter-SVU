namespace ApplianceProject.Interfaces
{
    // واجهة تحتوي على العمليات الأساسية المشتركة للأجهزة
    public interface IAppliance
    {
        void PerformMaintenance(); // بدء أو تنفيذ الصيانة
        void DisplayDetails();     // عرض تفاصيل الجهاز
    }
}