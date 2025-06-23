using IndoorLocalizationSystem.Data;
using IndoorLocalizationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace IndoorLocalizationSystem.Repositories
{
    public class DeviceRepository
    {
        private readonly AppDbContext _context;
        public DeviceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            return await _context.Devices
                .Include(d => d.Student)
                .ToListAsync();
        }
        public async Task<Device?> GetDeviceByIdAsync(int id)
        {
            return await _context.Devices
                .Include(d => d.Student)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task AddDeviceAsync(Device device)
        {
            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateDeviceAsync(Device device)
        {
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDeviceAsync(int id)
        {
            var device = await GetDeviceByIdAsync(id);
            if (device != null)
            {
                _context.Devices.Remove(device);
                await _context.SaveChangesAsync();
            }
        }
    }
}
