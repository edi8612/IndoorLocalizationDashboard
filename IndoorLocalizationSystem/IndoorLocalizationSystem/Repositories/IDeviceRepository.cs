using IndoorLocalizationSystem.Models;

namespace IndoorLocalizationSystem.Repositories
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetAllDevicesAsync();
        Task<Device?> GetDeviceByIdAsync(int id);
        Task AddDeviceAsync(Device device);
        Task UpdateDeviceAsync(Device device);
        Task DeleteDeviceAsync(int id);



        //Task<IEnumerable<Device>> GetDevicesByUserIdAsync(string userId);
        //Task<IEnumerable<Device>> GetDevicesByLocationAsync(string location);
        //Task<IEnumerable<Device>> GetDevicesByTypeAsync(string type);
    }
}
