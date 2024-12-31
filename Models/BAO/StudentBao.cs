using System.ComponentModel.DataAnnotations;
using HODPoc.DBContext;
using Microsoft.EntityFrameworkCore;

namespace HODPoc.Models.Entities
{
    public class StudentBao
    {
        private readonly StudentDao studentDao;

        public StudentBao(StudentDao studentDao)
        {
            this.studentDao = studentDao;
        }

        public async Task<List<Student>> Get()
        {
            return await studentDao.Get();
        }

        public async Task<string> Insert(Student student)
        {
            return await studentDao.Insert(student);
        }
    }
}
