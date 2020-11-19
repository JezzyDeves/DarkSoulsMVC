using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.LocationModels
{
    public class LocationDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Bosses { get; set; }
        public string Enemies { get; set; }
        public string Items { get; set; }
    }
}
