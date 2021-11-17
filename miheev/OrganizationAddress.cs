using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miheev
{
    public class OrganizationAddress
    {
        private string number;
        private string street;
        private string city;
        public string Number
        {
            get => number; 
            set => number=value;
        }
        public string Street
        {
            get => street;
            set => street = value;
        }
        public string City
        {
            get => city;
            set => city = value;
        }
    }
}
