using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    class GameManager
    {
        private static GameManager _instance;
        public Character Player { get; private set; }
        public Dungeon dungeon { get; private set; }
        public SelectJob selectJob { get; private set; }
        public List<Item> ItemList { get; private set; }

        public static GameManager Instance
        {
            get
            {
                // 인스턴스가 없으면 새로 생성
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
        }

        public Shop shop;

        Item item;
        private GameManager()
        {
            dungeon = new Dungeon(); // Dungeon 객체 초기화
            Dungeon.SetPlayer(Player); // 던전에 플레이어 정보 전달
            Dungeon.SetGameManager(this); // Dungeon에 GameManager 정보 전달
            selectJob = new SelectJob(Player); // SelectJob 객체 생성
            ItemList = new List<Item>();
        }
        public void SetPlayerName(string name)
        {
            Player = new Character(name);  // Player 이름을 설정
            Dungeon.SetPlayer(Player);     // 던전에도 Player 정보 전달
        }
        public Character GetCharacter()
        {
            return Player;
        }
    public void SetShop(Shop shopInstance)
    {
        shop = shopInstance;
    }

        public void DungeonScene()
        {
            Console.Clear();
            ConsoleUtility.ColorWrite("던전 종류", ConsoleColor.Magenta);
            Console.WriteLine();
            Console.WriteLine("1. 업무시작\n\n2. 승진시험\n\n0.나가기");
            int input = ConsoleUtility.GetInput(0, 2);
            switch (input)
            {
                case 0:
                    MainScreen();
                    break;
                case 1:
                    Dungeon.DungeonTypes(input);
                    break;
                case 2:
                    Dungeon.DungeonTypes(input);
                    break;

            }
            MainScreen();

        }
        public void MainScreen()
        {
            Console.Clear();
            Console.WriteLine($"스파르타 회사에 오신 {Player.name} 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 출근하기");
            Console.WriteLine("5. 전직하기");
            Console.WriteLine();

            int input = ConsoleUtility.GetInput(0, 5);

            switch (input)
            {
                case 0:
                    MainScreen(); //정보 변경 새로 만들어야함.
                    break;
                case 1:
                    StatusScreen();
                    break;
                case 2:
                    SelectInventory();
                    break;
                case 3:
                    shop.DisplayShop();
                    break;
                case 4:
                    DungeonScene();
                    break;
                case 5:
                    SelectJobScreen();
                    break;
            }
        }

        private void SelectInventory()
        {
            while (true)
            {
                Console.Clear();
                ConsoleUtility.ColorWrite("인벤토리", ConsoleColor.Magenta);
                Console.WriteLine("1. 무기\n2. 방어구\n3. 포션\n\n0. 나가기\n");

                int decision = ConsoleUtility.GetInput(0, 3);
                if (decision == 0)
                {
                    MainScreen();
                    return;
                }

                InventoryScreen(decision);

               
            }
        }
        private void Displayitems(ItemType itemType)
        {
            if (Player.inventory == null || Player.inventory.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어 있습니다.");
                return;
            }

            foreach (var item in Player.inventory)
            {
                if (item.ItemType == itemType)  // 아이템 타입을 필터링
                {
                    Console.WriteLine(item.ShowInfo());
                }
            }
        }
        private void SelectJobScreen()
        {
            selectJob.JobScreen();
            MainScreen();
        }

        public void StatusScreen() //상태창 화면
        {
            ConsoleUtility.Loading();

            Console.Clear();
            ConsoleUtility.ColorWrite("상태 보기", ConsoleColor.Magenta);
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();

            Player.ShowInfo();

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            ConsoleUtility.GetInput(0, 0);
            MainScreen();
        }

        public void InventoryScreen(int decision) //인벤토리 화면
        {
            ConsoleUtility.Loading();
            ShopCase Value = (ShopCase)decision;

            Console.Clear();
            ConsoleUtility.ColorWrite($"인벤토리 - [{Value}]", ConsoleColor.Magenta);
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            switch (Value)
            {
                case ShopCase.무기:
                    Displayitems(ItemType.ATK);
                    break;
                case ShopCase.방어구:
                    Displayitems(ItemType.DEF);
                    break;
                case ShopCase.포션:
                    Displayitems(ItemType.POTION);
                    break;

            }
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int input = ConsoleUtility.GetInput(0, 1);
            switch (input)
            {
                case 0:
                    MainScreen();
                    break;
                case 1:
                    EquipScreen(Value);
                    break;
            }
        }

        public void EquipScreen(ShopCase Value) //장착 화면
        {
            Console.Clear();

            Dictionary<ShopCase, ItemType> typeMapping = new Dictionary<ShopCase, ItemType>
            { 
                { ShopCase.무기, ItemType.ATK },
                { ShopCase.방어구, ItemType.DEF },
                { ShopCase.포션, ItemType.POTION }
            };
            
            ItemType Ivalue = typeMapping[Value];

            ConsoleUtility.ColorWrite($"인벤토리 - 장착 관리 [{Value}]", ConsoleColor.Magenta);

            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            List<Item> filteredItems = Player.inventory
                   .Where(item => item.ItemType == Ivalue)
                   .ToList();
            if (filteredItems.Count == 0)
            {
                Console.WriteLine("해당 유형의 아이템이 없습니다.");
                Console.WriteLine("\n0. 나가기\n");
                ConsoleUtility.GetInput(0, 0);
                MainScreen();
                return;
            }

            // 필터링된 아이템에 1부터 번호 매기기
            for (int i = 0; i < filteredItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {filteredItems[i].ShowInfo()}");
            }

            Console.WriteLine("\n0. 나가기\n");
            int input = ConsoleUtility.GetInput(0, filteredItems.Count);

            if (input == 0)
            {
                MainScreen();
            }
            else
            {
                Equip(input, Value, filteredItems);
            }
        }
        

        public void Equip(int input, ShopCase Value, List<Item> filteredItems) //아이템 장착
        {
            Item select = filteredItems[input - 1]; // -1을 해주는 이유는 위에 표기시 i+1로 진행했기 때문입니다.

            foreach (var item in Player.inventory)
            {
                if (item.IsEquip && item.ItemType == select.ItemType && item != select)
                {
                    Player.UnEquip(item);
                }
            }
            Player.EquipItem(select);
            EquipScreen(Value); // 다시 장착 화면으로 이동 (업데이트된 상태)
        }
    }
}
