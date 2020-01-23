using System;
using System.Collections.Generic;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var superCarBuilder = new SuperCarBuilder();
            var notSoSuperCarBuilderButOk = new NotSoSuperCarBuilderButOk();

            var factory = new CarFactory();
            var builders = new List<CarBuilder>
            {
                superCarBuilder,
                notSoSuperCarBuilderButOk
            };

            foreach (var builder in builders)
            {
                var car = factory.Build(builder);

                Console.WriteLine($"Samochód zamówiony przez " +
                    $"'{builder.GetType().Name}': " +
                    $"\n ------------------------------------" +
                    $"\n Konie mechaniczne: {car.HorsePower}" +
                    $"\n Najbardziej ceniony za: {car.MostImpressiveFeature}" +
                    $"\n Maksymalna prędkość: {car.TopSpeed} km/s \n");

                Console.ReadKey();
            }
        }
    }

    /// <summary>
    /// PRODUKT
    /// </summary>
    public class Car
    {
        public int TopSpeed { get; set; }
        public int HorsePower { get; set; }
        public string MostImpressiveFeature { get; set; }
    }

    /// <summary>
    /// BUILDER ABSTRAKCYJNY
    /// </summary>
    public abstract class CarBuilder
    {
        protected readonly Car _car = new Car();
        public abstract void SetHorsePower();
        public abstract void SetTopSpeed();
        public abstract void SetImpressiveFeature();

        public virtual Car GetCar()
        {
            return _car;
        }
    }

    /// <summary>
    /// DYREKTOR
    /// </summary>
    public class CarFactory
    {
        public Car Build(CarBuilder builder)
        {
            builder.SetHorsePower();
            builder.SetTopSpeed();
            builder.SetImpressiveFeature();
            return builder.GetCar();
        }
    }

    /// <summary>
    /// KONKRETNY BUILDER 1
    /// </summary>
    public class NotSoSuperCarBuilderButOk : CarBuilder
    {
        public override void SetHorsePower()
        {
            _car.HorsePower = 150;
        }
        public override void SetTopSpeed()
        {
            _car.TopSpeed = 1;
        }
        public override void SetImpressiveFeature()
        {
            _car.MostImpressiveFeature = "klimatyzacja automatyczna dwustrefowa";
        }
    }

    /// <summary>
    /// KONKRETNY BUILDER 2
    /// </summary>
    public class SuperCarBuilder : CarBuilder
    {

        public override void SetHorsePower()
        {
            _car.HorsePower = 1500;
        }

        public override void SetTopSpeed()
        {
            _car.TopSpeed = 100;
        }
        public override void SetImpressiveFeature()
        {
            _car.MostImpressiveFeature = "może latać";
        }
    }
}
