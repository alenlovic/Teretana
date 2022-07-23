using System.ComponentModel.DataAnnotations;

namespace Teretana.Models
{
    public class TreneriModel
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
    }
}
