using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using System.Text;

namespace SimulateManageDevice
{
    public class Program
    {
        static string DeviceConnectionString = "HostName=iot-tajamarpruebas02.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=pRQAdOE+bd2QugBm/MXAQdeF5o8ep5697AIoTMfzv/E=;DeviceId=Device01";
        static DeviceClient Client = null;
        static Task<MethodResponse> onReboot(MethodRequest methodRequest, object userContext) 
        {
            try
            {
                Console.WriteLine("Rebooting!");

                TwinCollection reportedProperties, reboot, lastReboot;
                lastReboot = new TwinCollection();
                reportedProperties = new TwinCollection();
                reboot = new TwinCollection();

                lastReboot["lastReboot"] = DateTime.Now;
                reboot["reboot"] = lastReboot;
                reportedProperties["iothubDM"] = reboot;

                lastReboot = new TwinCollection();
                Client.UpdateReportedPropertiesAsync(reportedProperties).Wait();
            }
            catch (Exception ex) 
            {
                Console.WriteLine();
                Console.WriteLine($"Error in device {ex.Message}");
            }

            string result = @"{""result"": ""Reboot started. ""}";
            return Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(result), 200));
        }

        static void Main()
        {
            try
            {
                Console.WriteLine("Connecting To hub");
                Client = DeviceClient.CreateFromConnectionString(DeviceConnectionString, TransportType.Mqtt);

                Client.SetMethodHandlerAsync("reboot", onReboot, null).Wait();
                Console.WriteLine("Waiting for reboot\n press enter to exit");
                Console.ReadLine();
                Console.WriteLine("Exiting...");
                Client.SetMethodHandlerAsync("reboot", null, null).Wait();
                Client.CloseAsync().Wait();
            }
            catch (Exception ex){
                Console.WriteLine(); Console.WriteLine($"Error en {ex.Message}");
            }
        }
    }
}