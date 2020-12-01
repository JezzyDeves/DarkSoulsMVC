using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Enemy
    {
        [Key]
        public int EnemyID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Health { get; set; }
        [Required]
        public string Description { get; set; }

        public int LocationID { get; set; }
        [ForeignKey(nameof(LocationID))]
        public Location Location { get; set; }
    }
}
