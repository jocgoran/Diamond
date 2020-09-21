using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diamond.Models
{
    public class Prodotto
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Nome prodotto")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome deve essere almeno 3 caratteri")]
        public string nome { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal prezzo { get; set; }
        [Range(0, 10000)]
        public int quantita { get; set; }
    }
}
