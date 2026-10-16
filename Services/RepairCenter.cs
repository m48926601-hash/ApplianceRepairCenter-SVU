using System;
using System.Collections.Generic;
using ApplianceProject.Enums;
using ApplianceProject.Models;

namespace ApplianceProject.Services
{
    // فئة إدارة مركز الصيانة
    public class RepairCenter
    {
        // 1. قائمة متعددة الأشكال تحتوي على الفئات المشتقة
        private readonly List<Appliance> _appliances = new List<Appliance>();

        // 2. تعريف الحدث (Event) بناءً على الـ Delegate
        public event ApplianceStatusChangedHandler OnApplianceStatusChanged;

        // 3. خاصية ثابتة لمتابعة إجمالي الأجهزة التي تم إصلاحها بالكامل عبر المركز
        public static int TotalRepairedCount { get; private set; } = 0;

        // تسجيل جهاز جديد في المركز
        public void RegisterAppliance(Appliance appliance)
        {
            if (appliance == null)
            {
                Console.WriteLine("[ERROR] Cannot register a null appliance.");
                return;
            }

            _appliances.Add(appliance);
            Console.WriteLine($"[REGISTERED] Device '{appliance.SerialNumber}' ({appliance.Brand}) added successfully.");
        }

        // إكمال صيانة جهاز وإطلاق الحدث
        public void CompleteRepair(string serialNumber)
        {
            var appliance = _appliances.Find(a => a.SerialNumber.Equals(serialNumber, StringComparison.OrdinalIgnoreCase));

            if (appliance != null)
            {
                if (appliance.Status == ApplianceStatus.Repaired)
                {
                    Console.WriteLine($"[INFO] Device '{serialNumber}' is already marked as Repaired.");
                    return;
                }

                var oldStatus = appliance.Status;

                // تحديث الحالة
                appliance.UpdateStatus(ApplianceStatus.Repaired);
                TotalRepairedCount++;

                // إطلاق الحدث (Trigger Event)
                OnApplianceStatusChanged?.Invoke(this, new ApplianceStatusChangedEventArgs(
                    appliance,
                    oldStatus,
                    ApplianceStatus.Repaired,
                    $"Repair work finished for {appliance.Brand} ({appliance.SerialNumber}). It is now ready for customer pickup!"
                ));
            }
            else
            {
                Console.WriteLine($"[WARNING] Appliance with Serial '{serialNumber}' was not found.");
            }
        }

        // استخدام تعدد الأشكال (Polymorphism) لمعالجة وحساب تكاليف كافة الأجهزة
        public void ProcessAllAppliances()
        {
            Console.WriteLine("\n================ Current Appliances Report (Polymorphism) ================");
            decimal totalRevenue = 0;

            foreach (var item in _appliances)
            {
                // استدعاء متعدد الأشكال لدالة العرض
                item.DisplayDetails();

                // استدعاء متعدد الأشكال لحساب التكلفة الخاصة بكل جهاز
                decimal cost = item.CalculateRepairCost();
                totalRevenue += cost;
            }

            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine($"Total Estimated Revenue: {totalRevenue:C}");
            Console.WriteLine($"Total Completed Repairs: {TotalRepairedCount}");
            Console.WriteLine("=========================================================================\n");
        }
    }
}