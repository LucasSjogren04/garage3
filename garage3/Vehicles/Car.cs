using System;
using System.Collections.Generic;
using System.Text;

namespace garage3.Vehicles
{
    public class Car : Vehicle
    {
        public string FuelType { get; set; }

        public Car(string licensePlateNumber, string color, int numberOfWheels, string fuelType)
            : base(licensePlateNumber, color, numberOfWheels)
        {
            FuelType = fuelType;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Fuel: {FuelType}";
        }
    }
}
