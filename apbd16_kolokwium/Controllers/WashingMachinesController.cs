using ExampleTest2.DTOs;
using ExampleTest2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleTest2.Controllers
{
    [ApiController]
    [Route("api/washing-machines")]
    public class WashingMachinesController : ControllerBase
    {
        private readonly IWashingMachineService _ws;
        public WashingMachinesController(IWashingMachineService ws) => _ws = ws;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateWashingMachineDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _ws.SerialExistsAsync(dto.WashingMachine.SerialNumber))
                return Conflict();

            var names = dto.AvailablePrograms.Select(x => x.ProgramName).ToArray();
            if (!await _ws.ProgramsExistAsync(names))
                return BadRequest("Nie istnieje program o podanej nazwie.");

            await _ws.CreateAsync(dto);
            return Created("", null);
        }
    }
}