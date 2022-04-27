using HotelPartApi;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceChambre
    {
        public IEnumerable<Chambre> Get()
        {
            using (HotelsDBContext entites = new HotelsDBContext())
            {
                return entites.Chambre.OrderBy(x => x.ChambreId).ToList();
            }
        }

        public IEnumerable<Saison> GetSaison()
        {
            using (HotelsDBContext entites = new HotelsDBContext())
            {
                return entites.Saison.OrderBy(x => x.IdSaison).ToList();
            }
        }

        public Chambre Get(int ID)
        {
            using (HotelsDBContext entites = new HotelsDBContext())
            {
                return entites.Chambre.FirstOrDefault(x => x.ChambreId == ID);
            }
        }

        public void Post([FromBody] Chambre con)
        {
            using (HotelsDBContext entites = new HotelsDBContext())
            {
                entites.Add(con);
                entites.SaveChanges();
            }
        }

        public void Delete([FromBody] Chambre con)
        {

            using (HotelsDBContext entites = new HotelsDBContext())
            {
                var chambDetails = entites.Chambre.FirstOrDefault(x => x.ChambreId == con.ChambreId);

                if (chambDetails != null)
                {
                    entites.Remove(chambDetails);
                    entites.SaveChanges();
                }
            }
        }

        public void Put([FromBody] Chambre con)
        {

            using (HotelsDBContext entites = new HotelsDBContext())
            {
                var chambDetails = entites.Chambre.FirstOrDefault(x => x.ChambreId == con.ChambreId);

                if (chambDetails != null)
                {
                    chambDetails.ChambreNum = con.ChambreNum;
                    chambDetails.TypeChamb = con.TypeChamb;
                    chambDetails.PrixNuit = con.PrixNuit;
                    chambDetails.NbLit = con.NbLit;
                    chambDetails.Descript = con.Descript;
                    chambDetails.Photo = con.Photo;
                    chambDetails.Disponibilité = con.Disponibilité;
                    chambDetails.Saison = con.Saison;

                    entites.SaveChanges();
                }
            }
        }
    }
}
