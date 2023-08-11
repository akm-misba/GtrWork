using Microsoft.AspNetCore.Identity;
using System;

namespace GtrWork.Member.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Number { get; set; }

    }
}
