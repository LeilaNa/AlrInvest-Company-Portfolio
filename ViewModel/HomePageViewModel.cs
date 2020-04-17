using AlrInvestSupply.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlrInvestSupply
{
    public class HomePageViewModel
    {
        public Slogans Slogans { get; set; }
        public About About { get; set; }
        public IEnumerable<Services> Services { get; set; }

        public Contact Contact { get; set; }
    }
}