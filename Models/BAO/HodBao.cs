using HODPoc.Models.DAO;
using HODPoc.Models.Entities;

namespace HODPoc.Models.BAO
{
    public class HodBao
    {
        private readonly HodDao hodDao;

        public HodBao(HodDao hodDao)
        {
            this.hodDao = hodDao;
        }

        public async Task<List<Hod>> Get()
        {
            return await hodDao.Get();
        }

        public async Task<string> Insert(Hod hod)
        {
            return await hodDao.Insert(hod);
        }
    }
}
