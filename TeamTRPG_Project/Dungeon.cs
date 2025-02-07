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
            ConsoleUtility.Loading();
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
            ConsoleUtility.Loading();
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
            ConsoleUtility.Loading();
            Console.Clear();
            ConsoleUtility.ColorWrite("담배냄새가 자욱하다...", ConsoleColor.Magenta);
            // 몬스터 여러 마리 생성
            List<Monster> monsters = new List<Monster>();
            int numberOfMonsters = 3;  // 예시로 3마리 몬스터 생성
            for (int i = 0; i < numberOfMonsters; i++)
            {
                Monster monster = Monster.GetRandomMonsterByGroup(1); // 몬스터 그룹 1에서 랜덤 몬스터 불러오기
                if (monster != null)
                {
                    monsters.Add(monster);
                    Console.WriteLine($"{monster.Name} (이)가 나타났습니다!");
                    ConsoleUtility.ColorWrite(monster.ToString(), ConsoleColor.Cyan);
                }
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