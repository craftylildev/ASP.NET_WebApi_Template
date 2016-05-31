
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Mvc;

using WebApi_Template.Models;

namespace WebApi_Template.Controllers
{
  
    public class HomeController 
    {
        [HttpGet]
        public string GetAll()
        {
                return "This is GetAll in ModelOne";
        }
    }
}
