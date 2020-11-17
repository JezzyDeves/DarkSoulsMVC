using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Location
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public ICollection<Boss> Bosses { get; set; } = new List<Boss>();
        public ICollection<Enemy> Enemies { get; set; } = new List<Enemy>();
        public ICollection<Item> Items { get; set; } = new List<Item>();

    }
}
