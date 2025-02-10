using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    internal class GameManager
    {
        Character Player;
        List<Item> ItemList;
        Shop shop = new Shop();


        Dungeon dungeon;
        SelectJob selectJob;
        public GameManager(string name)
        {
            Player = new Character(name);
            dungeon = new Dungeon(); // Dungeon 객체 초기화
            Dungeon.SetPlayer(Player); // 던전에 플레이어 정보 전달
            Dungeon.SetGameManager(this); // Dungeon에 GameManager 정보 전달
            selectJob = new SelectJob(Player); // SelectJob 객체 생성
            ItemList = new List<Item>();
        }


        public void DoungeonScene()
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
            Console.WriteLine("5. 회복아이템");
            Console.WriteLine("6. 전직하기");
            Console.WriteLine();

            int input = ConsoleUtility.GetInput(0, 6);

            switch (input)
            {
                case 0:
                    MainScreen(); //정보 변경 새로 만들어야함.
                    break;
                case 1:
                    StatusScreen();
                    break;
                case 2:
                    InventoryScreen();
                    break;
                case 3:
                    shop.DisplayShop();
                    break;
                case 4:
                    DoungeonScene();
                    break;
                case 5:
                    //포션
                    break;
                case 6:
                    SelectJobScreen();
                    break;
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

        public void InventoryScreen() //인벤토리 화면
        {
            ConsoleUtility.Loading();

            Console.Clear();
            ConsoleUtility.ColorWrite("인벤토리", ConsoleColor.Magenta);
            Console.WriteLine("보유 중인 아아템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            // inventory에 있는 item들에 대한 출력
            for (int i = 0; i < Player.inventory.Count; i++)
            {
                //Console.WriteLine(Player.inventory[i].ItemDisplay());
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
                    EquipScreen();
                    break;
            }
        }

        public void EquipScreen() //장착 화면
        {
            Console.Clear();
            ConsoleUtility.ColorWrite("인벤토리 - 장착 관리", ConsoleColor.Magenta);

            Console.WriteLine("보유 중인 아아템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            // inventory에 있는 item들에 대한 출력
            for (int i = 0; i < Player.inventory.Count; i++)
            {
                //  Console.WriteLine($"{i + 1}. {Player.inventory[i].ItemDisplay()}");
            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int input = ConsoleUtility.GetInput(0, Player.inventory.Count); //입력값의 제한이 소지한 아이템의 갯수만큼 증가
            switch (input)
            {
                case 0:
                    MainScreen();
                    break;
                default:  //0이 아닌 값은 아이템을 선택했을 경우
                    Equip(input); //아이템 장착
                    break;
            }
        }

        public void Equip(int input) //아이템 장착
        {
            Item select = Player.inventory[input - 1]; // -1을 해주는 이유는 위에 표기시 i+1로 진행했기 때문입니다.

            for (int i = 0; i < Player.inventory.Count; i++)
            {
                //인벤토리 아이템들 중에서 이미 장착중이고(&&) 아이템 타입이 같고(&&) inventory[i]와 select가 다를경우, 해당 장비 해제
                //if (Player.inventory[i].IsEquip && (Player.inventory[i].ItemType == select.ItemType) && (Player.inventory[i] != select))
                //    //Player.UnEquip(Player.inventory[i]);
            }

            //아이템 장착
            Player.EquipItem(select);
            //다시 장착화면으로 가서 업데이트
            EquipScreen();
        }
    }
}
