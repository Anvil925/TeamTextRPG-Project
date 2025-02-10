using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    public class Battle
    {

        public static void StartBattle(Character player, List<Monster> monsters)
        {
            Console.Clear();
            Console.WriteLine("전투 시작!");

            // 몬스터 목록 출력
            Console.WriteLine("몬스터 목록:");
            for (int i = 0; i < monsters.Count; i++)
            {
                ConsoleUtility.ColorWrite(monsters[i].ToString(), ConsoleColor.Cyan);
            }

            bool battleEnded = false;
            while (!battleEnded)
            {
                Console.WriteLine("1. 공격");
                Console.WriteLine("2. 스킬");
                Console.WriteLine("3. 아이템 사용");
                Console.WriteLine("4. 도망가기");
                Console.Write("선택: ");
                int action = ConsoleUtility.GetInput(1, 4);  // 유효한 입력 처리

                switch (action)
                {
                    case 1:
                        PlayerAttack(player, monsters);
                        MonsterAttack(player, monsters);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        Console.WriteLine("도망쳤습니다!");
                        battleEnded = true;
                        break;
                }

                if (!battleEnded)
                {
                }

                battleEnded = monsters.All(m => m.HP <= 0);
            }

            Console.WriteLine("전투가 종료되었습니다!");
            Thread.Sleep(1000);
        }

        // 플레이어의 공격 메서드
        private static void PlayerAttack(Character player, List<Monster> monsters)
        {
            Console.Clear();
            Console.WriteLine("공격할 몬스터를 선택하세요:");
            for (int i = 0; i < monsters.Count; i++)
            {
                ConsoleUtility.ColorWrite($"{i + 1}. {monsters[i]}", ConsoleColor.Cyan); // 몬스터 목록 출력
            }

            int targetIndex = ConsoleUtility.GetInput(1, monsters.Count) - 1; // 유효한 입력 처리
            Monster targetMonster = monsters[targetIndex]; // 선택한 몬스터

            float damage = player.CalculateDamage();
            ShakeText("!!!!!", 1, 10);
            Console.WriteLine(); // 빈줄출력
            Console.WriteLine($"{targetMonster.Name}에게 {damage}의 피해를 입혔습니다!");
            targetMonster.TakeDamage((int)damage);
            Thread.Sleep(2000);
        }

        private static void MonsterAttack(Character player, List<Monster> monsters)
        {
            foreach (Monster monster in monsters)
            {
                if (monster.HP > 0)
                {
                    Console.WriteLine($"{monster.Name}가 공격을 준비 합니다!");
                    Thread.Sleep(2000);
                    ShakeText("!!!!!", 1, 10);
                    Thread.Sleep(1000);
                    Console.WriteLine(); // 빈줄출력
                    monster.AttackPlayer(player);
                    
                    Thread.Sleep(2000);
                    Console.Clear();
                    for (int i = 0; i < monsters.Count; i++)
                    {
                        ConsoleUtility.ColorWrite(monsters[i].ToString(), ConsoleColor.Cyan);
                    }
                }
            }
        }

        static void ShakeText(string text, int intensity, int duration)
        {
            Random rand = new Random();

            for (int i = 0; i < duration; i++)
            {
                int x = rand.Next(0, Console.WindowWidth - text.Length); // X축 위치 (콘솔 너비 범위 내)
                int y = rand.Next(0, Console.WindowHeight); // Y축 위치 (콘솔 높이 범위 내)

                Console.Clear();
                Console.SetCursorPosition(x, y);
                Console.Write(text);
                Thread.Sleep(50); // 0.05초 대기
                Console.Clear();
            }
        }
    }
}