using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.DTOs
{
    public class WashingMachineCreateInfoDto
    {
        [Required]
        [MinLength(1)]
        public string SerialNumber { get; set; }
        [Range(8, double.MaxValue)]
        public double MaxWeight { get; set; }
    }
}