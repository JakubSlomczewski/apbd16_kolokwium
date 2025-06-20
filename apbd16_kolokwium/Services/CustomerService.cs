using ExampleTest2.Data;
using ExampleTest2.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleTest2.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _db;
        public CustomerService(ApplicationDbContext db) => _db = db;
        public async Task<CustomerPurchasesDto> GetPurchasesAsync(int customerId)
        {
            var result = await _db.Customers
                .Where(c => c.Id == customerId)
                .Select(c => new CustomerPurchasesDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    PhoneNumber = c.PhoneNumber,
                    Purchases = c.Purchases.Select(p => new PurchaseDto
                    {
                        Date = p.Date,
                        Rating = p.Rating,
                        Price = p.Price,
                        WashingMachine = new WashingMachineInfoDto
                        {
                            Serial = p.WashingMachine.SerialNumber,
                            MaxWeight = p.WashingMachine.MaxWeight
                        },
                        Program = new ProgramInfoDto
                        {
                            Name = p.Program.Name,
                            Duration = p.Program.Duration
                        }
                    })
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}