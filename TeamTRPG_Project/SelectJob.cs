using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    internal class SelectJob
    {
        public Character player;
        public SelectJob(Character player)
        {
            this.player = player;
        }

        public void JobScreen()
        {
            Console.Clear();
            Console.WriteLine("환영합니다. 이곳에서 전직을 할 수 있습니다.");
            Console.WriteLine("원하시는 직업을 선택해주세요.");
            Console.WriteLine();
            Console.WriteLine("1. 기획");
            Console.WriteLine("2. 개발");
            Console.WriteLine("3. 디자이너");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int input = ConsoleUtility.GetInput(0, 3);

            switch (input)
            {
                case 1:
                case 2:
                case 3:
                    //player.SetJob();
                    break;
            }
        }
    }
}
