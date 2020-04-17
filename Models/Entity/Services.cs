using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlrInvestSupply.Models.Entity
{
    public class Services
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string MediaUrl { get; set; }


        [Required]
        [DisplayName("Dil")]
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}