using Microsoft.AspNetCore.Identity;

namespace FoodSelling.Backend.Entities
{
    public class User: IdentityUser<string>
    {
        public string IdentityCard { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
