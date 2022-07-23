using System.ComponentModel.DataAnnotations;

namespace Teretana.Models
{
    public class ClanoviModel
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string DatumRodjenja { get; set; }
        public string BrojTelefona { get; set; }
        public string MjestoRodjenja { get; set; }
        public string Status { get; set; }
        public int BrojKartice { get; set; }
    }
}
