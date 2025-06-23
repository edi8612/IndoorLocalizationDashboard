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
            await _deviceRepository.AddDeviceAsync(device);
        }
        public async Task UpdateDeviceAsync(Device device)
        {
            await _deviceRepository.UpdateDeviceAsync(device);
        }
        public async Task DeleteDeviceAsync(int id)
        {
            await _deviceRepository.DeleteDeviceAsync(id);
        }

        

      
    }
}
