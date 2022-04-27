using HotelPartApi;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class ServiceHotelService
    {
        public IEnumerable<ServiceHot> Get()
        {
            using (HotelsDBContext entites = new HotelsDBContext())
            {
                return entites.ServiceHot.OrderBy(x => x.ServiceId).ToList();
            }
        }

  

        public ServiceHot Get(int ID)
        {
            using (HotelsDBContext entites = new HotelsDBContext())
            {
                return entites.ServiceHot.FirstOrDefault(x => x.ServiceId == ID);
            }
        }

        public void Post([FromBody] ServiceHot con)
        {
            using (HotelsDBContext entites = new HotelsDBContext())
            {
                entites.Add(con);
                entites.SaveChanges();
            }
        }

        public void Delete([FromBody] ServiceHot con)
        {

            using (HotelsDBContext entites = new HotelsDBContext())
            {
                var chambDetails = entites.ServiceHot.FirstOrDefault(x => x.ServiceId == con.ServiceId);

                if (chambDetails != null)
                {
                    entites.Remove(chambDetails);
                    entites.SaveChanges();
                }
            }
        }

        public void Put([FromBody] ServiceHot con)
        {

            using (HotelsDBContext entites = new HotelsDBContext())
            {
                var chambDetails = entites.ServiceHot.FirstOrDefault(x => x.ServiceId == con.ServiceId);

                if (chambDetails != null)
                {
                    chambDetails.NomS = con.NomS;
                    chambDetails.Prix = con.Prix;
                    chambDetails.Photo = con.Photo;
                    chambDetails.Descript = con.Descript;

                    entites.SaveChanges();
                }
            }
        }
    }
}
