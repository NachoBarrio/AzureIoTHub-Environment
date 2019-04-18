using System.Collections.Generic;

namespace CSharp.Core
{
    /// <summary>
    /// Model of yaml configuration file.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Gets or sets the azure iot hub configuration.
        /// </summary>
        /// <value>
        /// The azure io t hub configuration.
        /// </value>
        public AzureIoTHubConfig AzureIoTHubConfig { get; set; }

        /// <summary>
        /// Gets or sets the list of device configurations.
        /// </summary>
        /// <value>
        /// The device configurations.
        /// </value>
        public List<DeviceConfig> DeviceConfigs { get; set; }
    }
    /// <summary>
    /// Model of settings of Azure IoT Hub.
    /// </summary>
    public class AzureIoTHubConfig
    {
        /// <summary>
        /// Gets or sets the iot hub URI - aka azure portal iot hub host name.
        /// </summary>
        /// <value>
        /// The iot hub URI - aka azure portal iot hub host name.
        /// </value>
        public string IoTHubUri { get; set; }

        /// <summary>
        /// Gets or sets the iot hub storage URI.
        /// </summary>
        /// <value>
        /// The iot hub storage URI.d
        /// </value>
        public string IoTHubStorageUri { get; set; }

        /// <summary>
        /// Gets or sets the io t hub storage container.
        /// </summary>
        /// <value>
        /// The io t hub storage container.
        /// </value>
        public string IoTHubStorageContainer { get; set; }

        /// <summary>
        /// Gets or sets the iot hub D2C (device to cloud) messaging endpoint.
        /// </summary>
        /// <value>
        /// The iot hub D2C (device to client) messaging endpoint.
        /// </value>
        public string IoTHubD2CEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the connection string to the iot hub.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        public string ConnectionString { get; set; }
    }

    /// <summary>
    /// Model of a single device configuration.
    /// </summary>
    public class DeviceConfig
    {
        /// <summary>
        /// Gets or sets the name of the device nickname.
        /// </summary>
        /// <value>
        /// The name of the device nickname.
        /// </value>
        public string Nickname { get; set; }

        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the device key.
        /// </summary>
        /// <value>
        /// The device key.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the device generation.
        /// </summary>
        /// <value>
        /// The generation.
        /// </value>
        public string Status { get; set; }
    }
}
