using System.ComponentModel.DataAnnotations;
using HODPoc.DBContext;
using Microsoft.EntityFrameworkCore;

namespace HODPoc.Models.Entities
{
    public class TeacherDao
    {
        private readonly HODContext _context;

        public TeacherDao(HODContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> Get()
        {
            return await _context.teachers.ToListAsync();
        }

        public async Task<string> Insert(Teacher teacher)
        {
            await _context.teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return "1";
        }
    }
}
