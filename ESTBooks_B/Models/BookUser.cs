using Microsoft.AspNetCore.Identity;

namespace ESTBooks_B.Models
{
    public class BookUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
    }
}
