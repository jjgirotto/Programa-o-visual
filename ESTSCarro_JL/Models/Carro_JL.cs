using System.ComponentModel.DataAnnotations;

namespace ESTSCarro_JL.Models
{
    public class Carro_JL
    {
        public Guid Carro_JLId { get; set; }

        [Display(Name = "Marca")]
        [EnumDataType(typeof(Marcas_JL))]
        public Marcas_JL Marca_JL { get; set; }

        [Display(Name = "Modelo")]
        [EnumDataType(typeof(Modelos_JL))]
        public Modelos_JL Modelo_JL { get; set; }
    }
}
