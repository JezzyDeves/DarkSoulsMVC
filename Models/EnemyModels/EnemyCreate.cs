using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EnemyModels
{
    public class EnemyCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Health { get; set; }
        public int LocationID { get; set; }
    }
}
