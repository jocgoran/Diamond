using System.ComponentModel.DataAnnotations;

namespace Diamond.Models
{
    public class Prodotto
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Nome prodotto")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome deve essere almeno 3 caratteri")]
        public string nome { get; set; }
        public string prezzo { get; set; }
        public int quantita { get; set; }
    }
}
