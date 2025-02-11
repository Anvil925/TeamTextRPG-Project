using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    internal class SkillWindow
    {
        Character player;
        List<Skill> SkillList;

        public SkillWindow(Character player)
        {
            this.player = player;
            SkillList = new List<Skill>();
        }

        public void SkillWindowScreen()
        {
            SetSkillList();

            PrintTitle();

            PrintPlayerInfo();

            PrintSkillList();

            PrintSelect();

            int input = ConsoleUtility.GetInput(0, 1);
            if (input == 1)
            {
                LearnSkillScreen();
            }
            else
            {
                GameManager.Instance.MainScreen();
            }
        }

        // 스킬 획득 창 출력
        private void LearnSkillScreen()
        {
            PrintTitle();

            PrintPlayerInfo();

            PrintSkillList(true);

            Console.WriteLine("0. 나가기");
            int SelectCount = SkillList.Count;
            int input = ConsoleUtility.GetInput(0, SelectCount);

            if (input != 0)
            {
                GetSkill(input);
                LearnSkillScreen(); //스킬 구매 창 유지
            }
            else
            {
                SkillWindowScreen(); //스킬 구매 창 나가기
            }

        }

        private void PrintPlayerInfo()
        {
            Console.WriteLine($"플레이어 스킬 포인트 : {player.skillPoints} Point");
            Console.WriteLine();
        }

        private void GetSkill(int index)
        {
            player.AddSkill(SkillList[index - 1]);
            Thread.Sleep(1000);
        }

        // 선택 사항 출력
        private void PrintSelect()
        {
            Console.WriteLine("1. 스킬 획득하기");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        // 스킬 창 타이틀 출력
        private static void PrintTitle()
        {
            Console.Clear();
            Console.WriteLine("[스킬창]");
            Console.WriteLine();
        }


        // 직업에 맞는 스킬 리스트 설정
        private void SetSkillList()
        {
            if (player.job.JobType == Jobs.INTERN)
                return;

            switch (player.job.JobType)
            {
                case Jobs.DEVELOP:
                    SkillList = Skill.DevSkills;
                    break;
                case Jobs.PLANNING:
                    SkillList = Skill.PlanSkills;
                    break;
                case Jobs.ART:
                    SkillList = Skill.ArtSkills;
                    break;
            }
        }

        // 설정한 스킬 리스트 출력
        private void PrintSkillList(bool isLearnSkillWindow = false)
        {
            if (SkillList.Count == 0)
            {
                Console.WriteLine("인턴은 스킬을 가질 수 업습니다.");
                Thread.Sleep(1000);
                GameManager.Instance.MainScreen();
            }

            for (int i = 0; i < SkillList.Count; i++)
            {
                // 앞에 부분을 꾸며주는 문자
                string deco = (isLearnSkillWindow ? $"- {i + 1}" : "- ") + " ";
                Console.WriteLine(deco + SkillList[i].ShowInfo(true));
            }
            Console.WriteLine();
        }
    }
}
