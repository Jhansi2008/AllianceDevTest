namespace Entities
{
    public class Address
    {
        public string StreetName
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }

        public string ZipCode
        {
            get;
            set;
        }

        public Address(string streetName, string city, string state, string Zip)
        {
            this.StreetName = streetName;
            this.City = city;
            this.State = state;
            this.ZipCode = Zip;
        }

        public override bool Equals(object obj)
        {
            bool flag = obj is Address;
            bool result;
            if (flag)
            {
                Address targetAddress = obj as Address;
                result = (this.StreetName == targetAddress.StreetName && this.City == targetAddress.City && this.State == targetAddress.State && this.ZipCode == targetAddress.ZipCode);
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
