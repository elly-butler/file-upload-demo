using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Nexul.Demo
{
    public class NexulIdentityUser : IdentityUser
    {
        [MaxLength(120)]
        public string Name { get; set; }
    }
}
