
## Azure.IoTHub.Examples.CSharp.Core
This is a shared lib for all Azure IoT Hub Device Managment C# Sample Projects.  It 
currently contains configuration types and extension methods useful across all sample
projects in the solution. 

### Configuation
Projects in this solution use a [`yaml`](http://yaml.org/) configuration file to provide a single point
of configuration for all projects.  The configuration is mapped from the `config.yaml` file to the poco AzureIoTHubConfig 
type using the [YamlDotNet](http://aaubry.net/pages/yamldotnet.html) serialization/deserialization library.

## Code Example

``GetIoTConfiguration()`` - string extension method that takes a file path and deserializes the files yaml content into the AzureIoTHubConfig type

#### Example 
 ```C#
@"../../../config.yaml".GetIotConfiguration();
```

``UpdateIoTConfiguration(Configuration config)`` - `Configuration` extension method that writes a configuation object model to a target file.

#### Example
```C#
@"../../../config.yaml".UpdateIoTConfiguration(config);
```

## Notes
*None**

## License
This project uses the [MIT License](https://opensource.org/licenses/MIT)