using System.ComponentModel.DataAnnotations;
using HODPoc.DBContext;
using Microsoft.EntityFrameworkCore;

namespace HODPoc.Models.Entities
{
    public class StudentDao
    {
        private readonly HODContext _context;

        public StudentDao(HODContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> Get()
        {
            return await _context.students.ToListAsync();
        }

        public async Task<string> Insert(Student student)
        {
            await _context.students.AddAsync(student);
            await _context.SaveChangesAsync();
            return "1";
        }
    }
}
