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
    public class ServiceController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly IWebHostEnvironment _env;

        public ServiceController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        [Route("allServices")]

        public IEnumerable<ServiceHot> Get()
        {
            return new Services.ServiceHotelService().Get();
        }

        [HttpGet]
        [Route("getService")]

        public ServiceHot Get(int ID)
        {
            return new Services.ServiceHotelService().Get(ID);
        }

        /*[HttpPost]
        [Route("AddChambre")]

        public void Post([FromBody] Chambre con)
        {
             new Services.ServiceChambre().Post(con);
        }*/

        [HttpDelete]
        [Route("deleteService")]

        public void Delete([FromBody] ServiceHot con)
        {
            new Services.ServiceHotelService().Delete(con);
        }

        [HttpPut]
        [Route("putService")]

        public void Put([FromBody] ServiceHot con)
        {
            new Services.ServiceHotelService().Put(con);
        }


        [HttpPost]
        [Route("AddService")]
        public void SaveService()
        {
            var httpRequest = Request.Form;
            var postedFile = httpRequest.Files["Photo"];
            string filename = null;
            filename = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            filename = filename + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var physicalPath = Path.Combine(@"C:\Users\ASUS\Zodiac-Hammamet\src\assets\images\services", filename);
            using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }
            //Save to DB
            using (HotelsDBContext db = new HotelsDBContext())
            {
                ServiceHot service = new ServiceHot()
                {
                    NomS = httpRequest["NomService"],
                    Prix = int.Parse(httpRequest["Prix"]),
                    Descript = httpRequest["Descript"],
                    Photo = filename
                };
                db.ServiceHot.Add(service);
                db.SaveChanges();
            }
        }


    }
}
