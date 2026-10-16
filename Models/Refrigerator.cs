using System;

namespace ApplianceProject.Models
{
    public class Refrigerator : Appliance
    {
        public bool HasCompressorIssue { get; set; }
        public decimal GasRefillCost { get; set; }

        public Refrigerator(string serialNumber, string brand, decimal baseRepairFee, bool hasCompressorIssue, decimal gasRefillCost)
            : base(serialNumber, brand, baseRepairFee)
        {
            HasCompressorIssue = hasCompressorIssue;
            GasRefillCost = gasRefillCost >= 0 ? gasRefillCost : 0;
        }

        public override decimal CalculateRepairCost()
        {
            decimal total = BaseRepairFee + GasRefillCost;
            if (HasCompressorIssue)
            {
                total += 150.0m;
            }
            return total;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"   -> [Refrigerator Details] Compressor Issue: {(HasCompressorIssue ? "Yes" : "No")} | Gas Cost: {GasRefillCost:C}");
        }
    }
}