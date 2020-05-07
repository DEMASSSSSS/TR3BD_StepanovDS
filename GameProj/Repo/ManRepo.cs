using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProj.Models;

namespace GameProj.Repo
{
    class ManRepo : BaseRepo<MANAGER>
    {
        public void ManUpdate(object obj)
        {
            if (obj is MANAGER man && man.MANAGER_ID != 0)
            {
                var newman = GetOne(man.MANAGER_ID);
                newman.FIO_MNG = man.FIO_MNG;
                newman.SALARY_MNG = man.SALARY_MNG;
                SaveChanges();
            }
            else
                return;
        }
    }
}
