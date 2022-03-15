using System;
using System.Collections.Generic;
using System.Text;

namespace BE.DAL.DO.Objects
{
    public partial class CustomerCustomerDemo
    {
        public CustomerCustomerDemo()
        {
        }
        public string CustomerId { get; set; }
        public string CustomerTypeId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual CustomerDemographics CustomerType { get; set; }
    }
}
