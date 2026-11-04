namespace garage3.Interfaces
{
    public interface IVehicle
    {
        string LicensePlateNumber { get; }
        string Color { get; }
        int NumberOfWheels { get; }

        string GetTypeName();
    }
}
