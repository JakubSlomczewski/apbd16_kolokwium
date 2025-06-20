using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.DTOs
{
    public class AvailableProgramDto
    {
        [Required]
        public string ProgramName { get; set; }
        [Range(0,25)]
        public double Price { get; set; }
    }
}