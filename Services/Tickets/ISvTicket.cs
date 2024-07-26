using Entities;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Services.DTO;

namespace Services.Tickets
{
    public interface ISvTicket
    {
        //Write
        Task<Ticket> AddTicketAsync(DTOTicket dtoTicket);

        //Read  
        Task<int> GetPersonsTraveledByRouteAsync(string departureRoute, string destinationRoute);
        Task<int> GetPersonsTraveledByDateAsync(DateTime startDate, DateTime endDate);
        Task<float> GetTotalCollectedByRouteAsync(string departureRoute, string destinationRoute);
        Task<float> GetTotalCollectedByDateAsync(DateTime startDate, DateTime endDate);
    }
}
