using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    class Shop
    {
        Character character;
        GameManager gm;
        Item item;
        public void ShopScreen() // 상점 화면 
        {

            ConsoleUtility.ColorWrite("상점", ConsoleColor.Magenta);
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{character.gold}G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            //초기에 설정한 아이템리스트들을 전부 표기
            for (int i = 0; i < item.itemList.Count; i++)
            {
                Console.WriteLine($"- {item.itemList[i].ItemDisplay()} | {item.itemList[i].GetPriceString()}");
            }

            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int input = ConsoleUtility.GetInput(0, 1);
            switch (input)
            {
                case 0:
                    gm.MainScreen();
                    break;
                case 1:
                    buyScreen();
                    break;
            }
        }
        private void buyScreen(bool needGold = false, bool hasItem = false)
        {

            Console.Clear();
            ConsoleUtility.ColorWrite("상점 - 아이템 구매", ConsoleColor.Magenta);
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{character.gold}G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < item.itemList.Count; i++)
            {
                Console.WriteLine($"- {i + 1}. {item.itemList[i].ItemDisplay()} | {item.itemList[i].GetPriceString()}");
            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            if (needGold)
                Console.WriteLine("골드가 부족합니다!!");
            else if (hasItem)
                Console.WriteLine("이미 보유한 아이템입니다!!");

            int input = ConsoleUtility.GetInput(0, item.itemList.Count);
            switch (input)
            {
                case 0:
                    gm.MainScreen();
                    break;
                default:
                    Item select = item.itemList[input - 1];

                    if (character.inventory.Contains(select))
                        buyScreen(false, true); //아이템이 이미 보유중이라는 메세지 표기
                    else
                        buy(select); //아이템 구매 시도
                    break;
            }
        }
        private void buy(Item item)
        {

        }
    }
}
