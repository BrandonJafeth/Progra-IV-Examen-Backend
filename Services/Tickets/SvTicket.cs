using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Services.DTO;

namespace Services.Tickets
{
    public class SvTicket : ISvTicket
    {
        private readonly MyContext _myDbContext;

        public SvTicket(MyContext myDbContext)
        {
            _myDbContext = myDbContext;
        }



        public async Task<Ticket> AddTicketAsync(DTOTicket dtoTicket)
        {
     
            var busRoute = await _myDbContext.Routes
                .FirstOrDefaultAsync(br => (br.From == dtoTicket.From && br.To == dtoTicket.To) ||
                               (br.From == dtoTicket.To && br.To == dtoTicket.From));

            if (busRoute == null)
            {
                throw new Exception("Ruta no encontrada.");
            }

            var ticket = new Ticket
            {
                Date_Ticket = dtoTicket.Date_Ticket,
                Id_Bus_Routes = busRoute.Id_Bus_Routes 
            };

            if (!await ValidarAsientosDisponiblesAsync(ticket.Date_Ticket, ticket.Id_Bus_Routes))
            {
                throw new Exception("La ruta ha alcanzado el máximo de capacidad para el día seleccionado.");
            }

            await _myDbContext.Tickets.AddAsync(ticket);
            await _myDbContext.SaveChangesAsync();
            return ticket;
        }


        public async Task<int> GetPersonsTraveledByRouteAsync(string departureRoute, string destinationRoute)
        {
            return await _myDbContext.Tickets
                .Where(t => (t.Bus_Routes.From == departureRoute && t.Bus_Routes.To == destinationRoute) ||
                            (t.Bus_Routes.From == destinationRoute && t.Bus_Routes.To == departureRoute))
                .CountAsync();
        }


        public async Task<int> GetPersonsTraveledByDateAsync(DateTime startDate, DateTime endDate)
        {
            return await _myDbContext.Tickets
                .Where(t => t.Date_Ticket >= startDate && t.Date_Ticket <= endDate)
                .CountAsync();
        }

        public async Task<float> GetTotalCollectedByRouteAsync(string departureRoute, string destinationRoute)
        {
            return await _myDbContext.Tickets
                .Where(t => (t.Bus_Routes.From == departureRoute && t.Bus_Routes.To == destinationRoute) ||
                            (t.Bus_Routes.From == destinationRoute && t.Bus_Routes.To == departureRoute))
                .SumAsync(t => t.Bus_Routes.Price);
        }


        public async Task<float> GetTotalCollectedByDateAsync(DateTime startDate, DateTime endDate)
        {
            return await _myDbContext.Tickets
                .Where(t => t.Date_Ticket >= startDate && t.Date_Ticket <= endDate)
                .SumAsync(t => t.Bus_Routes.Price);
        }


        public async Task<bool> ValidarAsientosDisponiblesAsync(DateTime Date_Ticket , int Id_Bus_Route)
        {
            var cantidadTickets = await _myDbContext.Tickets
                .Where(t => t.Date_Ticket.Date == Date_Ticket .Date && t.Id_Bus_Routes == Id_Bus_Route)
                .CountAsync();

            return cantidadTickets < 10;
        }


    }
}
