using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTO;

namespace Services.Routes
{
    public interface ISvBus_Route
    {
        float GetPrice(string from, string to);

        Task<IEnumerable<DTOBus_Route>> GetAllRoutesAsync();
    }
}
