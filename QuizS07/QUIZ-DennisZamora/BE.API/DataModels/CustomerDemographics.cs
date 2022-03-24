using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.DataModels
{
    public class CustomerDemographics
    {
        public CustomerDemographics()
        {
            //CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
        }
        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }
    }
}
