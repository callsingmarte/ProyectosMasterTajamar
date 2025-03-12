using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;

namespace ConsoleAzureIoT01
{
    class Program
    {
        static RegistryManager _registryManager;

        private const string ConnectionString = "HostName=iot-tajamarpruebas02.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=pRQAdOE+bd2QugBm/MXAQdeF5o8ep5697AIoTMfzv/E=";
        private const string DeviceId = "Device01";

        static void Main()
        {
            _registryManager = RegistryManager.CreateFromConnectionString(ConnectionString);
            AddDeViceAsync();
            Console.ReadKey();
        }

        private async static void AddDeViceAsync()
        {
            Device device;

            try
            {
                device = await _registryManager.AddDeviceAsync(new Device(DeviceId));
            }
            catch (DeviceAlreadyExistsException)
            {
                device = await _registryManager.GetDeviceAsync(DeviceId);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                device = await _registryManager.GetDeviceAsync(DeviceId);
            }

            Console.WriteLine("Device Id: {0}", DeviceId);
            Console.WriteLine("Generated device key: {0}", device.Authentication.SymmetricKey.PrimaryKey);
            Console.ReadKey();
        }

    }
}

