using System;
using System.Collections.Generic;
using System.Text;

namespace garage3.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; set; }

        public Motorcycle(string licensePlateNumber, string color, int numberOfWheels, int cylinderVolume)
            : base(licensePlateNumber, color, numberOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Cylinder volume: {CylinderVolume} cc";
        }
    }
}
