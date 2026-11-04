using System;
using System.Collections.Generic;
using System.Text;

namespace garage3.Vehicles
{
    public class Boat : Vehicle
    {
        public int Length { get; set; }

        public Boat(string licensePlateNumber, string color, int numberOfWheels, int length)
            : base(licensePlateNumber, color, numberOfWheels)
        {
            Length = length;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Length: {Length} m";
        }
    }

}
