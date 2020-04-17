using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlrInvestSupply.Models.Entity
{
    public class Clients
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public string MediaUrl { get; set; }

        public string Link { get; set; }
    }
}