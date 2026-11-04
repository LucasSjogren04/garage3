using System;
using System.Collections.Generic;
using System.Text;

namespace garage3.Vehicles
{
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(string licensePlateNumber, string color, int numberOfWheels, int numberOfSeats)
            : base(licensePlateNumber, color, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Seats: {NumberOfSeats}";
        }
    }
}
