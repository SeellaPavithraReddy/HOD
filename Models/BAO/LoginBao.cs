using System.ComponentModel.DataAnnotations;
using HODPoc.DBContext;
using Microsoft.EntityFrameworkCore;

namespace HODPoc.Models.Entities
{
    public class LoginBao
    {
        private readonly LoginDao loginDao;

        public LoginBao(LoginDao loginDao)
        {
            this.loginDao = loginDao;
        }

        public async Task<List<Login>> Get()
        {
            return await loginDao.Get();
        }

        public async Task<string> Insert(Login login)
        {
            return await loginDao.Insert(login);
        }
    }
}
