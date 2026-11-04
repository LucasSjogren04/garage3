namespace garage3.Interfaces
{
    public interface IHandler
    {
        void CreateGarage(int capacity);
        int GetCapacity();
        int CountVehicles();
        bool IsFull();
        bool Park(IVehicle vehicle);
        bool Remove(string licensePlateNumber);
        IVehicle? FindVehicle(string licensePlateNumber);
        List<IVehicle> GetAllVehicles();
        int CountType(string typeName);
        List<IVehicle> Search(string type, string color, int numberOfWheels);
        int AddSampleVehicles();
    }
}
