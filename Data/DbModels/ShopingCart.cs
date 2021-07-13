using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Data.DbModels
{
    public class ShopingCart
    {
        [Key]
        public string Id { get; init; }

        public ICollection<Pair> Items { get; set; } = new HashSet<Pair>();

        public string OwnerId { get; set; }
        public User Owner { get; set; }
    }
}
