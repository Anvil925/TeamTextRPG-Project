﻿using System;
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
        Character character;
        GameManager gm;
        Item item;
        ItemList itemlist = new ItemList();

        public void temporary_Method()
        {
            string _Purchase = weapon.IsPurchase ? "구매 완료" : $"{item.Price}";
        }
        public void DisplayShop()
        {
            Console.Clear();
            Console.WriteLine("상점 목록");
            Console.WriteLine("1. 무기\n2. 방어구\n3.포션\n");
            int choice = ConsoleUtility.GetInput(1, 3);
            ShopScreen(choice);
        }

        public void ShopScreen(int choice) // 상점 화면 
        {
            ShopCase Value = (ShopCase)choice;
            int value = choice;
            Console.Clear();
            ConsoleUtility.ColorWrite("상점", ConsoleColor.Magenta);
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다. [0]", Value);
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{character.gold}G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            //상점 목록
            for (int i = 0; i < itemlist.Items[choice].Count; i++)
            {
                Console.WriteLine($"- {item.ShowInfo} | {temporary_Method}");
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
                    buyScreen(choice);
                    break;
            }
        }
        private void buyScreen(int choice, bool needGold = false, bool hasItem = false)
        {

            Console.Clear();
            ConsoleUtility.ColorWrite("상점 - 아이템 구매", ConsoleColor.Magenta);
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{character.gold}G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < itemlist.Items.Count; i++)
            {
                Console.WriteLine($"- {i + 1}. {item.ShowInfo()} | {temporary_Method}");
            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            if (needGold)
                Console.WriteLine("골드가 부족합니다!!");
            else if (hasItem)
                Console.WriteLine("이미 보유한 아이템입니다!!");

            int input = ConsoleUtility.GetInput(0, itemlist.Items[choice].Count);
            switch (input)
            {
                case 0:
                    gm.MainScreen();
                    break;
                default:
                    Item select = itemlist.Items[choice][input - 1];

                    if (character.inventory.Contains(select))
                        buyScreen(choice, false, true); //아이템이 이미 보유중이라는 메세지 표기
                    else
                        buy(select, choice); //아이템 구매 시도
                    break;
            }
        }
        private void buy(Item item, int choice)
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
    }
}
