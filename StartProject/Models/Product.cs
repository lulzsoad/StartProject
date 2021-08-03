using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EAN { get; set; }
        public string Description { get; set; }

        public ICollection<StoreHouseAvailability> StoreHouseAvailabilities { get; set; }

    }
}
