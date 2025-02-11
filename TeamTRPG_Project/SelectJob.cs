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
            if(player == null)
                player = GameManager.Instance.Player;

            if(!IsLvOK())
                return;

            if (IsHaveJob())
                return;

            Console.Clear();
            Console.WriteLine("환영합니다. 이곳에서 전직을 할 수 있습니다.");
            Console.WriteLine("원하시는 팀을 선택해주세요.");
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
                    Job job = Job.JobList[input - 1];
                    player.SetJob(Job.JobList[input-1]);      // Character 함수 호출
                    Console.WriteLine($"축하합니다. {job.Name}팀으로 배정 되었습니다!");
                    Thread.Sleep(1000);
                    break;
            }
        }

        // 전직을 했는지 확인
        private bool IsHaveJob()
        {
            if (player.job.JobType != Jobs.INTERN)
            {
                Console.WriteLine("이미 전직을 완료하셨습니다.");
                Thread.Sleep(1000);
                return true;
            }
            return false;
        }

        // 전직에 충족되는 레벨인지 확인
        private bool IsLvOK()
        {
            if (player.LV < 3)
            {
                Console.WriteLine("아직은 전직이 불가능한 레벨입니다 ㅠㅠ");
                Thread.Sleep(1000);
                return false;
            }
            return true;
        }
    }
}
