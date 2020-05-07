using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProj.Models;

namespace GameProj.Repo
{
    class GameRepo : BaseRepo<GAME>
    {
        public void GameUpdate(object obj)
        {
            if (obj is GAME game && game.ID_GAMES != 0)
            {
                var newgame = GetOne(game.ID_GAMES);
                newgame.NAME = game.NAME;
                newgame.STARTCREATING = game.STARTCREATING;
                newgame.ENDCREATING = game.ENDCREATING;
                newgame.PROFIT = game.PROFIT;
                newgame.TEAM_ID_DVLP = game.TEAM_ID_DVLP;
                newgame.MANAGER_ID = game.MANAGER_ID;
                newgame.RATE = game.RATE;
                SaveChanges();
            }
            else
                return;
        }

        public dynamic GetAllProject()
        {


            return (GetAll().Select(g => new
            {
                NAME = g.NAME,
                PROFIT = g.PROFIT,
                MONTH_CREATING = (g.ENDCREATING - g.STARTCREATING).Value.Days / 30

            }).OrderByDescending(n=>n.PROFIT).Distinct()).ToList();
        }
    }
}
