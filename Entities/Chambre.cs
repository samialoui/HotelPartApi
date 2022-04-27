using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelPartApi
{
    public partial class Chambre
    {
        public Chambre()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int ChambreId { get; set; }
        public int ChambreNum { get; set; }
        public string TypeChamb { get; set; }
        public int PrixNuit { get; set; }
        public int NbLit { get; set; }
        public string Descript { get; set; }
        public string Photo { get; set; }
        public int Disponibilité { get; set; }
        public int Saison { get; set; }

        public virtual Saison SaisonNavigation { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
