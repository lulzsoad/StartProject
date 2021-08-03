using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartProject.Models
{
    public class StoreHouse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Location> Location { get; set; }
    }
}
