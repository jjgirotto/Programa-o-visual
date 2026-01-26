using Microsoft.AspNetCore.Identity;

namespace ESTSCarro_JL.Models
{
    public class Cliente_JL : IdentityUser
    {
        [PersonalData]
        public String Nome_JL { get; set; }
    }
}
