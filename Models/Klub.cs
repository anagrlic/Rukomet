using System.ComponentModel.DataAnnotations;

namespace Rukomet.Models
{
    public class Klub
    {
        public int Id { get; set; }

        [Display(Name = "Ime kluba")]
        public string ImeKluba { get; set; }

        [Display(Name = "Grad kluba")]
        public string GradKluba { get; set; }

        [Display(Name = "Broj trofeja")]
        public int BrojTrofeja { get; set; }
    }
}
