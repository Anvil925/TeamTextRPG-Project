using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    public class Battle
    {
        public static void StartBattle(Character player, List<Monster> monsters, int groupID)
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
                            StartBattle(player, monsters,groupID);
                            continue; // while 루프의 처음으로 돌아가 다시 선택하도록 함
                        }
                        UseSkill(player, monsters);
                        break;
                    case 3:
                        Useitem(player, monsters, groupID);
                        break;
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
                    ShowClearScreen(groupID,player);
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
            if (monsters.All(m => m.HP <= 0))
            {
                battleEnded = true;
                ShowClearScreen(groupID, player); // 던전 클리어 처리
            }
            // 플레이어가 죽으면 실패 처리
            else if (player.HP <= 0)
            {
                battleEnded = true;
            }
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
                    if (player.HP <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        ShowFailureScreen(player); // 실패 처리
                        return;
                    }
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
        // 3. 번 아이템 사용을 선택하였을때 사용가능한 아이템 목록을 보여주고 선택하게한다.
        // 아이템은 포션 종류만 보여주고 사용하면 해당 포션의 효과를 사용한다.
        // 아이템을 사용하면 해당 아이템 효과를 사용한다.
        private static void Useitem(Character player, List<Monster> monsters, int groupID)
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
                StartBattle(player, monsters, groupID);
                return;
            }
            Item item = player.inventory[itemIndex];
            Console.WriteLine($"{item.Name} 아이템을 사용합니다!");
            player.UsePotion((Potion)item);
            Thread.Sleep(2000);
            StartBattle(player, monsters, groupID);
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
        public void HandleDungeonClear(int groupID, Character player)
        {
            // 던전 클리어 처리
            ShowClearScreen(groupID, player); // 던전 ID와 player 객체를 전달
        }

        private static void ShowClearScreen(int groupID, Character player)
        {
            string dungeonName = Dungeon.GetDungeonName(groupID); // Dungeon.GetDungeonName으로 던전 이름 가져오기

            Console.Clear();
            ConsoleUtility.ColorWrite($"던전 클리어! - {dungeonName}", ConsoleColor.Green); // 던전 이름을 표시

            // 보상 처리 (예시: 경험치 및 아이템 보상)
            int expReward = 100; // 임시 보상값
            int goldReward = 50; // 임시 보상값

            player.ClearedDungeons.Add(dungeonName); // 던전 이름 추가

            Console.WriteLine($"{expReward} 경험치와 {goldReward} 골드를 획득했습니다.");

            // 결과 창에서 나가기
            Console.WriteLine("\n1. 돌아가기");
            int input = ConsoleUtility.GetInput(1, 1);
            if (input == 1)
            {
                GameManager.Instance.MainScreen(); // 메인 화면으로 돌아가기
            }
        }

        private static void ShowFailureScreen(Character player)
        {

            Console.Clear();
            Console.WriteLine($"{player.name}이(가) 과로로 쓰러졌습니다!!");
            Console.WriteLine("응급실에 이송되었습니다.\n 병원비 1000G가 소모되었습니다.");
            player.HP = player.MAX_HP;
            player.MP = player.MAX_MP;
            player.gold -= 1000;
            Console.ResetColor();
            Thread.Sleep(2000); Console.WriteLine("\n1. 돌아가기\n");
            int input = ConsoleUtility.GetInput(1, 1);
            if (input == 1)
            {
                GameManager.Instance.MainScreen(); // 메인 화면으로 돌아가기
            }
        }
    }
}