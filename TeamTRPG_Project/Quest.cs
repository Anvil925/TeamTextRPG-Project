using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    public class Quest
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public int RewardGold { get; private set; }
        public string QuestProgress { get; private set; }
        public bool IsAccepted { get; private set; }

        public Action<Character> CompletionCondition;
        public Action<Character> OnAccept;
        public Action<Character> OnDecline;

        // 퀘스트 진행 상태를 추적할 변수 추가
        private int requiredProgress;

        public Quest(string name, string description, Action<Character> completionCondition,
                     int rewardGold = 0, int requiredProgress = 0,
                     Action<Character> onAccept = null, Action<Character> onDecline = null)
        {
            Name = name;
            Description = description;
            IsCompleted = false;
            RewardGold = rewardGold;
            CompletionCondition = completionCondition;
            OnAccept = onAccept;
            OnDecline = onDecline;
            IsAccepted = false;  // 초기화
            this.requiredProgress = requiredProgress;
            UpdateProgress(0); // 초기 진행 상태
        }

        // 퀘스트 진행 상태 업데이트
        public void UpdateProgress(int progress)
        {
            // 플레이어의 레벨에 맞춰 퀘스트 진행 상태를 업데이트
            int currentProgress = progress > requiredProgress ? requiredProgress : progress;
            QuestProgress = $"진행 중: {currentProgress}/{requiredProgress}";

            // 진행 상태가 완료 조건을 만족하면 퀘스트 완료 처리
            if (currentProgress >= requiredProgress)
            {
                CompleteQuest();
            }
        }

        // 퀘스트 완료 처리
        public void CompleteQuest()
        {
            if (!IsCompleted)
            {
                IsCompleted = true;
                Console.WriteLine($"{Name} 퀘스트 완료!");
                Console.WriteLine($"보상으로 {RewardGold} GOLD를 받았습니다.");
            }
            else
            {
                Console.WriteLine($"이미 완료한 퀘스트입니다: {Name}");
            }
        }

        public void AcceptQuest(Character player)
        {
            OnAccept?.Invoke(player);
            IsAccepted = true;
            Console.WriteLine($"{Name} 퀘스트가 수락되었습니다.");
        }

        public void DeclineQuest(Character player)
        {
            OnDecline?.Invoke(player);
            IsAccepted = false;
            Console.WriteLine($"{Name} 퀘스트가 거절되었습니다.");
        }
    }

    public class QuestManager
    {
        private static QuestManager instance;
        public static QuestManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QuestManager();
                }
                return instance;
            }
        }

        public List<Quest> quests;

        public QuestManager()
        {
            quests = new List<Quest>
        {
            new Quest("흡연실", "승진을 원하는 동료를 이기자!", (player) =>
            {
                if (player.ClearedDungeons.Contains("흡연실")) // 추후 연결
                {
                    Console.WriteLine("출근 완료! 첫 업무 시작!");
                    player.gold += 500;
                    player.GetExp(100);
                    Console.WriteLine("보상으로 500 GOLD와 100 EXP를 받았습니다.");
                }
            }, 500, 1), // 흡연실 던전 완료 요구

            new Quest("탕비실", "무능한 간부를 물리치자", (player) =>
            {
                if (player.ClearedDungeons.Contains("흡연실")) // 추후 연결
                {
                    Console.WriteLine("첫 업무를 성공적으로 끝냈습니다!");
                    player.gold += 800;
                    player.GetExp(150);
                    Console.WriteLine("보상으로 800 GOLD와 150 EXP를 받았습니다.");
                }
                else
                {
                    Console.WriteLine("아직 업무를 완료할 준비가 되지 않았습니다.");
                }
            }, 800, 1), // 탕비실 던전 완료 요구

            new Quest("승진", "빌런 부장님을 물리치자!", (player) =>
            {
                if (player.ClearedDungeons.Contains("부장실자리"))
                {
                    Console.WriteLine("부장님을 물리쳤습니다!");
                    player.gold += 1000;
                    player.GetExp(200);
                    Console.WriteLine("보상으로 1000 GOLD와 200 EXP를 받았습니다.");
                }
                else
                {
                    Console.WriteLine("아직 부장님께 다가갈 수 없습니다!");
                }
            }, 1000, 1), // 부장실자리 던전 완료 요구

            new Quest("회사에서의 승진", "레벨 3이 되어 승진을 준비하자!", (player) =>
            {
                // 퀘스트 진행 상황을 플레이어의 레벨로 업데이트
                foreach (var quest in quests)
                {
                    if (quest.Name == "회사에서의 승진")
                    {
                        quest.UpdateProgress(player.LV);
                    }
                }

                if (player.LV >= 3)
                {
                    Console.WriteLine("승진 조건을 충족했습니다!");
                    player.gold += 1500;
                    player.GetExp(300);
                    Console.WriteLine("보상으로 1500 GOLD와 300 EXP를 받았습니다.");
                }
                else
                {
                    Console.WriteLine("아직 승진할 준비가 되지 않았습니다.");
                }
            }, 1500, 3) // 레벨 3 요구
        };
        }

        public void ShowQuests(Character player)
        {
            while (true)
            {
                Console.Clear();
                ConsoleUtility.ColorWrite("Quest!!\n", ConsoleColor.Magenta);
                for (int i = 0; i < quests.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {quests[i].Name} {(quests[i].IsAccepted ? "(진행중)" : "")} ");
                }
                Console.WriteLine("\n0. 나가기");
                Console.WriteLine("\n원하시는 퀘스트를 선택해주세요.");
                Console.Write(">> ");
                int choice = ConsoleUtility.GetInput(0, quests.Count); // 0을 선택시 메인 화면으로 돌아감
                if (choice == 0)
                {
                    GameManager.Instance.MainScreen();
                    break; // ShowQuests 종료
                }

                Quest selectedQuest = quests[choice - 1];
                Console.Clear();
                ConsoleUtility.ColorWrite($"\n{selectedQuest.Name}\n", ConsoleColor.Cyan);
                Console.WriteLine($"{selectedQuest.Description}\n");

                Console.WriteLine($"{selectedQuest.QuestProgress}");

                // 보상 표시
                Console.WriteLine($"\n보상: {selectedQuest.RewardGold} GOLD");

                // 수락 또는 거절 옵션
                Console.WriteLine("\n1. 수락");
                Console.WriteLine("2. 거절");
                int action = ConsoleUtility.GetInput(1, 2);

                if (action == 1)
                {
                    if (!selectedQuest.IsAccepted)
                    {
                        selectedQuest.AcceptQuest(player);
                        Console.WriteLine($"{selectedQuest.Name} 퀘스트가 수락되었습니다.");
                    }
                    else
                    {
                        Console.WriteLine($"{selectedQuest.Name} 퀘스트는 이미 수락된 상태입니다.");
                    }
                }
                else if (action == 2)
                {
                    if (selectedQuest.IsAccepted)
                    {
                        selectedQuest.DeclineQuest(player);
                        Console.WriteLine($"{selectedQuest.Name} 퀘스트가 거절되었습니다.");
                    }
                    else
                    {
                        Console.WriteLine($"{selectedQuest.Name} 퀘스트는 아직 수락되지 않았습니다.");

                    }
                }
            }
        }
    }
}


