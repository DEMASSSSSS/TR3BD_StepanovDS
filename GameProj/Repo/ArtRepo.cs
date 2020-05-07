using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProj.Models;

namespace GameProj.Repo
{
    class ArtRepo : BaseRepo<ARTIST>
    {
        public void ArtUpdate(object obj)
        {
            if (obj is ARTIST art && art.ARTST_ID != 0)
            {
                var newart = GetOne(art.ARTST_ID);
                newart.FIO_ARTST = art.FIO_ARTST;
                newart.PASSPORT_ARTST = art.PASSPORT_ARTST;
                newart.SALARY_ARTST = art.SALARY_ARTST;
                newart.TEAM_ID_ARTST = art.TEAM_ID_ARTST;
                SaveChanges();
            }
            else
                return;
        }
    }
}
