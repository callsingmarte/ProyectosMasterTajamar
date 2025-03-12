using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Shared;
public class Program
{
    static RegistryManager registryManager;
    static string DeviceConnectionString = "HostName=iot-tajamarpruebas02.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=pRQAdOE+bd2QugBm/MXAQdeF5o8ep5697AIoTMfzv/E=";
    static ServiceClient client;
    static string targetDevice = "Device01";
    public static async Task QueryTwinRebootReported()
    {
        Twin twin = await registryManager.GetTwinAsync(targetDevice);
        Console.WriteLine(twin.Properties.Reported.ToJson());
    }
    public static async Task StartReboot()
    {
        client = ServiceClient.CreateFromConnectionString(DeviceConnectionString);
        CloudToDeviceMethod method = new CloudToDeviceMethod("reboot");
        method.ResponseTimeout = TimeSpan.FromSeconds(30);

        CloudToDeviceMethodResult result = await
         client.InvokeDeviceMethodAsync(targetDevice, method);

        Console.WriteLine("Invoked firmware update on device.");
        // El firmware es un tipo de software que está integrado en el hardware de un dispositivo, proporcionando las instrucciones necesarias para que ese dispositivo funcione correctamente. A diferencia del software tradicional, el firmware generalmente se encuentra en una memoria no volátil (como una memoria flash o ROM) y está diseñado para realizar tareas específicas de control o gestión del hardware.

    }
    static void Main()
    {
        registryManager = RegistryManager.CreateFromConnectionString(DeviceConnectionString);
        StartReboot().Wait();
        QueryTwinRebootReported().Wait();
        Console.WriteLine("Press ENTER to exit.");
        Console.ReadLine();
    }
}