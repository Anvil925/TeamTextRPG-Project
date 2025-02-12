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
                        MonsterAttack(player, monsters);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        player.ShowInfo();
                        break;
                    case 5:
                        Console.WriteLine("도망쳤습니다!"); // 이 부분 현재 오류발생 던전씬으로 가지지만 던전에서 도망가기가 불가능 무한 루프
                        battleEnded = true;
                        Dungeon.DungeonTypes(1); // 던전으로 돌아가기 (메인 씬으로 가는 코드)
                        break;
                }
                if (!battleEnded)
                {
<<<<<<< Updated upstream
=======
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    player.GetExp(monsters.Sum(m => m.EXP)); // 경험치 획득
                    player.gold += monsters.Sum(m => m.Gold); // 골드 획득
                    Console.ResetColor();
                    battleEnded = true; // 전투 종료
>>>>>>> Stashed changes
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
                Console.WriteLine($"{targetMonster.Name}을(를) 처치했습니다!");
                player.GetExp(targetMonster.EXP);
                player.gold += targetMonster.Gold;
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
        // 스킬 사용 2.번 스킬을 선택하였을때 사용가능한 스킬 목록을 보여주고 선택하게한다.
        // 스킬을 사용하면 스킬의 데미지를 계산하여 몬스터에게 데미지를 입힌다.
        // private static void UseSkill(Character player, List<Monster> monsters)
        // {
        //     Console.Clear();
        //     Console.WriteLine("사용할 스킬을 선택하세요:");
        //     for (int i = 0; i < player.Skills.Count; i++) // 플레이어의 스킬 목록 출력
        //     {
        //         Console.WriteLine($"{i + 1}. {player.Skills[i]}"); // 스킬 목록 출력
        //     }
        //     int skillIndex; // 사용할 스킬 인덱스
        //     do 
        //     {
        //         Console.Write("사용할 스킬 번호를 입력하세요: ");
        //         skillIndex = ConsoleUtility.GetInput(1, player.Skills.Count) - 1; 
        //     } while (skillIndex < 0 || skillIndex >= player.Skills.Count);
        //     Skill skill = player.Skills[skillIndex];
        //     Console.WriteLine($"{skill.Name} 스킬을 사용합니다!");
        //     float damage = player.CalculateSkillDamage(skill);
        //     ShakeText("!!!!!", 1, 10);
        //     Console.WriteLine(); // 빈줄출력
        //     Console.WriteLine($"{skill.Name} 스킬로 {damage}의 피해를 입혔습니다!");
        //     foreach (Monster monster in monsters)
        //     {
        //         monster.TakeDamage((int)damage);
        //         if (monster.IsDead())
        //         {
        //             Console.ForegroundColor = ConsoleColor.Yellow;
        //             Console.WriteLine($"{monster.Name}을(를) 처치했습니다! 🎉");
        //             Console.ResetColor();
        //             Thread.Sleep(2000);
        //         }
        //     }
        //     Thread.Sleep(2000);
        // }
        // 3. 번 아이템 사용을 선택하였을때 사용가능한 아이템 목록을 보여주고 선택하게한다.
        // 아이템을 사용하면 해당 아이템 효과를 사용한다.
        // private static void UseItem(Character player, List<Monster> monsters)
        // {
        //     Console.Clear();
        //     Console.WriteLine("사용할 아이템을 선택하세요:");
        //     for (int i = 0; i < player.Items.Count; i++) // 플레이어의 아이템 목록 출력
        //     {
        //         Console.WriteLine($"{i + 1}. {player.Items[i]}"); // 아이템 목록 출력
        //     }
        //     int itemIndex; // 사용할 아이템 인덱스
        //     do 
        //     {
        //         Console.Write("사용할 아이템 번호를 입력하세요: ");
        //         itemIndex = ConsoleUtility.GetInput(1, player.Items.Count) - 1; 
        //     } while (itemIndex < 0 || itemIndex >= player.Items.Count);
        //     Item item = player.Items[itemIndex];
        //     Console.WriteLine($"{item.Name} 아이템을 사용합니다!");
        //     item.Use(player);
        //     player.Items.Remove(item);
        //     Thread.Sleep(2000);
        // }

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