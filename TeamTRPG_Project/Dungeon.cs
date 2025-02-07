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

        public static GameManager gm;


        static Character Player;
        public static void SetPlayer(Character player)
        {
            Player = player;
        }
        public static void SetGameManager(GameManager gameManager)
        {
            gm = gameManager;
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
                    StartWork_1(1);
                    break;
                case 2:
                    StartWork_1(2);
                    break;
                case 3:
                    StartWork_1(3);
                    break;
            }
        }

        public static void StartWork_1(int GroupID)
        {
            ConsoleUtility.Loading();
            Console.Clear();
            if (Player == null)
            {
                Console.WriteLine("Player 정보가 없습니다.");
                return;
            }
            switch (GroupID)
            {
                case 1:
                    ConsoleUtility.ColorWrite($"{Player.name}야 오늘 점심은 뭐냐?", ConsoleColor.Magenta);
                    break;
                case 2:
                    ConsoleUtility.ColorWrite("발표가 회의 10분 전인데 어떤 파일이 진짜지???;;;", ConsoleColor.Magenta);
                    break;
                case 3:
                    ConsoleUtility.ColorWrite("서버 폭파 5분전", ConsoleColor.Magenta);
                    break;

            }

            List<Monster> monsters = new List<Monster>();

            int numberOfMonsters = new Random().Next(1, 5);

            for (int i = 0; i < numberOfMonsters; i++)
            {
                Monster monster = Monster.GetRandomMonsterByGroup(GroupID); // 몬스터 그룹 1에서 랜덤 몬스터 불러오기
                if (monster != null)
                {
                    monsters.Add(monster);
                    Console.WriteLine($"{monster.Name} (이)가 나타났습니다!");
                    ConsoleUtility.ColorWrite(monster.ToString(), ConsoleColor.Cyan);
                }
            }
            int count = monsters.Count;
            do
            {
                Console.WriteLine("1. 공격");
                Console.WriteLine("2. 스킬");
                Console.WriteLine("3. 아이템사용");
                Console.WriteLine("4. 플레이어상태");
                Console.WriteLine("5. 도망가기");
                Console.Write("선택: ");
                int input = ConsoleUtility.GetInput(1, 5);
                switch (input)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        if (gm != null)
                        {
                            Console.WriteLine($"{Player.name}은 자리에서 도망쳤다....");
                            Thread.Sleep(1000);
                            gm.MainScreen();
                        }
                        else
                        {
                            Console.WriteLine("GameManager가 설정되지 않았습니다.");
                        }
                        break;
                }
            } while (count != 0 && Player.HP > 0); //




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
                    PromotionBattle_1(6);
                    break;
                case 2:
                    PromotionBattle_1(6);
                    break;
                case 3:
                    PromotionBattle_1(6);
                    break;
                case 4:
                    PromotionBattle_1(6);
                    break;
                case 5:
                    PromotionBattle_1(6);
                    break;
            }
        }
        public static void PromotionBattle_1(int GroupID)
        {
            ConsoleUtility.Loading();
            Console.Clear();
            if (Player == null)
            {
                Console.WriteLine("Player 정보가 없습니다.");
                return;
            }
            switch (GroupID)
            {
                case 1:
                    ConsoleUtility.ColorWrite("담배냄새가 자욱하다...", ConsoleColor.Magenta);
                    break;
                case 2:
                    ConsoleUtility.ColorWrite("~~~", ConsoleColor.Magenta);
                    break;
                case 3:
                    ConsoleUtility.ColorWrite("~~~", ConsoleColor.Magenta);
                    break;
                case 4:
                    ConsoleUtility.ColorWrite("~~~", ConsoleColor.Magenta);
                    break;
                case 5:
                    ConsoleUtility.ColorWrite("~~~", ConsoleColor.Magenta);
                    break;
            }
            List<Monster> monsters = new List<Monster>();
            int numberOfMonsters = new Random().Next(1, 5);
            for (int i = 0; i < numberOfMonsters; i++)
            {
                Monster monster = Monster.GetRandomMonsterByGroup(GroupID); // 몬스터 그룹 1에서 랜덤 몬스터 불러오기
                if (monster != null)
                {
                    monsters.Add(monster);
                    Console.WriteLine($"{monster.Name} (이)가 나타났습니다!");
                    ConsoleUtility.ColorWrite(monster.ToString(), ConsoleColor.Cyan);
                }
            }
            int count = monsters.Count;
            do
            {
                Console.WriteLine("1. 공격");
                Console.WriteLine("2. 스킬");
                Console.WriteLine("3. 아이템사용");
                Console.WriteLine("4. 플레이어상태");
                Console.WriteLine("5. 도망가기");
                Console.Write("선택: ");
                int input = ConsoleUtility.GetInput(1, 5);
                switch (input)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        if (gm != null)
                        {
                            Console.WriteLine($"{Player.name}은 자리에서 도망쳤다....");
                            Thread.Sleep(1000);
                            gm.MainScreen();
                        }
                        else
                        {
                            Console.WriteLine("GameManager가 설정되지 않았습니다.");
                        }
                        break;
                }
            } while (count != 0 && Player.HP > 0);
        }
    }
}