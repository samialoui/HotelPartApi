using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelPartApi
{
    public partial class Payment
    {
        public Payment()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int PaymentId { get; set; }
        public string TypeP { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
