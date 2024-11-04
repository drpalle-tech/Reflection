using Reflection_Advanced;

class Program
{
    static void Main()
    {
        Console.WriteLine("*** TALKING TO EXTERNAL WORLD VIA A DLL.");

        GatewayConnector _gateway = new GatewayConnector();

        _gateway.StartTalking();

        Console.WriteLine($"Enter to disconnect");

        Console.ReadLine();

        _gateway.StopTalking();

        Console.ReadKey();
    }
}