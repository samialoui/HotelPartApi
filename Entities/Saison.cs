using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelPartApi
{
    public partial class Saison
    {
        public Saison()
        {
            Chambre = new HashSet<Chambre>();
        }

        public int IdSaison { get; set; }
        public string NomS { get; set; }
        public string DateS { get; set; }

        public virtual ICollection<Chambre> Chambre { get; set; }
    }
}
