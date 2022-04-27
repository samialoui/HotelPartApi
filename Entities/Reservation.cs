using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelPartApi
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public string DateArr { get; set; }
        public string DateDep { get; set; }
        public int NbPers { get; set; }
        public int ChambreId { get; set; }
        public int Prix { get; set; }
        public int FactId { get; set; }
        public int ClientId { get; set; }
        public string DemandSpecial { get; set; }
        public string Coupon { get; set; }
        public int PaymentId { get; set; }
        public int Confirmation { get; set; }

        public virtual Chambre Chambre { get; set; }
        public virtual Client Client { get; set; }
        public virtual Facture Fact { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
