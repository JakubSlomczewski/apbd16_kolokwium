using System.Collections.Generic;

namespace ExampleTest2.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}