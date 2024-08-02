using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAG_Squadron;

namespace Testbench
{
    public class CombatTest
    {
        static void Main()
        {
            Player player = new Player();
            //Player CPU = new Player();
            List<CombatMAG> PlayerMAGs = new List<CombatMAG>();
            List<CombatMAG> CpuMAGs = new List<CombatMAG>();
            Game game = new Game(player);
            player.PlayerMAGs.Add(0, game.MAGMasterList[0]);
            PlayerMAGs.Add(new CombatMAG(game.MAGMasterList[0], 0));
            CpuMAGs.Add(new CombatMAG(game.MAGMasterList[0],0));
            game.Run();

        }
    }
}
