using System;
using ApplianceProject.Models;
using ApplianceProject.Services;
using ApplianceProject.Utilities;

namespace ApplianceProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("     Home Appliance Repair Center System (OOP Project)    ");
            Console.WriteLine("==========================================================\n");

            // 1. Static Class Validation Test
            Console.WriteLine("--- [1] Input Validation using Static Class ---");
            string validSN = "REF-2026-99";
            string invalidSN = "123";

            Console.WriteLine($"Validating '{validSN}': {(ValidationHelper.IsValidSerialNumber(validSN) ? "VALID" : "INVALID")}");
            Console.WriteLine($"Validating '{invalidSN}': {(ValidationHelper.IsValidSerialNumber(invalidSN) ? "VALID" : "INVALID")}\n");

            // 2. Initialize Center and Subscribe to Event
            RepairCenter center = new RepairCenter();
            center.OnApplianceStatusChanged += Center_OnApplianceStatusChanged;

            // 3. Register Derived Appliances (Inheritance & Encapsulation)
            Console.WriteLine("--- [2] Registering Appliances in the System ---");
            Appliance fridge = new Refrigerator("REF-1001", "Samsung", 50.0m, hasCompressorIssue: true, gasRefillCost: 40.0m);
            Appliance washer = new WashingMachine("WASH-2002", "LG", 45.0m, motorReplacement: false, capacity: 12);
            Appliance ac = new AirConditioner("AC-3003", "Gree", 60.0m, coolingCapacityBTU: 24000, filtersReplaced: true);

            center.RegisterAppliance(fridge);
            center.RegisterAppliance(washer);
            center.RegisterAppliance(ac);

            // 4. Process all appliances polymorphically
            center.ProcessAllAppliances();

            // 5. Trigger Events by changing status
            Console.WriteLine("--- [3] Maintenance Workflow & Event Triggers ---");
            fridge.PerformMaintenance();
            
            // Completing repairs will raise the event automatically
            center.CompleteRepair("REF-1001");
            center.CompleteRepair("AC-3003");

            // 6. Final Report showing updated counts
            center.ProcessAllAppliances();

            Console.WriteLine("Process finished successfully. Press any key to exit...");
            Console.ReadKey();
        }

        private static void Center_OnApplianceStatusChanged(object sender, ApplianceStatusChangedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n>>> [EVENT TRIGGERED]: {e.Message}");
            Console.WriteLine($"    Serial: {e.TargetAppliance.SerialNumber} | Old Status: {e.OldStatus} -> New Status: {e.NewStatus}\n");
            Console.ResetColor();
        }
    }
}