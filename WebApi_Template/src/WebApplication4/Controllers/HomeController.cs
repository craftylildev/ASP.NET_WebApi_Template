
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

        // Bring back 100 artists and order by name (hint new model class, new entry to the entityset in the DBContext class)
        [HttpGet]
        public IEnumerable<Artist> GetTopArtist()
        {
            // WHY IS THIS NOT WORKING
            //var products = dbContext.Artist.Take(100).ToList();
            //IEnumerable<Artist> artist = products.OrderBy(a => a.Name);
            //return products;

            return dbContext.Artist.Take(100).ToList().OrderBy(a => a.Name);
        }

        // Pass in a search phase to the Artist table, query the artist table by the search phrase, output the results.
        [HttpGet]
       public IEnumerable<Artist> SearchArtist(string artistName)
        {
            //var products = dbContext.Artist.Where(a => a.Name == artistName).ToList();
            //return products;
            
            return dbContext.Artist.Where(a => a.Name == artistName).ToList();
        }

        // List all the artist on a particular album you like(hint, will need to pass an album id in the calling url to the action)


        //List all of the albums by your favorite artist.
        public IEnumerable<AlbumTitle> FavArtistAlbums(string artistName)
        {
            var products = (from al in dbContext.Album
                            join ar in dbContext.Artist
                            on al.ArtistId equals ar.ArtistId
                            where ar.Name == artistName
                            select new AlbumTitle
                            {
                                Title = al.Title
                            })
                           .ToList();
            return products;
        }

        // Create a class that will hold information regarding concerts you would like to attend. 
        // Create a list containing your concerts of choice. Set up several properties. 
        // Query your favorite concert list.

    }
}
