using ExampleTest2.Data;
using ExampleTest2.DTOs;
using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleTest2.Services
{
    public class WashingMachineService : IWashingMachineService
    {
        private readonly ApplicationDbContext _db;
        public WashingMachineService(ApplicationDbContext db) => _db = db;

        public Task<bool> SerialExistsAsync(string serial)
            => _db.WashingMachines.AnyAsync(x => x.SerialNumber == serial);

        public async Task<bool> ProgramsExistAsync(string[] names)
        {
            var count = await _db.Programs.CountAsync(p => names.Contains(p.Name));
            return count == names.Length;
        }

        public async Task CreateAsync(CreateWashingMachineDto dto)
        {
            var wm = new WashingMachine
            {
                SerialNumber = dto.WashingMachine.SerialNumber,
                MaxWeight = dto.WashingMachine.MaxWeight
            };
            _db.WashingMachines.Add(wm);
            await _db.SaveChangesAsync();

            var progs = await _db.Programs
                .Where(p => dto.AvailablePrograms.Select(x => x.ProgramName).Contains(p.Name))
                .ToListAsync();

            var joins = dto.AvailablePrograms
                .Select(x => new WashingMachineProgram
                {
                    WashingMachineId = wm.Id,
                    ProgramId = progs.First(p => p.Name == x.ProgramName).Id,
                    Price = x.Price
                });

            _db.WashingMachinePrograms.AddRange(joins);
            await _db.SaveChangesAsync();
        }
    }
}