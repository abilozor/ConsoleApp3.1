using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp3
{
    internal class Program
    {
        static List<CarSample> carSamples;
        static void Main(string[] args)
        {
            carSamples = new List<CarSample>();
            FileStream fs = new FileStream("Cars.cars", FileMode.Open);
            BinaryReader reader = new BinaryReader(fs);

            try
            {
                CarSample car;
                Console.WriteLine("\tЧИТАЄМО ДАНІ З ФАЙЛУ...\n");
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    car = new Car();
                    for (int i = 1; i <= 7; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                car.ModelName = reader.ReadString();
                                break;
                            case 2:
                                car.Manufacturer = reader.ReadString();
                                break;
                            case 3:
                                car.YearOfProduction = reader.ReadInt32();
                                break;
                            case 4:
                                car.EngineCapacity = reader.ReadDouble();
                                break;
                            case 5:
                                car.SeatCount = reader.ReadInt32();
                                break;
                            case 6:
                                car.IsElectric = reader.ReadBoolean();
                                break;
                            case 7:
                                car.AverageFuelConsumption = reader.ReadDouble();
                                break;
                        }
                    }
                    carSamples.Add(car);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: {0}", ex.Message);
            }
            finally
            {
                reader.Close();
            }

            Console.WriteLine("Несортований перелік автомобілів: {0}", carSamples.Count);
            PrintCars();

            carSamples.Sort(); 
            Console.WriteLine("\nСортований перелік автомобілів за моделлю: {0}", carSamples.Count);
            PrintCars();

            Console.WriteLine("\nДодаємо новий запис: Toyota Camry Toyota");
            carSamples.Add(new Car("Toyota Camry", "Toyota", 2022, 2, 5, false, 9));

            Console.WriteLine("\nПерелік автомобілів: {0}", carSamples.Count);
            PrintCars();

            Console.WriteLine("\nВидаляємо останнє значення");
            carSamples.RemoveAt(carSamples.Count - 1);

            Console.WriteLine("\nПерелік автомобілів: {0}", carSamples.Count);
            PrintCars();

            while(true) Console.ReadKey();
        }

        static void PrintCars()
        {
            foreach(Car car in carSamples) 
            {
                Console.WriteLine(car.Info().Replace('і', 'i'));
            }
            Console.WriteLine();
        }
    }
}
