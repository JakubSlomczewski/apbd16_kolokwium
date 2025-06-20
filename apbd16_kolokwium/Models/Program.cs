using System.Collections.Generic;

namespace ExampleTest2.Models
{
    public class Program
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public ICollection<WashingMachineProgram> WashingMachinePrograms { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}