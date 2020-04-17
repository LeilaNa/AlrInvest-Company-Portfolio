using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlrInvestSupply.Models.Entity
{
    public class Language
    {
        public int Id { get; set; }

        [DisplayName("Dil")]
        public string Name { get; set; }
    }
}