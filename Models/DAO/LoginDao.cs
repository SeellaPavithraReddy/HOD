using System.ComponentModel.DataAnnotations;
using HODPoc.DBContext;
using Microsoft.EntityFrameworkCore;

namespace HODPoc.Models.Entities
{
    public class LoginDao
    {
        private readonly HODContext _context;

        public LoginDao(HODContext context)
        {
            _context = context;
        }

        public async Task<List<Login>> Get()
        {
            return await _context.logins.ToListAsync();
        }

        public async Task<string> Insert(Login login)
        {
            await _context.logins.AddAsync(login);
            await _context.SaveChangesAsync();
            return "1";
        }
    }
}
