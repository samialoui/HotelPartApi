using HotelPartApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceBlogeur
    {
        public IEnumerable<Blogeur> Get()
        {
            using (HotelsDBContext entities = new HotelsDBContext())
                return entities.Blogeur.OrderBy(x => x.BlogId).ToList();

        }

        public Blogeur Get(int ID)
        {
            using (HotelsDBContext entities = new HotelsDBContext())
            {
                return entities.Blogeur.FirstOrDefault(x => x.BlogId == ID);
            }
        }

        public void Post([FromBody] Blogeur con)
        {
            using (HotelsDBContext entites = new HotelsDBContext())
            {
                entites.Add(con);
                entites.SaveChanges();
            }
        }

        public void AddBlogeurAsync(string nom, string prenom, string note, string descript, string pays, IFormFile photo)
        {
            using (HotelsDBContext _db = new HotelsDBContext())
            {
                // Real path
                // var filePath = Path.Combine(_host.WebRootPath + "/images/actors", img.FileName); 
                var filePath = Path.Combine(@"C:\Users\ASUS\Zodiac-Hammamet\src\assets\images\blogeurs", photo.FileName);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyToAsync(fileStream);
                }

                var blogeur = new Blogeur
                {
                    Nom = nom,
                    Prenom = prenom,
                    Note = note,
                    Descript = descript,
                    Pays = pays,
                    Photo = photo.FileName
                };
                _db.Blogeur.Add(blogeur);
                _db.SaveChangesAsync();
            }
        }



        public void Delete(int ID)
        {
            using (HotelsDBContext entites = new HotelsDBContext())
            {
                var ConDetail = entites.Blogeur.FirstOrDefault(p => p.BlogId == ID);
                if (ConDetail != null)
                {
                    entites.Blogeur.Remove(ConDetail);
                    entites.SaveChanges();
                }
            }
        }

        public void Put([FromBody] Blogeur con)
        {
            using (HotelsDBContext entites = new HotelsDBContext())
            {
                var conDetail = entites.Blogeur.FirstOrDefault(x => x.BlogId == con.BlogId);
                if (conDetail != null)
                {
                    conDetail.Nom = con.Nom;
                    conDetail.Prenom = con.Prenom;
                    conDetail.Note = con.Note;
                    conDetail.Descript = con.Descript;
                    conDetail.Pays = con.Pays;
                    conDetail.Photo = con.Photo;



                    entites.SaveChanges();
                }
            }
        }
    }
}
