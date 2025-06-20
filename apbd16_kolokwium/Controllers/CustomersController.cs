using ExampleTest2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExampleTest2.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _cs;
        public CustomersController(ICustomerService cs) => _cs = cs;

        [HttpGet("{customerId}/purchases")]
        public async Task<IActionResult> GetPurchases(int customerId)
        {
            var data = await _cs.GetPurchasesAsync(customerId);
            if (data == null) return NotFound();
            return Ok(data);
        }
    }
}