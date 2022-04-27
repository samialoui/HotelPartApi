using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelPartApi
{
    public partial class Facture
    {
        public Facture()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int FactId { get; set; }
        public string DateFact { get; set; }
        public int ServiceId { get; set; }

        public virtual ServiceHot Service { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
