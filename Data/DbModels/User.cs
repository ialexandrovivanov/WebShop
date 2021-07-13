using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebShop.Data.DbModels
{
    public class User : IdentityUser<string>
    {
        [Key]
        public override string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime? CreatedOn { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }

        public virtual ICollection<Order> Orders { get; init; } = new HashSet<Order>();
    }
}
