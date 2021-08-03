using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartProject.Models
{
    public class StoreHouseAvailability
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

    }
}
