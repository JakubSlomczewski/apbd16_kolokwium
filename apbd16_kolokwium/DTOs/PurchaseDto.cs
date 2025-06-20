using System;

namespace ExampleTest2.DTOs
{
    public class PurchaseDto
    {
        public DateTime Date { get; set; }
        public int? Rating { get; set; }
        public double Price { get; set; }
        public WashingMachineInfoDto WashingMachine { get; set; }
        public ProgramInfoDto Program { get; set; }
    }
}