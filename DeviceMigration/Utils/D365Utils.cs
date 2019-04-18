using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Shared;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace DeviceMigration
{
    public static class  D365Utils
    {

        public static IOrganizationService _service { get; set; }

        /// <summary>
        /// Initialize D365 Connections
        /// </summary>
        /// <returns></returns>
        internal static void initD365Connection()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            CrmServiceClient conn = new CrmServiceClient(Properties.Settings.Default.D365Url);
            _service = conn.OrganizationWebProxyClient ?? (IOrganizationService)conn.OrganizationServiceProxy;
        }

        /// <summary>
        /// Create D365 IoT Devices
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Guid>> CreateDevicesD365(IEnumerable<Twin> iotDevices)
        {
            Console.WriteLine("Creating devices in D365");
            List<Guid> devicesCreated = new List<Guid>();
            for (int i = 0; i < iotDevices.Count(); i++)
            {
                if (iotDevices.ElementAt(i).DeviceId.Equals("Otromas"))
                {
                    Entity device = new Entity("msdyn_iotdevice");
                    device["msdyn_deviceid"] = iotDevices.ElementAt(i).DeviceId + "frombatch";
                    device["msdyn_name"] = "Device migrated " + i;
                    devicesCreated.Add(_service.Create(device));
                }
            }
            Console.WriteLine("Devices created in D365: " + devicesCreated.Count());
            return await Task.FromResult(devicesCreated);
        }

        /// <summary>
        /// Use Action from Connected Field Service to register devices in the environment IoT Hub 
        /// </summary>
        /// <returns></returns>
        public static void RegisterDevFromD365ToAzure(IEnumerable<Guid> iotDevices)
        {
            string param = "";
            foreach (var guid in iotDevices)
            {
                param = param + guid.ToString() + ",";
            }
            param = param.Substring(0, param.Length - 1);

            OrganizationRequest Req = new OrganizationRequest("msdyn_RegisterIoTDevice");

            Req["IoTDeviceIds"] = param; 

            OrganizationResponse Respons = _service.Execute(Req);
        }
    }
}
