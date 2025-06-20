using ExampleTest2.DTOs;
using System.Threading.Tasks;

namespace ExampleTest2.Services
{
    public interface IWashingMachineService
    {
        Task<bool> SerialExistsAsync(string serial);
        Task<bool> ProgramsExistAsync(string[] names);
        Task CreateAsync(CreateWashingMachineDto dto);
    }
}