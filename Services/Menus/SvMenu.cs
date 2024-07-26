using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Menus
{
    public class SvMenu : ISvMenu
    {
        private readonly MyContext _myDbContext;

        public SvMenu(MyContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<IEnumerable<Menu>> GetAllMenusAsync()
        {
          return await _myDbContext.Menus.ToListAsync();
        }
    }
}
