
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Mvc;

using WebApi_Template.Models;
using System.Collections.Generic;

namespace WebApi_Template.Controllers
{
  
    public class HomeController :Controller
    {
        private ApplicationDbContext dbContext { get; set; }
        public HomeController (ApplicationDbContext context)
        {
            dbContext = context;
        }


        [HttpGet]
        public IEnumerable<Album> GetAll()
        {
            var products = dbContext.Album.ToList();
            return products;
        }


        [HttpGet]
        public IEnumerable<Artist> GetTopArtist()
        {
            var products = dbContext.Artist.Take(100).ToList();
            IEnumerable<Artist> artist = products.OrderBy(a => a.Name);
                
            return products;
        }

       


    }
}
