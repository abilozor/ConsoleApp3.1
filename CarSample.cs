using System;

namespace ConsoleApp3
{
    public abstract class CarSample
    {
        public string ModelName { get; set; }
        public string Manufacturer { get; set; }
        public int YearOfProduction { get; set; }
        public double EngineCapacity { get; set; }
        public int SeatCount { get; set; }
        public bool IsElectric { get; set; }
        public double AverageFuelConsumption { get; set; }

        public abstract int GetCarAge();
    }
}
