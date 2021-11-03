using System;

namespace Messenger.Domain
{
    public class Person
    {
        //Properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Midname { get; set; }
        public string HeldPost { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime RegDate { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
    }
}
