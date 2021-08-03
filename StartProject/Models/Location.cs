using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartProject.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public int StoreHouseId { get; set; }
        public virtual StoreHouse StoreHouse { get; set; }

    }
}
