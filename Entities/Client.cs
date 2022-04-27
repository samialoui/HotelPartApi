using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelPartApi
{
    public partial class Client
    {
        public Client()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int ClientId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string NumTele { get; set; }
        public string Adress { get; set; }
        public string Quartier { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
