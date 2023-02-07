using System.ComponentModel.DataAnnotations;

namespace Rukomet.Models
{
    public class Igrac
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        [Display(Name = "Broj dresa")]
        public int BrojDresa { get; set; }
        public string Klub { get; set; }

    }
}
