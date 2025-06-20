namespace ExampleTest2.Models
{
    public class WashingMachineProgram
    {
        public int WashingMachineId { get; set; }
        public WashingMachine WashingMachine { get; set; }
        public int ProgramId { get; set; }
        public Program Program { get; set; }
        public double Price { get; set; }
    }
}