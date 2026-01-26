using Microsoft.AspNetCore.Identity;

namespace T2_JulianaLeite.Models
{
    public class Autocaravanista_JL : IdentityUser
    {
        [PersonalData]
        public string Nome_JL { get; set; }
    }
}
