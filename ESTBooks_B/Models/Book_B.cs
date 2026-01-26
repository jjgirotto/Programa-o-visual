using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESTBooks_B.Models
{
    public class Book_B
    {
        [Key]
        public Guid Book_BId { get; set; }

        [MaxLength(150)]
        public string Title_B { get; set; }

        [Column(TypeName = "decimal(10, 2)"), DataType(DataType.Currency)]
        public decimal Price_B { get; set; }

        [Range(0, 999)]
        public int Units_B { get; set; }

        [EnumDataType(typeof(BookCategory_B))]
        public BookCategory_B Category_B { get; set; }

        [ForeignKey("Store_BId")]
        public Guid Store_BId { get; set; }

        public BookStore_B? Store_B { get; set; }
    }
}
