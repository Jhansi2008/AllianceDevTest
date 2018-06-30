using System;

namespace Entities
{
    public class Company : EntityBase<Company>
    {
        public string Name
        {
            get;
            set;
        }

        public Address Address
        {
            get;
            set;
        }

        public Company(string companyName, Address address)
        {
            this.Name = companyName;
            this.Address = address;
        }
    }
}