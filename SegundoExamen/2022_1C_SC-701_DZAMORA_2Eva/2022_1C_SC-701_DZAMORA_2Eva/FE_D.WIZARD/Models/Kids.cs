using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE_D.WIZARD.Models
{
    public partial class Kids
    {
        public Kids()
        {
            Toys = new HashSet<Toys>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Toys> Toys { get; set; }
    }
}
