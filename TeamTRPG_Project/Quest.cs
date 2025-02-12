using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TeamTRPG_Project
{
    public enum ProgressType
    {
        DungeonClear,
        Level,
        EquipItem,
        UpgradeItem
    }

    public class Quest
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public int RewardGold { get; private set; }
        public int RewardExp { get; private set; }
        public string QuestProgress { get; private set; }
        public bool IsAccepted { get; private set; }
        public ProgressType ProgressType { get; private set; }

        public Action<Character> CompletionCondition;
        public Action<Character> OnAccept;
        public Action<Character> OnDecline;

        private int requiredProgress;
        private int currentProgress;

        public Quest(string name, string description, Action<Character> completionCondition,
                     int rewardGold = 0, int rewardExp = 0, int requiredProgress = 0, ProgressType progressType = ProgressType.DungeonClear,
                     Action<Character> onAccept = null, Action<Character> onDecline = null)
        {
            Name = name;
            Description = description;
            IsCompleted = false;
            RewardGold = rewardGold;
            RewardExp = rewardExp;
            CompletionCondition = completionCondition;
            OnAccept = onAccept;
            OnDecline = onDecline;
            IsAccepted = false;
            this.requiredProgress = requiredProgress;
            this.ProgressType = progressType;
            UpdateProgress(null);
        }

        public void UpdateProgress(Character player)
        {
            if (ProgressType == ProgressType.Level && player != null)
            {
                currentProgress = Math.Min(player.LV, requiredProgress);
            }
            else
            {
                currentProgress = Math.Min(currentProgress, requiredProgress);
            }
            QuestProgress = $"진행 중: {currentProgress}/{requiredProgress}";
        }

        public void CheckCompletion(Character player, QuestManager questManager)
        {
            UpdateProgress(player);
            if (currentProgress >= requiredProgress)
            {
                CompleteQuest(player, questManager);
            }
            else
            {
                Console.WriteLine("퀘스트 완료 조건이 충족되지 않았습니다.");
                Thread.Sleep(500);
            }
        }

        public void CompleteQuest(Character player, QuestManager questManager)
        {
            if (!IsCompleted)
            {
                IsCompleted = true;
                player.gold += RewardGold;
                player.GetExp(RewardExp);
                Console.WriteLine($"{Name} 퀘스트 완료! 보상으로 {RewardGold} GOLD를 받았습니다.");
                questManager.RemoveQuest(this);
                Thread.Sleep(500);
            }
            else
            {
                Console.WriteLine($"이미 완료한 퀘스트입니다: {Name}");
                Thread.Sleep(500);
            }
        }

        public void AcceptQuest(Character player)
        {
            OnAccept?.Invoke(player);
            IsAccepted = true;
            Console.WriteLine($"{Name} 퀘스트가 수락되었습니다.");
            Thread.Sleep(500);
        }

        public void DeclineQuest(Character player)
        {
            OnDecline?.Invoke(player);
            IsAccepted = false;
            Console.WriteLine($"{Name} 퀘스트가 거절되었습니다.");
            Thread.Sleep(500);
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
                new Quest("[M]흡연실", "승진을 원하는 동료를 이기자!", (player) =>
                {
                    if (player.ClearedDungeons.Contains("흡연실"))
                    {
                        player.gold += 1500;
                        player.GetExp(100);
                    }
                }, 500,100, 1, ProgressType.DungeonClear),

                new Quest("[M]탕비실", "본인의 업무를 떠넘기는 간부를 물리치자!", (player) =>
                {
                    if (player.ClearedDungeons.Contains("탕비실"))
                    {
                        player.gold += 5000;
                        player.GetExp(100);
                    }
                }, 500,100, 1, ProgressType.DungeonClear),
                new Quest("[M]팀장실", "대화가 통하지 않는 팀장을 처리하자!", (player) =>
                {
                    if (player.ClearedDungeons.Contains("팀장실"))
                    {
                        player.gold += 10000;
                        player.GetExp(100);
                    }
                }, 500, 100, 1, ProgressType.DungeonClear),
                new Quest("[M]차장실", "꼰대 차장을 물리치자!", (player) =>
                {
                    if (player.ClearedDungeons.Contains("흡연실"))
                    {
                        player.gold += 20000;
                        player.GetExp(100);
                    }
                }, 500, 100, 1, ProgressType.DungeonClear),
                new Quest("[M]사장실", "인권을 박살내는 사장을 물리치자!", (player) =>
                {
                    if (player.ClearedDungeons.Contains("사장실"))
                    {
                        player.gold += 50000;
                        player.GetExp(100);
                    }
                }, 500,100, 1, ProgressType.DungeonClear),

                new Quest("[S]승진", "레벨을 올려 승진을 준비하자!", (player) =>
                {
                    if (player.LV >= 3)
                    {
                        player.gold += 3500;
                        player.GetExp(35);
                    }
                }, 1500,35, 3, ProgressType.Level)
        };
        }

        public void RemoveQuest(Quest quest)
        {
            quests.Remove(quest);
        }

        public void ShowQuests(Character player)
        {
            ConsoleUtility.Loading();
            while (true)
            {
                Console.Clear();
                ConsoleUtility.ColorWrite("Quest!!\n", ConsoleColor.Magenta);
                for (int i = 0; i < quests.Count; i++)
                {
                    quests[i].UpdateProgress(player);
                    Console.WriteLine($"{i + 1}. {quests[i].Name} {(quests[i].IsAccepted ? "(진행중)" : "")}");
                }
                Console.WriteLine("\n0. 나가기");
                Console.Write("\n원하시는 퀘스트를 선택해주세요.\n>> ");
                int choice = ConsoleUtility.GetInput(0, quests.Count);
                if (choice == 0)
                {
                    GameManager.Instance.MainScreen();
                    break;
                }

                Quest selectedQuest = quests[choice - 1];
                Console.Clear();
                ConsoleUtility.ColorWrite($"\n{selectedQuest.Name}\n", ConsoleColor.Cyan);
                Console.WriteLine($"{selectedQuest.Description}\n");
                Console.WriteLine($"{selectedQuest.QuestProgress}");
                Console.WriteLine($"\n보상: {selectedQuest.RewardGold} GOLD");

                Console.WriteLine("\n1. 수락");
                Console.WriteLine("2. 거절");
                Console.WriteLine("3. 완료");
                int action = ConsoleUtility.GetInput(1, 3);

                if (action == 1)
                {
                    if (!selectedQuest.IsAccepted)
                    {
                        selectedQuest.AcceptQuest(player);
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
                    }
                    else
                    {
                        Console.WriteLine($"{selectedQuest.Name} 퀘스트는 아직 수락되지 않았습니다.");
                    }
                }
                else if (action == 3)
                {
                    selectedQuest.CheckCompletion(player, this);
                }
            }
        }
    }
}
