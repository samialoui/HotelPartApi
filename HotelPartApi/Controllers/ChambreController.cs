using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChambreController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly IWebHostEnvironment _env;

        public ChambreController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        [Route("allChambres")]

        public IEnumerable<Chambre> Get()
        {
            return new Services.ServiceChambre().Get();
        }

        [HttpGet]
        [Route("getChambre")]

        public Chambre Get(int ID)
        {
            return new Services.ServiceChambre().Get(ID);
        }

        /*[HttpPost]
        [Route("AddChambre")]

        public void Post([FromBody] Chambre con)
        {
             new Services.ServiceChambre().Post(con);
        }*/

        [HttpDelete]
        [Route("deleteChambre")]

        public void Delete([FromBody] Chambre con)
        {
            new Services.ServiceChambre().Delete(con);
        }

        [HttpPut]
        [Route("putChambre")]

        public void Put([FromBody] Chambre con)
        {
            new Services.ServiceChambre().Put(con);
        }

        [HttpGet]
        [Route("GetAllSaisonNames")]
        public IEnumerable<Saison> GetAllSaisonNames()
        {
            return new Services.ServiceChambre().GetSaison();
        }


        [HttpPost]
        [Route("AddChambre")]
        public void SaveChambre()
        {
            var httpRequest = Request.Form;
            var postedFile = httpRequest.Files["Photo"];
            string filename = null;
            filename = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            filename = filename + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var physicalPath = Path.Combine(@"C:\Users\ASUS\Zodiac-Hammamet\src\assets\images\chambres", filename);
            using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }
            //Save to DB
            using (HotelsDBContext db = new HotelsDBContext())
            {
                Chambre chambre = new Chambre()
                {
                    ChambreNum = int.Parse(httpRequest["ChambreNum"]),
                    TypeChamb = httpRequest["TypeChamb"],
                    PrixNuit = int.Parse(httpRequest["PrixNuit"]),
                    NbLit = int.Parse(httpRequest["NbLit"]),
                    Descript = httpRequest["Descript"],
                    Disponibilité = int.Parse(httpRequest["Disponibilite"]),
                    Saison = int.Parse(httpRequest["Saison"]),
                    Photo = filename
                };
                db.Chambre.Add(chambre);
                db.SaveChanges();
            }
        }


    }

}
