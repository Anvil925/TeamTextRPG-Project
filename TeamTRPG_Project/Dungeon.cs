using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    internal class Dungeon
    {
        Monster monster;

        static Character Player;
        public static void SetPlayer(Character player)
        {
            Player = player;
        }
        public static void StartWork()
        {
            Console.Clear();
            ConsoleUtility.ColorWrite("어떤 업무를 해야할까?", ConsoleColor.Magenta);
            Console.WriteLine("1.꼰대 차장의 오점뭐?");
            Console.WriteLine("2.파일 어디갔니 미궁");
            Console.WriteLine("3.서버실의 열기");
            Console.WriteLine("\n0.나가기");
            int input = ConsoleUtility.GetInput(0, 3);
            switch (input)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
            
        }
        public static void PromotionBattle()
        {
            Console.Clear();
            ConsoleUtility.ColorWrite("승진은 어려운 법!", ConsoleColor.Magenta);
            Console.WriteLine("1.흡연실 - 승진을 원하는 동료");
            Console.WriteLine("2.탕비실 - 무능한 간부 (권장Lv:3)");
            Console.WriteLine("3.부장님자리(권장Lv:5)");
            Console.WriteLine("4.부장님자리(권장Lv:7)");
            Console.WriteLine("5.부장님자리(권장Lv:10)");
            Console.WriteLine("\n0.나가기");
            int input = ConsoleUtility.GetInput(0, 5);
            switch (input)
            {
                case 0:
                    break;
                case 1:
                    PromotionBattle1();
                    break;
                case 2:  
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }
        public static void PromotionBattle1()
        {
            Console.Clear();
            ConsoleUtility.ColorWrite("담배냄새가 자욱하다...", ConsoleColor.Magenta);
            // 승진시험 첫 번째 단계에서 싸울 몬스터를 불러옵니다.
            Monster monster = Monster.GetRandomMonsterByGroup(1); // 1은 승진시험의 첫 번째 단계
            if (monster != null)
            {
                Console.WriteLine($"{monster.Name} (이)가 나타났습니다!");
                // 몬스터와의 전투 시작
            }
            else
            {
                Console.WriteLine("승진시험에서 몬스터가 나타나지 않았습니다.");
            }
            while (true)
            {
                Console.WriteLine("1. 공격");
                Console.WriteLine("2. 스킬");
                Console.WriteLine("3. 아이템사용");
                Console.WriteLine("4. 플레이어상태");
                Console.WriteLine("5. 도망가기");
                Console.Write("선택: ");
                 int input = ConsoleUtility.GetInput(0, 5);
                switch (input)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;                        
                    case 4:
                        break;
                    case 5:
                        break;
                }
            }
        }
    }
}