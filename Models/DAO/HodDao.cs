using HODPoc.DBContext;
using HODPoc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HODPoc.Models.DAO
{
    public class HodDao
    {
        private readonly HODContext _context;

        public HodDao(HODContext context)
        {
            _context = context;
        }

        public async Task<List<Hod>> Get()
        {
            return await _context.hods.ToListAsync();
        }

        public async Task<string> Insert(Hod hod)
        {
            await _context.hods.AddAsync(hod);
            await _context.SaveChangesAsync();
            return "1";
        }
    }
}
