using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Services.DTO;

namespace Services.Routes
{
    public class SvBus_Route : ISvBus_Route 
    {
        private readonly MyContext _myDbContext;

        public SvBus_Route(MyContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public float GetPrice(string from, string to)
        {
            if (from == to)
            {
                throw new ArgumentException("El lugar de salida y destino no pueden ser el mismo.");
            }

            var routePrice = _myDbContext.Routes
                .Where(r => (r.From == from && r.To == to) || (r.From == to && r.To == from))
                .Select(r => r.Price)
                .FirstOrDefault();

            if (routePrice == 0)
            {
                throw new KeyNotFoundException("No se encontró la ruta especificada.");
            }

            return routePrice;
        }
        public async Task<IEnumerable<DTOBus_Route>> GetAllRoutesAsync()
        {
            var routes = await _myDbContext.Routes
                .Select(r => new DTOBus_Route 
                {
                    Id_Route = r.Id_Bus_Routes,
                    From = r.From,
                    To = r.To,
                   
                })
                .ToListAsync();

            return routes;
        }
    }
}
