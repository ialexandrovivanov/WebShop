using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Data.DbModels
{
    public class Order
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public DateTime CreatedOn { get; init; } = DateTime.UtcNow;

        public ICollection<Pair> Items { get; init; } = new HashSet<Pair>();

        public string UserId { get; set; }
        public User User { get; init; }
    }
}
