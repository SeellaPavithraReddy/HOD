using System.ComponentModel.DataAnnotations;
using HODPoc.DBContext;
using Microsoft.EntityFrameworkCore;

namespace HODPoc.Models.Entities
{
    public class TeacherBao
    {
        private readonly TeacherDao teacherDao;

        public TeacherBao(TeacherDao teacherDao)
        {
            this.teacherDao = teacherDao;
        }

        public async Task<List<Teacher>> Get()
        {
            return await teacherDao.Get();
        }

        public async Task<string> Insert(Teacher teacher)
        {
            return await teacherDao.Insert(teacher);
        }
    }
}
