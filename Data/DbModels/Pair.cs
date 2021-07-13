using System;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Data.DbModels
{
    public class Pair
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [MaxLength(100)]
        public string Brand { get; set; }

        [MaxLength(100)]
        public string Model { get; set; }

        public double SizeUK { get => this.SizeUS - 0.5; }
        public double SizeUS { get => this.SizeEU - 33; }
        public double SizeEU { get; set; }
        public double SizeSM { get; set; }

        public int Count { get; set; }
        public string Description { get; set; }

        [Url]
        public string Image01 { get; set; }
        [Url]
        public string Image02 { get; set; }
        [Url]
        public string Image03 { get; set; }
        [Url]
        public string Image04 { get; set; }
        [Url]
        public string Image05 { get; set; }
        [Url]
        public string Image06 { get; set; }
        [Url]
        public string Image07 { get; set; }
        [Url]
        public string Image08 { get; set; }
    }
}
