using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Bus_Routes
    {
        public int Id_Bus_Routes{ get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public float Price { get; set; }

        // Relations

        [JsonIgnore]
        public List<Ticket> Tickets { get; set; }

    }
}
