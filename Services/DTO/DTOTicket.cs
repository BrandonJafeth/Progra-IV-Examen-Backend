using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class DTOTicket
    {
        public int Id_Ticket { get; set; }

        public DateTime Date_Ticket { get; set; }

       public string From { get; set; }
        public string To { get; set; }


    }
}
