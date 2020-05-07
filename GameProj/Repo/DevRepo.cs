using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProj.Models;

namespace GameProj.Repo
{
    class DevRepo : BaseRepo<DEVELOPER>
    {
        public dynamic DevRate()
        {
            return (GetAll().Join(Context.GAMES,
                d => d.TEAM_ID_DVLP,
                g => g.TEAM_ID_DVLP,
                (d, g) => new
                {
                    FIO = d.FIO_DVLP,
                    LNG = d.LNG,
                    NameGame = g.NAME,
                    Rate = g.RATE
                }).OrderByDescending(g=>g.Rate)).ToList();
        }

        public ObjectResult<SelectLan_Result> SelectLan(string lan)
        {
            var lanParameter = lan != null ?
                new ObjectParameter("lan", lan) :
                new ObjectParameter("lan", typeof(string));

            return ((IObjectContextAdapter)Context).ObjectContext.ExecuteFunction<SelectLan_Result>("SelectLan", lanParameter);
        }

        public void DevUpdate(object obj)
        {
            if (obj is DEVELOPER dev && dev.DVLP_ID != 0)
            {
                var newdev = GetOne(dev.DVLP_ID);
                newdev.FIO_DVLP = dev.FIO_DVLP;
                newdev.EDUCATION = dev.EDUCATION;
                newdev.SALARY_DVLP = dev.SALARY_DVLP;
                newdev.LEADER = dev.LEADER;
                newdev.TEAM_ID_DVLP = dev.TEAM_ID_DVLP;
                newdev.LNG = dev.LNG;
                newdev.PASSPORT_DVLP = dev.PASSPORT_DVLP;
                newdev.EXPERIENCE = dev.EXPERIENCE;
                SaveChanges();
            }
            else
                return;

        }

    }
}
