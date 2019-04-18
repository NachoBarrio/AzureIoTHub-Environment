using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Core;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Shared;

namespace DeviceMigration.Utils
{
    public class AzureUtils
    {
        private static RegistryManager _registryManager;

        /// <summary>
        /// Initialize Connection with Azure IoT Central Source
        /// </summary>
        /// <returns></returns>
		public static void initAzureConnection()
        {
            var config = @"../../../config/config.yaml".GetIoTConfiguration();
            var testDevice = config.DeviceConfigs.First();
            var azureConfig = config.AzureIoTHubConfig;
            _registryManager = RegistryManager.CreateFromConnectionString(azureConfig.ConnectionString);
        }
        /// <summary>
        /// Gets the list of configred devices in the Azure IoT Hub.
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<Twin>> GetDevices()
        {
            Console.WriteLine("Getting Configured Device List ...");
            IEnumerable<Twin> page = null;
            var query = _registryManager.CreateQuery("SELECT * FROM devices", 100);
            while (query.HasMoreResults)
            {
                page = await query.GetNextAsTwinAsync();
                
            }
            return page;
        }
    }
}
