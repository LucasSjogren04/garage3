using System;
using System.Collections.Generic;
using System.Text;
using garage3.Interfaces;

namespace garage3.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        public string LicensePlateNumber { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }

        public Vehicle(string licensePlateNumber, string color, int numberOfWheels)
        {
            // Standardize license plate so everyhng is uppercase
            LicensePlateNumber = licensePlateNumber.ToUpper();
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        // Returns the name of the class, for example "Car" or "Boat".
        public string GetTypeName()
        {
            return GetType().Name;
        }

        public override string ToString()
        {
            return $"{GetTypeName()}, Reg: {LicensePlateNumber}, Color: {Color}, Wheels: {NumberOfWheels}";
        }

        public static bool IsValidLicensePlate(string plate)
        {
            plate = plate.ToUpper();

            if (plate.Length != 6)
            {
                return false;
            }

            for (int i = 0; i < 3; i++)
            {
                if (!IsLetter(plate[i]))
                {
                    return false;
                }
            }

            if (!IsDigit(plate[3]) || !IsDigit(plate[4]))
            {
                return false;
            }

            if (!IsDigit(plate[5]) && !IsLetter(plate[5]))
            {
                return false;
            }

            return true;
        }

        private static bool IsLetter(char c)
        {
            return c >= 'A' && c <= 'Z';
        }

        private static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }
    }
}
