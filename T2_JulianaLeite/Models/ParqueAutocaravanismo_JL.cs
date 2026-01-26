using System.ComponentModel.DataAnnotations;

namespace T2_JulianaLeite.Models
{
    public class ParqueAutocaravanismo_JL
    {
        [Key]
        public Guid ParqueAutocaravanismo_JLId { get; set; }
        [Display(Name = "Nome")]
        public String Nome_JL { get; set; }
        [Display(Name = "Autocaravanas")]
        public List<Autocaravana_JL>? Autocaravanas_JL { get; set; }
    }
}
