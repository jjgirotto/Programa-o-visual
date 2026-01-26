using System.ComponentModel.DataAnnotations;

namespace ESTBooks_B.Models
{
    public class BookStore_B
    {
        [Key]
        public Guid BookStore_BId { get; set; }
        public string Location_B { get; set; }
        public List<Book_B> Books_B { get; set; } = new List<Book_B>();
    }
}
