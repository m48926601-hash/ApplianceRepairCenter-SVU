namespace ApplianceProject.Enums
{
    // تعداد يمثل حالات الجهاز داخل مركز الصيانة
    public enum ApplianceStatus
    {
        Received,      // تم الاستلام
        InProgress,    // قيد الصيانة
        Repaired,      // تم الإصلاح
        Delivered      // تم التسليم للزبون
    }
}