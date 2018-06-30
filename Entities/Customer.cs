using System;

namespace Entities
{
    public class Customer : EntityBase<Customer>
    {
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public Address Address
        {
            get;
            set;
        }

        public Customer(string firstName, string lastName, Address address)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
        }
    }
}