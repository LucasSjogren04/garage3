using garage3.Interfaces;
using garage3.Vehicles;

namespace garage3
{
    // The only class that talks to the garage. The user interface goes through this class.
    public class GarageHandler : IHandler
    {
        // null until CreateGarage has been called.
        private Garage<IVehicle>? garage;

        public void CreateGarage(int capacity)
        {
            garage = new Garage<IVehicle>(capacity);
        }

        public int GetCapacity()
        {
            return GetGarage().GetCapacity();
        }

        public int CountVehicles()
        {
            return GetGarage().CountVehicles();
        }

        public bool IsFull()
        {
            return GetGarage().IsFull();
        }

        public bool Park(IVehicle vehicle)
        {
            return GetGarage().Park(vehicle);
        }

        public bool Remove(string licensePlateNumber)
        {
            return GetGarage().Remove(licensePlateNumber);
        }

        public IVehicle? FindVehicle(string licensePlateNumber)
        {
            return GetGarage().FindVehicle(licensePlateNumber);
        }

        public List<IVehicle> GetAllVehicles()
        {
            List<IVehicle> result = new List<IVehicle>();
            foreach (IVehicle vehicle in GetGarage())
            {
                result.Add(vehicle);
            }
            return result;
        }

        public int CountType(string typeName)
        {
            int count = 0;
            foreach (IVehicle vehicle in GetGarage())
            {
                if (vehicle.GetTypeName() == typeName)
                {
                    count++;
                }
            }
            return count;
        }

        //empty "" = anything
        //-1 wheels = any number of wheels
        public List<IVehicle> Search(string type, string color, int numberOfWheels)
        {
            List<IVehicle> result = new List<IVehicle>();
            foreach (IVehicle vehicle in GetGarage())
            {
                if (Matches(vehicle, type, color, numberOfWheels))
                {
                    result.Add(vehicle);
                }
            }
            return result;
        }

        // Returns how many of the sample vehicles were parked.
        public int AddSampleVehicles()
        {
            List<IVehicle> samples = new List<IVehicle>
            {
                new Car("ABC123", "Red", 4, "Gasoline"),
                new Car("RED456", "Red", 6, "Gasoline"),
                new Motorcycle("MCK11A", "Pink", 2, 600),
                new Motorcycle("BRM222", "Orange", 2, 1000),
                new Bus("BUS333", "Yellow", 6, 52),
                new Airplane("FLY44B", "White", 3, 2),
                new Boat("SEA555", "Blue", 0, 8),
            };

            int added = 0;
            foreach (IVehicle vehicle in samples)
            {
                //park returns false when the garage is full or same plate is there
                if (GetGarage().Park(vehicle))
                {
                    added++;
                }
            }
            return added;
        }

        private bool Matches(IVehicle vehicle, string type, string color, int numberOfWheels)
        {
            if (type != "" && vehicle.GetTypeName().ToLower() != type.ToLower())
            {
                return false;
            }
            if (color != "" && vehicle.Color.ToLower() != color.ToLower())
            {
                return false;
            }
            if (numberOfWheels != -1 && vehicle.NumberOfWheels != numberOfWheels)
            {
                return false;
            }
            return true;
        }

        private Garage<IVehicle> GetGarage()
        {
            if (garage == null)
            {
                throw new InvalidOperationException("No garage has been created yet.");
            }
            return garage;
        }
    }
}
