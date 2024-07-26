using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Ticket
    {
        public int Id_Ticket { get; set; }

       public DateTime Date_Ticket { get; set; }

        // Relations 
        public int Id_Bus_Routes { get; set; }

        [JsonIgnore]
        public Bus_Routes Bus_Routes { get; set; }

    }
}
