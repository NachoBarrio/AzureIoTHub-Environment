using CSharp.Core;
using DeviceMigration.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMigration
{
    /// <summary>
    /// Launh procedure
    /// </summary>
    public class IoTHubToD365
    {
        static void Main(string[] args)
        {
            try
            {
                Run().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an exception: {ex.ToString()}");
            }
        }

        /// <summary>
        /// Batch to migrate IoT Devices from IoT Hub to D365 Connected Field Service
        /// </summary>
        /// <returns></returns>
        public static async Task Run()
        {
            Console.WriteLine("Starting IoT Devices import");
            #region connections
            AzureUtils.initAzureConnection();
            D365Utils.initD365Connection();
            #endregion
            Console.WriteLine("Connections established");


            var devices = await AzureUtils.GetDevices();
            Console.WriteLine(devices.Count() + " devices recovered from IoT Hub");
            var devices_GUIDs = await D365Utils.CreateDevicesD365(devices);
            D365Utils.RegisterDevFromD365ToAzure(devices_GUIDs);
            Console.WriteLine("End of execution");
        }


    }
}
