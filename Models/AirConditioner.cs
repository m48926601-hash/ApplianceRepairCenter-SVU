using System;

namespace ApplianceProject.Models
{
    public class AirConditioner : Appliance
    {
        public int CoolingCapacityBTU { get; set; }
        public bool FiltersReplaced { get; set; }

        public AirConditioner(string serialNumber, string brand, decimal baseRepairFee, int coolingCapacityBTU, bool filtersReplaced)
            : base(serialNumber, brand, baseRepairFee)
        {
            CoolingCapacityBTU = coolingCapacityBTU;
            FiltersReplaced = filtersReplaced;
        }

        public override decimal CalculateRepairCost()
        {
            decimal total = BaseRepairFee;
            if (FiltersReplaced)
            {
                total += 35.0m;
            }
            if (CoolingCapacityBTU >= 24000)
            {
                total += 80.0m;
            }
            return total;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"   -> [AC Details] Capacity: {CoolingCapacityBTU} BTU | New Filters: {(FiltersReplaced ? "Yes" : "No")}");
        }
    }
}