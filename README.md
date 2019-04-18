# AzureIoTHub
Different operations using de IoT Hub
- (Beta) Device Migration

C# project which obtains the registereds Devices of an IoT Hub and migrate them into a Dynamics 365 Connected Field Service Environment.
Steps:
  1. Get all Devices from an IoT Hub.
  2. Create each Device as an IoT Device within D365 Connected Field Service.
  3. Execute Action Register IoT Device from D365 with will register the IoT Device directly to the IoT Hub of the Connected Field Service deployment.
