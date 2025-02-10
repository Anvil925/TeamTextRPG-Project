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
        Monster? monster;

        public static GameManager gm;


        static Character? Player;
        public static void SetPlayer(Character player)
        {
            Player = player;
        }
        public static void SetGameManager(GameManager gameManager)
        {
            gm = gameManager;
        }

        public static void DungeonTypes(int input)
        {
            ConsoleUtility.Loading();
            Console.Clear();
            if (input == 1)
            {
                ConsoleUtility.ColorWrite("어떤 업무를 해야할까?", ConsoleColor.Magenta);
                Console.WriteLine("1.꼰대 차장의 오점뭐?");
                Console.WriteLine("2.파일 어디갔니 미궁");
                Console.WriteLine("3.서버실의 열기");
                Console.WriteLine("\n0.나가기");
                input = ConsoleUtility.GetInput(0, 3);
                switch (input)
                {
                    case 0:
                        break;
                    case 1:
                        Battle(1, 1);
                        break;
                    case 2:
                        Battle(2, 1);
                        break;
                    case 3:
                        Battle(3, 1);
                        break;
                }
            }
            else if (input == 2)
            {
                ConsoleUtility.ColorWrite("승진은 어려운 법!", ConsoleColor.Magenta);
                Console.WriteLine("1.흡연실 - 승진을 원하는 동료");
                Console.WriteLine("2.탕비실 - 무능한 간부 (권장Lv:3)");
                Console.WriteLine("3.부장님자리(권장Lv:5)");
                Console.WriteLine("4.부장님자리(권장Lv:7)");
                Console.WriteLine("5.부장님자리(권장Lv:10)");
                Console.WriteLine("\n0.나가기");
                input = ConsoleUtility.GetInput(0, 5);
                switch (input)
                {
                    case 0:
                        break;
                    case 1:
                        Battle(6, 2);
                        break;
                    case 2:
                        Battle(6, 2);
                        break;
                    case 3:
                        Battle(6, 2);
                        break;
                    case 4:
                        Battle(6, 2);
                        break;
                    case 5:
                        Battle(6, 2);
                        break;
                }
            }


        }

        public static void Battle(int GroupID, int BattleTypes)
        {
            ConsoleUtility.Loading();
            Console.Clear();
            if (Player == null)
            {
                Console.WriteLine("Player 정보가 없습니다.");
                return;
            }
            if (BattleTypes == 1)
            {
                switch (GroupID)
                {
                    case 1:
                        ConsoleUtility.ColorWrite($"{Player.name}아 오늘 점심은 뭐냐?", ConsoleColor.Magenta);
                        break;
                    case 2:
                        ConsoleUtility.ColorWrite("발표가 회의 10분 전인데 어떤 파일이 진짜지???;;;", ConsoleColor.Magenta);
                        break;
                    case 3:
                        ConsoleUtility.ColorWrite("서버 폭파 5분전", ConsoleColor.Magenta);
                        break;

                }
            }
            else if (BattleTypes == 2)
            {
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
                Console.WriteLine("1. 전투시작");
                Console.WriteLine("2. 플레이어상태");
                Console.WriteLine("3. 도망가기");
                Console.Write("선택: ");
                int input = ConsoleUtility.GetInput(1, 3);
                switch (input)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
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