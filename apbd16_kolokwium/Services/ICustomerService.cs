using ExampleTest2.DTOs;
using System.Threading.Tasks;

namespace ExampleTest2.Services
{
    public interface ICustomerService
    {
        Task<CustomerPurchasesDto> GetPurchasesAsync(int customerId);
    }
}