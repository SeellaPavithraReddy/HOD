using System.ComponentModel.DataAnnotations;
using HODPoc.DBContext;
using Microsoft.EntityFrameworkCore;

namespace HODPoc.Models.Entities
{
    public class SubjectDao
    {
        private readonly HODContext _context;

        public SubjectDao(HODContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> Get()
        {
            return await _context.subjects.ToListAsync();
        }

        public async Task<string> Insert(Subject subject)
        {
            await _context.subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            return "1";
        }
    }
}
