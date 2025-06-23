using IndoorLocalizationSystem.Models;

namespace IndoorLocalizationSystem.Services
{
    public interface IDeviceService
    {
        Task<IEnumerable<Device>> GetAllDevicesAsync();
        Task<Device?> GetDeviceByIdAsync(int id);
        Task AddDeviceAsync(Device device);
        Task UpdateDeviceAsync(Device device);
        Task DeleteDeviceAsync(int id);
        Task AssignDeviceToStudentAsync(Device device);

    }
}
