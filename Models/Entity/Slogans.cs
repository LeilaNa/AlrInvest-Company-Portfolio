using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlrInvestSupply.Models.Entity
{
    public class Slogans
    {

        public int Id { get; set; }

        [DisplayName("Böyük hərflərlə yazılmış sloqan")]
        [MaxLength(50, ErrorMessage = "Böyük hərflərlə yazılmış  sloqan üçün 50 simvoldan artıq simvoldan istifadə edə bilməzsiz")]
        [Required(ErrorMessage = "Bu sahə boş buraxıla bilməz")]
        [MinLength(10, ErrorMessage = "Böyük hərflərlə yazılmış sloqan üçün 10 simvoldan az simvoldan istifadə edə bilməzsiz")]
        public string BigSlogan { get; set; }

        [DisplayName("Kiçik hərflərlə yazılmış sloqan")]
        [MaxLength(50, ErrorMessage = "Kiçik hırflərlə yazılmış sloqan üçün 100 simvoldan artıq simvoldan istifadə edə bilməzsiz")]
        [Required(ErrorMessage = "Bu sahə boş buraxıla bilməz")]
        [MinLength(20, ErrorMessage = " Kiçik hırflərlə yazılmış sloqan üçün 20 simvoldan az simvoldan istifadə edə bilməzsiz")]
        public string SmallSlogan { get; set; }

        [Required]
        [DisplayName("Dil")]
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}