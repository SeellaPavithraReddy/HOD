using System.ComponentModel.DataAnnotations;
using HODPoc.DBContext;
using Microsoft.EntityFrameworkCore;

namespace HODPoc.Models.Entities
{
    public class SubjectBao
    {
        private readonly SubjectDao subjectDao;

        public SubjectBao(SubjectDao subjectDao)
        {
            this.subjectDao = subjectDao;
        }

        public async Task<List<Subject>> Get()
        {
            return await subjectDao.Get();
        }

        public async Task<string> Insert(Subject subject)
        {
            return await subjectDao.Insert(subject);
        }
    }
}
