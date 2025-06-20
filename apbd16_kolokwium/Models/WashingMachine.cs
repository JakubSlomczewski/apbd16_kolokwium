using System.Collections.Generic;

namespace ExampleTest2.Models
{
    public class WashingMachine
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public double MaxWeight { get; set; }
        public ICollection<WashingMachineProgram> WashingMachinePrograms { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}