using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.DTOs
{
    public class CreateWashingMachineDto
    {
        [Required]
        public WashingMachineCreateInfoDto WashingMachine { get; set; }
        [Required]
        public List<AvailableProgramDto> AvailablePrograms { get; set; }
    }
}