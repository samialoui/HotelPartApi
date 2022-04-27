using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelPartApi
{
    public partial class Hotel
    {
        public int HotelId { get; set; }
        public string Adresse { get; set; }
        public string NumTele { get; set; }
        public string Ville { get; set; }
    }
}
