using System;
using System.Text.RegularExpressions;

namespace ApplianceProject.Utilities
{
    // فئة ثابتة تحتوي على دوال مساعدة للتحقق من صحة المدخلات
    public static class ValidationHelper
    {
        // دالة ثابتة للتحقق من صحة الرقم التسلسلي (مثال: يجب أن يبدأ بحرفين ويليه 4 أرقام على الأقل)
        public static bool IsValidSerialNumber(string serialNumber)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
                return false;

            // يشترط أن يكون الرقم التسلسلي بطول لا يقل عن 5 خانات ويحتوي أحرف وأرقام
            return Regex.IsMatch(serialNumber, @"^[A-Z0-9-]{5,15}$", RegexOptions.IgnoreCase);
        }

        // دالة ثابتة للتحقق من صحة تاريخ استلام الجهاز (لا يمكن أن يكون في المستقبل)
        public static bool IsValidDate(DateTime date)
        {
            return date <= DateTime.Now;
        }

        // دالة للتحقق من القيم المالية ألا تكون سالبة
        public static bool IsPositiveAmount(decimal amount)
        {
            return amount >= 0;
        }
    }
}