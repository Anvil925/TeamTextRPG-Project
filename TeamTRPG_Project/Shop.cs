using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TeamTRPG_Project
{
    enum ShopCase
    {
        무기 = 1,
        방어구,
        포션
    }

    class Shop
    {
        Weapon weapon;
        Character character = new Character("");
        GameManager gm;
        private ItemList itemlist = ItemList.Instance();
        public Shop(GameManager gameManager)
        {
            gm = gameManager;
            character = gm.GetCharacter();
        }
        public void DisplayShop()
        {
            Console.Clear();
            Console.WriteLine("상점 목록\n");
            Console.WriteLine("1. 무기\n2. 방어구\n3. 포션\n4.아이템 판매\n\n0. 나가기\n");
            int choice = ConsoleUtility.GetInput(0, 4);
            switch(choice)
            {
                case 0:
                    gm.MainScreen();
                    break;
                case 1:
                case 2:
                case 3:
                    ShopScreen(choice);
                    break;
                case 4:
                    SellingScreen();
                    break;
                default:
                    gm.MainScreen();
                    break;
            }
            gm.MainScreen();


        }

        public void ShopScreen(int choice) // 상점 화면 
        {
            ShopCase Value = (ShopCase)choice;
            Console.Clear();
            ConsoleUtility.ColorWrite("상점", ConsoleColor.Magenta);
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다. [{0}]", Value);
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{character.gold}G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            var currentItem = itemlist.Items[choice - 1];

            //상점 목록
            for (int i = 0; i < currentItem.Count; i++)
            {
                Console.WriteLine($"- {currentItem[i].ShowInfo(true)}");
            }

            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int input = ConsoleUtility.GetInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayShop();
                    break;
                case 1:
                    buyScreen(choice);
                    break;

            }
        }
        private void buyScreen(int choice, bool needGold = false, bool hasItem = false) // 구매씬
        {

            Console.Clear();
            ConsoleUtility.ColorWrite("상점 - 아이템 구매", ConsoleColor.Magenta);
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{character.gold}G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            var currentItem = itemlist.Items[choice - 1];

            for (int i = 0; i < currentItem.Count; i++)
            {
                Console.WriteLine($"- {i + 1}. {currentItem[i].ShowInfo(true)}");
            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            if (needGold)
                Console.WriteLine("골드가 부족합니다!!");
            else if (hasItem)
                Console.WriteLine("이미 보유한 아이템입니다!!");

            int input = ConsoleUtility.GetInput(0, itemlist.Items[choice - 1].Count);
            switch (input)
            {
                case 0:
                    ShopScreen(choice);
                    break;
                default:
                    Item select = itemlist.Items[choice - 1][input - 1];

                    if (character.inventory.Contains(select))
                        buyScreen(choice, false, true); //아이템이 이미 보유중이라는 메세지 표기
                    else
                        buy(select, choice); //아이템 구매 시도
                    break;
            }
        }
        private void buy(Item item, int choice) // 구매
        {

            //골드가 충분할때 
            if (character.gold >= item.Price)
            {
                character.gold -= item.Price;
                item.IsPurchase = true;
                character.inventory.Add(item);
                buyScreen(choice);
            }
            else //골드가 부족할때
            {
                buyScreen(choice, true, false); //골드가 부족하다는 메세지 표기
            }
        }

        private void SellingScreen()
        {
            Console.Clear();
            ConsoleUtility.ColorWrite("상점 - 아이템 판매", ConsoleColor.Magenta);
            Console.WriteLine("인벤토리 아이템 목록입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{character.gold}G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            if (character.inventory.Count == 0)
            {
                Console.WriteLine("인벤토리 아이템이 없습니다.");

            }
            else
            {
                int index = 1;
                foreach (var item in character.inventory)
                {
                    //아이템 번호 및 이름 효과 설명 , 그리고 판매금액 원래 상점가 보다 15% 할인 판매

                    Console.WriteLine($"  {index} | {(item.IsEquip ? "[E]" : "")} | {item.Name} | {item.ItemType}| {item.Description} | 판매금액 {item.Price * 0.85}");
                    index++;
                }
                Console.WriteLine("판매할 아이템을 번호를 입력하세요.");
                int itemChoice;
                if (int.TryParse(Console.ReadLine(), out itemChoice) && itemChoice >= 1 && itemChoice <= character.inventory.Count)
                {
                    var selectedItem = character.inventory[itemChoice - 1];
                    Console.WriteLine($"{selectedItem.Name}을(를) {selectedItem.Price * 0.85} 골드에 판매하시겠습니까? (Y/N)");

                    string confirm = Console.ReadLine();

                    if (confirm.ToUpper() == "Y") //입력을  받아서 대문자로변경 Y이면 판매
                    {
                        character.UnEquip(selectedItem);
                        character.gold += (int)(selectedItem.Price * 0.85); // 골드 추가
                        //selectedItem.ItemBuy = false; // 
                        selectedItem.IsPurchase = false; // 상점에서 아이템 구매 여부를 다시 false로 주면서 상점을 다시 입장하면 구매완료가 안뜨도록 로직설계
                        character.inventory.RemoveAt(itemChoice - 1); // 아이템 삭제


                        Console.WriteLine($"{selectedItem.Name}을(를) 판매했습니다! 현재 골드: {character.gold}");
                       
                    }
                    else
                    {
                        Console.WriteLine("판매를 취소했습니다.");
                        
                    }

                }

            }
            Thread.Sleep(2000);

        }


    }
}
