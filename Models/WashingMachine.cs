using System;

namespace ApplianceProject.Models
{
    public class WashingMachine : Appliance
    {
        public bool MotorReplacementRequired { get; set; }
        public int CapacityInKg { get; set; }

        public WashingMachine(string serialNumber, string brand, decimal baseRepairFee, bool motorReplacement, int capacity)
            : base(serialNumber, brand, baseRepairFee)
        {
            MotorReplacementRequired = motorReplacement;
            CapacityInKg = capacity > 0 ? capacity : 7;
        }

        public override decimal CalculateRepairCost()
        {
            decimal total = BaseRepairFee;
            if (MotorReplacementRequired)
            {
                total += 200.0m;
            }
            if (CapacityInKg > 10)
            {
                total += 50.0m;
            }
            return total;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"   -> [Washer Details] Motor Replacement: {(MotorReplacementRequired ? "Yes" : "No")} | Capacity: {CapacityInKg} KG");
        }
    }
}