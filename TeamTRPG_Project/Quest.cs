using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    using System;
    using System.Collections.Generic;

    namespace TeamTRPG_Project
    {
        public class Quest
        {
            public string Name { get; private set; }
            public string Description { get; private set; }
            public bool IsCompleted { get; private set; }

            public Quest(string name, string description)
            {
                Name = name;
                Description = description;
                IsCompleted = false;
            }

            public void CompleteQuest()
            {
                IsCompleted = true;
                Console.WriteLine($"퀘스트 완료: {Name}");

                //보상 지급 로직

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

            public List<Quest> MainQuests = new List<Quest>();

            private QuestManager()                // 기본 메인 퀘스트 추가
            {
                MainQuests.Add(new Quest("흡연실", "흡연실 던전을 클리어하세요."));
            }

            public void CheckQuestCompletion(int dungeonClears)
            {
                foreach (var quest in MainQuests)
                {
                    if (!quest.IsCompleted && dungeonClears >= 1) //퀘스트 목표 설정 추가
                    {
                        quest.CompleteQuest();
                    }
                }
            }
        }
    }

}
