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
                        StartWork(1, 1);
                        break;
                    case 2:
                        StartWork(2, 1);
                        break;
                    case 3:
                        StartWork(3, 1);
                        break;
                }
            }
            else if (input == 2)
            {
                ConsoleUtility.ColorWrite("승진은 어려운 법!", ConsoleColor.Magenta);
                Console.WriteLine("1.흡연실 - 승진을 원하는 동료");
                Console.WriteLine("2.탕비실 - 무능한 간부 (권장Lv:3)");
                Console.WriteLine("3.팀장실 - 보고서의 전쟁 (권장Lv:5)");
                Console.WriteLine("4.차장실 - 꼰대의 성벽 (권장Lv:7)");
                Console.WriteLine("5.사장실 - 권력의 최종 시험 (권장Lv:10)");
                Console.WriteLine("\n0.나가기");
                input = ConsoleUtility.GetInput(0, 5);
                switch (input)
                {
                    case 0:
                        break;
                    case 1:
                        StartWork(4, 2);
                        break;
                    case 2:
                        StartWork(5, 2);
                        break;
                    case 3:
                        StartWork(6, 2);
                        break;
                    case 4:
                        StartWork(7, 2);
                        break;
                    case 5:
                        StartWork(8, 2);
                        break;
                }
            }
            else if (input == 3)
            {
                ConsoleUtility.ColorWrite("왠지 프로젝트와의 긴 싸움이 시작 될거 같다....", ConsoleColor.Magenta);
                ConsoleUtility.ColorWrite("험난한 프로젝트를 시작하게 됩니다. 진짜로 입장 하시겠습니까?(권장 LV.???)", ConsoleColor.Magenta);
                Console.WriteLine("1.입장한다.");
                Console.WriteLine("2.상태보기");
                Console.WriteLine("\n0.나가기");
                input = ConsoleUtility.GetInput(0, 2);
                switch (input)
                {
                    case 0:
                        break;
                    case 1:
                        StartWork(9, 3);
                        break;
                    case 2:
                        Player.ShowInfo();                        
                        break;
                }
            }
        }
        public static void StartWork(int GroupID, int BattleTypes)
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
                        ConsoleUtility.ColorWrite($"{Player.name}아 커피 좀 타와봐라!", ConsoleColor.Magenta);
                        break;
                    case 3:
                        ConsoleUtility.ColorWrite($"일을 그거 밖에 못해? 잘 좀 하자... {Player.name}아", ConsoleColor.Magenta);
                        break;
                    case 4:
                        ConsoleUtility.ColorWrite("~~~", ConsoleColor.Magenta);
                        break;
                    case 5:
                        ConsoleUtility.ColorWrite("~~~", ConsoleColor.Magenta);
                        break;
                }
            }
            else if (BattleTypes == 3)
            {
                switch (GroupID)
                {
                    case 1:
                        ConsoleUtility.ColorWrite("?????", ConsoleColor.Magenta);
                        break;
                }
            }
            List<Monster> monsters = new List<Monster>();
            HashSet<string> monsterNames = new HashSet<string>(); // 중복 체크용 HashSet
            int numberOfMonsters = new Random().Next(1, 4);
            while (monsters.Count < numberOfMonsters)
            {
                Monster monster = Monster.GetRandomMonsterByGroup(GroupID); // 랜덤 몬스터 생성
                if (monster != null && !monsterNames.Contains(monster.Name)) // 중복 체크
                {
                    monsters.Add(monster); // 몬스터 추가
                    monsterNames.Add(monster.Name); // 추가된 몬스터 이름 저장
                    Console.WriteLine($"{monster.Name} (이)가 나타났습니다!");
                    ConsoleUtility.ColorWrite(monster.ToString(), ConsoleColor.Cyan);
                }
            }
            int count = monsters.Count;
            do
            {
                Console.WriteLine("1. 전투시작");
                Console.WriteLine("2. 상태보기");
                Console.WriteLine("3. 도망가기");
                int input = ConsoleUtility.GetInput(1, 3);
                switch (input)
                {
                    case 1:
                        Battle.StartBattle(Player, monsters);
                        break;
                    case 2:
                        Player.ShowInfo();
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