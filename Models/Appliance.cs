using System;
using ApplianceProject.Enums;
using ApplianceProject.Interfaces;

namespace ApplianceProject.Models
{
    public abstract class Appliance : IAppliance
    {
        private readonly string _serialNumber;
        private string _brand;
        private decimal _baseRepairFee;
        private ApplianceStatus _status;

        public string SerialNumber => _serialNumber;

        public string Brand
        {
            get => _brand;
            set => _brand = string.IsNullOrWhiteSpace(value) ? "Unknown" : value;
        }

        public decimal BaseRepairFee
        {
            get => _baseRepairFee;
            set => _baseRepairFee = value >= 0 ? value : 0;
        }

        public ApplianceStatus Status => _status;

        protected Appliance(string serialNumber, string brand, decimal baseRepairFee)
        {
            _serialNumber = serialNumber;
            _brand = brand;
            BaseRepairFee = baseRepairFee;
            _status = ApplianceStatus.Received;
        }

        public abstract decimal CalculateRepairCost();

        public virtual void PerformMaintenance()
        {
            _status = ApplianceStatus.InProgress;
            Console.WriteLine($"[MAINTENANCE] Device '{_serialNumber}' is now IN-PROGRESS.");
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Device: {Brand,-12} | Serial: {SerialNumber,-10} | Status: {Status,-10} | Est. Cost: {CalculateRepairCost():C}");
        }

        public void UpdateStatus(ApplianceStatus newStatus)
        {
            _status = newStatus;
        }
    }
}