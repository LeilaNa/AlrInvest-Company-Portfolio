using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlrInvestSupply.Models.Entity
{
    public class Contact
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(150)]
        public string Adress { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
    }
}