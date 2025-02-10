using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
   public class Battle
    {
        public static void StartBattle(List<Monster> monsters)
        {
            Console.Clear();
            ConsoleUtility.ColorWrite("전투 시작!", ConsoleColor.Red);
            Console.WriteLine("몬스터 목록:");

            foreach (var monster in monsters)
            {
                ConsoleUtility.ColorWrite(monster.ToString(), ConsoleColor.Cyan);
            }

            // 여기서부터 전투 로직을 구현하면 됩니다.
            // 예를 들어, 플레이어와 몬스터 간의 전투를 진행하는 방식으로 작성할 수 있습니다.
        }
    }
}