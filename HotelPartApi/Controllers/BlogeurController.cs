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
    public class BlogeurController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly IWebHostEnvironment _env;
        public BlogeurController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        [HttpGet]
        [Route("getAllBlogeurs")]
        public IEnumerable<Blogeur> getAllBlogeurs()
        {
            return new Services.ServiceBlogeur().Get();
        }

        [HttpGet]
        [Route("getBlogeur")]
        public Blogeur Get(int ID)
        {
            return new Services.ServiceBlogeur().Get(ID);
        }

        [Route("AddBlogeur")]
        [HttpPost]
        public void AddBlogeur()
        {

            var nom = HttpContext.Request.Form["nom"];
            var prenom = HttpContext.Request.Form["prenom"];
            var note = HttpContext.Request.Form["note"];
            var descript = HttpContext.Request.Form["descript"];
            var pays = HttpContext.Request.Form["pays"];
            var photo = HttpContext.Request.Form.Files["photo"];

            new Services.ServiceBlogeur().AddBlogeurAsync(nom, prenom, note, descript, pays, photo);


        }


        [HttpPost]
        [Route("addBlogeur")]
        public void Post([FromBody] Blogeur con)
        {
            new Services.ServiceBlogeur().Post(con);
        }

        [HttpDelete]
        public void Delete(int ID)
        {
            new Services.ServiceBlogeur().Delete(ID);
        }

        [HttpPut]
        [Route("putBlogeur")]
        public void Put([FromBody] Blogeur con)
        {
            new Services.ServiceBlogeur().Put(con);
        }


        [HttpPost]
        [Route("UploadImage")]
        public void SaveFile()
        {

            var httpRequest = Request.Form;
            var postedFile = httpRequest.Files["Photo"];
            string filename = null;
            filename = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            filename = filename + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var physicalPath = Path.Combine(@"C:\Users\ASUS\Zodiac-Hammamet\src\assets\images\blogeurs", filename);

            using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }
            //Save to DB
            using (HotelsDBContext db = new HotelsDBContext())
            {
                Blogeur blogeur = new Blogeur()
                {
                    Nom = httpRequest["Nom"],
                    Prenom = httpRequest["Prenom"],
                    Note = httpRequest["Note"],
                    Descript = httpRequest["Descript"],
                    Pays = httpRequest["Pays"],
                    Photo = filename
                };
                db.Blogeur.Add(blogeur);
                db.SaveChanges();
            }



        }

        /* [HttpPost]
         [Route("UploadImage")]
         public void UploadImage()
         {

             string imageName = null;
             var nom = HttpContext.Request.Form["Nom"];
             var prenom = HttpContext.Request.Form["Prenom"];
             var note = HttpContext.Request.Form["Note"];
             var descript = HttpContext.Request.Form["Descript"];
             var pays = HttpContext.Request.Form["Pays"];

             //Upload Image
             var postedFile = HttpContext.Request.Form.Files["Image"];
             //Create custom filename
             imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
             imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);

             var filePath = Path.Combine(@"C:\Users\ASUS\Zodiac-Hammamet\src\assets\images\blogeurs", imageName);
              using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
             {
                 postedFile.CopyTo(fileStream);
             }
             // var filePath = HttpContext.Current.Server.MapPath("~/Images/" + imageName);
             //postedFile.SaveAs(filePath);

             //Save to DB
             using (HotelsDBContext db = new HotelsDBContext())
             {
                 Blogeur blogeur = new Blogeur()
                 {
                     Nom = nom,
                     Prenom = prenom,
                     Note = note,
                     Descript = descript,
                     Pays = pays,
                     Photo = imageName
                 };
                 db.Blogeur.Add(blogeur);
                 db.SaveChanges();
             }

         }*/



    }
}
