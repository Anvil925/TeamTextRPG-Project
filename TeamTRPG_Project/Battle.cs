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
                if (monsters[i].IsDead())
                    Console.ForegroundColor = ConsoleColor.Red; // 죽은 몬스터는 빨간색
                else
                    Console.ForegroundColor = ConsoleColor.Cyan; // 살아있는 몬스터는 기본 색상
                Console.WriteLine(monsters[i].ToString());   
            }
            Console.ResetColor();
            bool battleEnded = false;
            while (!battleEnded)
            {
                Console.WriteLine("1. 공격");
                Console.WriteLine("2. 스킬");
                Console.WriteLine("3. 아이템 사용");
                Console.WriteLine("4. 상태보기");
                Console.WriteLine("5. 도망가기");
                int action = ConsoleUtility.GetInput(1, 5);  // 유효한 입력 처리

                switch (action)
                {
                    case 1:
                        PlayerAttack(player, monsters);
                        break;
                    case 2:
                        if (player.skills.Count == 0)
                        {
                            Console.WriteLine("배운 스킬이 없습니다! 다시 선택하세요.");
                            Thread.Sleep(1000);
                            StartBattle(player, monsters);
                            continue; // while 루프의 처음으로 돌아가 다시 선택하도록 함
                        }
                        UseSkill(player, monsters);
                        break;
                    case 3:
                        Useitem(player, monsters);
                        continue; // while 루프의 처음으로 돌아가 다시 선택하도록 함
                    case 4:
                        player.ShowInfo();
                        continue; // while 루프의 처음으로 돌아가 다시 선택하도록 함
                    case 5:
                        Console.WriteLine("도망쳤습니다!"); // 이 부분 현재 오류발생 던전씬으로 가지지만 던전에서 도망가기가 불가능 무한 루프
                        battleEnded = true; // 전투 종료
                        break;
                }
                if (monsters.All(m => m.IsDead())) // 모든 몬스터가 죽었는지 확인
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("전투에서 승리했습니다!"); 
                    Console.ResetColor();
                    battleEnded = true; // 전투 종료
                }
                if (!battleEnded) // 몬스터가 살아있으면 몬스터의 공격
                {
                    MonsterAttack(player, monsters); 
                }
                if (player.HP <= 0) // 플레이어가 죽었을 때
                {
                    battleEnded = true; // 전투 종료
                    player.HP = player.MAX_HP;
                    player.MP = player.MAX_MP;
                    player.gold -= 1000;
                    // 전투 종료 후 플레이어의 HP, MP를 회복하고 1000G를 소모함
                }
                Thread.Sleep(2000);
            }
        }
        private static void PlayerAttack(Character player, List<Monster> monsters)
        {
            Console.Clear();
            Console.WriteLine("공격할 몬스터를 선택하세요:");
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].IsDead())
                    Console.ForegroundColor = ConsoleColor.Red; // 죽은 몬스터는 빨간색
                else
                    Console.ForegroundColor = ConsoleColor.Cyan; // 살아있는 몬스터는 기본 색상
                Console.WriteLine($"{i + 1}. {monsters[i]}"); // 몬스터 목록 출력
            }
            Console.ResetColor();
            int targetIndex;
            do
            {
                Console.Write("공격할 몬스터 번호를 입력하세요: ");
                targetIndex = ConsoleUtility.GetInput(1, monsters.Count) - 1; 
                if (monsters[targetIndex].IsDead())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("이미 죽은 몬스터는 공격할 수 없습니다! 다시 선택하세요.");
                    Console.ResetColor();
                }
            } while (monsters[targetIndex].IsDead()); // 죽은 몬스터면 다시 입력받음
            Monster targetMonster = monsters[targetIndex]; // 선택한 몬스터
            float damage = player.CalculateDamage();
            ShakeText("!!!!!", 1, 10);
            Console.WriteLine(); // 빈줄출력
            Console.WriteLine($"{targetMonster.Name}에게 {damage}의 피해를 입혔습니다!");
            targetMonster.TakeDamage((int)damage);
            if (targetMonster.IsDead())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{targetMonster.Name}을(를) 처치했습니다! 🎉");
                player.GetExp(targetMonster.EXP);
                Console.ResetColor();
                Thread.Sleep(2000);
            }
            Thread.Sleep(2000);
        }
        private static void MonsterAttack(Character player, List<Monster> monsters)
        {
            foreach (Monster monster in monsters)
            {
                if (monster.HP > 0)
                {
                    Console.WriteLine($"{monster.Name}(이)가 공격을 준비 합니다!");
                    Thread.Sleep(2000);
                    ShakeText("!!!!!", 1, 10);
                    Thread.Sleep(1000);
                    Console.WriteLine(); // 빈줄출력
                    monster.AttackPlayer(player);
                    Thread.Sleep(2000);
                if (player.HP <= 0)
                {
                     Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{player.name}이(가) 과로로 쓰러졌습니다!!");
                    Console.WriteLine("응급실에 이송되었습니다.\n병원비 1000G가 소모되었습니다.");;
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Console.WriteLine("다시 화이팅 하세요!");
                    Thread.Sleep(2000);
                    break;
                }
                    Console.Clear();
                    for (int i = 0; i < monsters.Count; i++)
                    {
                        if (monsters[i].IsDead())
                            Console.ForegroundColor = ConsoleColor.Red; // 죽은 몬스터는 빨간색
                        else
                            Console.ForegroundColor = ConsoleColor.Cyan; // 살아있는 몬스터는 기본 색상
                        Console.WriteLine(monsters[i].ToString());
                    }
                    Console.ResetColor();
                }
            }  
        }
        private static void UseSkill(Character player, List<Monster> monsters)
        {
            Console.Clear();
            Console.WriteLine("사용할 스킬을 선택하세요:");
            for (int i = 0; i < player.skills.Count; i++) // 플레이어의 스킬 목록 출력
            {
                Console.WriteLine($"{i + 1}. {player.skills[i]}"); // 스킬 목록 출력
            }
            int skillIndex; // 사용할 스킬 인덱스
            do 
            {
                Console.Write("사용할 스킬 번호를 입력하세요: ");
                skillIndex = ConsoleUtility.GetInput(1, player.skills.Count) - 1; 
            } while (skillIndex < 0 || skillIndex >= player.skills.Count);
            Skill skill = player.skills[skillIndex];
            Console.WriteLine($"{skill.Name} 스킬을 사용합니다!"); 
            skill.Use(player, monsters);
            Thread.Sleep(2000);
        }
        private static void Useitem(Character player, List<Monster> monsters)
        {
            Console.Clear();
            Console.WriteLine("사용할 아이템을 선택하세요:");
            for (int i = 0; i < player.inventory.Count; i++) // 플레이어의 아이템 목록 출력
            {
                Console.WriteLine($"{i + 1}. {player.inventory[i]}"); // 아이템 목록 출력
            }
            int itemIndex; // 사용할 아이템 인덱스
            Console.WriteLine("0. 나가기");
            do
            {
                Console.Write("사용할 아이템 번호를 입력하세요: ");
                itemIndex = ConsoleUtility.GetInput(0, player.inventory.Count) - 1; 
            } while (itemIndex < -1 || itemIndex >= player.inventory.Count);
            if (itemIndex == -1)
            {   
                StartBattle(player, monsters);
                return;
            }
            Item item = player.inventory[itemIndex];
            Console.WriteLine($"{item.Name} 아이템을 사용합니다!");
            player.UsePotion((Potion)item);
            Thread.Sleep(2000);
            StartBattle(player, monsters);
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