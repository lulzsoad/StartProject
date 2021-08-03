using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartProject.Models
{
    public class PickupDocument
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public string State { get; set; }

        public ICollection<PickupProduct> pickupProduct { get; set; }
    }
}
