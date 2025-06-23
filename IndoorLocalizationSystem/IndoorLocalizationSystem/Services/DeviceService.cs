using IndoorLocalizationSystem.Models;
using IndoorLocalizationSystem.Repositories;

namespace IndoorLocalizationSystem.Services
{
    public class DeviceService: IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        public async Task<Device> GetDeviceByIdAsync(int id)
        {
            return await _deviceRepository.GetDeviceByIdAsync(id);
        }
        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            return await _deviceRepository.GetAllDevicesAsync();
        }
        public async Task AddDeviceAsync(Device device)
        {
            if (string.IsNullOrWhiteSpace(device.MACAddress))
                throw new Exception("MAC address is required.");

            await _deviceRepository.AddDeviceAsync(device);
        }
        public async Task UpdateDeviceAsync(Device device)
        {
            var existing = await _deviceRepository.GetDeviceByIdAsync(device.Id);
            if (existing == null)
                throw new Exception("Device not found.");

            await _deviceRepository.UpdateDeviceAsync(device);
        }
        public async Task DeleteDeviceAsync(int id)
        {
            var device = await _deviceRepository.GetDeviceByIdAsync(id);
            if (device == null)
                throw new Exception("Device not found.");

            await _deviceRepository.DeleteDeviceAsync(id);
        }

        // Business logic to assign a device to a student
        public async Task AssignDeviceToStudentAsync(Device device)
        {
            if (string.IsNullOrWhiteSpace(device.MACAddress))
                throw new Exception("MAC address is required.");

            var existingDevice = (await _deviceRepository.GetAllDevicesAsync())
                .FirstOrDefault(d => d.MACAddress == device.MACAddress && d.Id != device.Id);

            if (existingDevice != null)
                throw new Exception("This MAC address is already assigned to another student.");

            await _deviceRepository.AddDeviceAsync(device);
        }


    }
}
