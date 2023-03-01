using Microsoft.AspNetCore.Identity;

namespace FoodSelling.Backend.Entities
{
    public class User: IdentityUser<string>
    {
        public int IdentityCard { get; set; }
        public string Role { get; set; }
    }
}
