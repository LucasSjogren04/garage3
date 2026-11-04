using System;
using System.Collections.Generic;
using System.Text;

namespace garage3.Vehicles
{
    public class Airplane : Vehicle
    {
        public int NumberOfEngines { get; set; }

        public Airplane(string licensePlateNumber, string color, int numberOfWheels, int numberOfEngines)
            : base(licensePlateNumber, color, numberOfWheels)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Engines: {NumberOfEngines}";
        }
    }

}
