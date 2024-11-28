using System;

namespace ConsoleApp3
{
    public class Car : CarSample, IComparable
    {

        public Car()
        { }

        public Car(string modelName, string manufacturer, int yearOfProduction,
            double engineCapacity, int seatCount, bool isElectric, double averageFuelConsumption)
        {
            ModelName = modelName;
            Manufacturer = manufacturer;
            YearOfProduction = yearOfProduction;
            EngineCapacity = engineCapacity;
            SeatCount = seatCount;
            IsElectric = isElectric;
            AverageFuelConsumption = averageFuelConsumption;
        }

        public double GetFuelConsumptionPer100Km()
        {
            return AverageFuelConsumption;
        }

        public override int GetCarAge()
        {
            return DateTime.Now.Year - YearOfProduction;
        }

        public int CompareTo(object obj)
        {
            Car car = obj as Car;
            return string.Compare(this.ModelName, car.ModelName);
        }

        public string Info()
        {
            return ModelName + ", " + Manufacturer;
        }
    }
}
