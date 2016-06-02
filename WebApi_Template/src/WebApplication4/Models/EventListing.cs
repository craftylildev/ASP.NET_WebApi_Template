using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Template.Models
{
    public class EventListing
    {
                 
        public List<Concert> EventList { get; set; }

        public EventListing()
        {
            this.EventList = new List<Concert>();
            this.EventList.Add(new Concert{ArtistId = 5, ConcertName = "Fun Tour",  ConcertDate = new DateTime(2002, 05, 31)});
        }

    }
}
