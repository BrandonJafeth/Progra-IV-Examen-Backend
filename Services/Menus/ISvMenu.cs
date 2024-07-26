using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Menus
{
    public interface ISvMenu
    {
        Task<IEnumerable<Menu>> GetAllMenusAsync();
    }
}
