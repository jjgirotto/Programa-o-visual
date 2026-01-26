using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2_JulianaLeite.Models
{
    public class Autocaravana_JL
    {
        [Key]
        public Guid Autocaravana_JLId { get; set; }
        
        [MaxLength(8)]
        [Display(Name = "Matrícula")]
        public String Matricula_JL { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        [DataType(DataType.Currency)]
        [Display(Name = "Diária")]
        public decimal Diaria_JL { get; set; }

        [Display(Name = "Parque de Autocaravanismo")]
        public ParqueAutocaravanismo_JL? ParqueAutocaravanismo_JL { get; set; }
        
        [Display(Name = "ID Parque de Autocaravanismo")]
        [ForeignKey("ParqueAutocaravanismo_JLId")]
        public Guid? ParqueAutocaravanismo_JLId { get; set; }

    }
}
