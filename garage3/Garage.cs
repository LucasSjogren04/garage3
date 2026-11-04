using System.Collections;
using garage3.Interfaces;

namespace garage3
{
    // T can only be a class that implements IVehicle. Garage<IVehicle> , Garage<Car>.
    public class Garage<T> : IEnumerable<T> where T : class, IVehicle
    {
        private List<T> vehicles;

        private int capacity;

        public Garage(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be at least 1.");
            }

            this.capacity = capacity;
            vehicles = new List<T>();
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public int CountVehicles()
        {
            return vehicles.Count;
        }

        public bool IsFull()
        {
            return vehicles.Count >= capacity;
        }

        // Returns false if the garage is full or the plate is already parked here.
        public bool Park(T vehicle)
        {
            if (IsFull())
            {
                return false;
            }
            if (FindVehicle(vehicle.LicensePlateNumber) != null)
            {
                return false;
            }

            vehicles.Add(vehicle);
            return true;
        }

        public bool Remove(string licensePlateNumber)
        {
            T? vehicle = FindVehicle(licensePlateNumber);
            if (vehicle == null)
            {
                return false;
            }

            vehicles.Remove(vehicle);
            return true;
        }

        // Returns the vehicle, or null if it isn't parked here.
        public T? FindVehicle(string licensePlateNumber)
        {
            foreach (T vehicle in vehicles)
            {
                if (vehicle.LicensePlateNumber == licensePlateNumber.ToUpper())
                {
                    return vehicle;
                }
            }
            return null;
        }

        // Makes it possible to use foreach on a garage.
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T vehicle in vehicles)
            {
                yield return vehicle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
