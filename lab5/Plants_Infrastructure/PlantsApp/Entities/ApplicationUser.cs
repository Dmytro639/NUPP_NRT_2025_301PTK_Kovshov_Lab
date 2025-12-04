using Microsoft.AspNetCore.Identity;

namespace PlantsApp.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
