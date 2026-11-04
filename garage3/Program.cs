using garage3;
using garage3.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        IUI ui = new UserInterface(new GarageHandler());
        ui.Run();
    }
}
