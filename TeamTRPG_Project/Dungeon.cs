using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{

    
    internal class Dungeon
    {
        //Monster monster;

        //List<Monster> field;

        //List<Monster> MonsterList;
        static Character Player;

        public static void SetPlayer(Character player )
        {
            Player = player;
            
        }




        public static void StartWork()
        {
            ConsoleUtility.ColorWrite("���� ����", ConsoleColor.Magenta);
            Console.WriteLine("1.���� ������ ������?");
            Console.WriteLine("2.���� ��𰬴� �̱�");
            Console.WriteLine("3.�������� ����");
            Console.WriteLine("\n0.������");
            int input = ConsoleUtility.GetInput(0, 3);
            switch (input)
            {
                case 0:
                    break;
                case 1:
                    StartWork_1();
                    break;
                case 2:
                    
                    break;
                case 3:

                    break;

            }
            
        }




        public  static void PromotionBattle()
        {
            ConsoleUtility.ColorWrite("��������", ConsoleColor.Magenta);
            Console.WriteLine("1.���� - ������ ���ϴ� ����");
            Console.WriteLine("2.����� - ������ ���� (����Lv:3)");
            Console.WriteLine("3.������ڸ�(����Lv:5)");
            Console.WriteLine("4.������ڸ�(����Lv:7)");
            Console.WriteLine("5.������ڸ�(����Lv:10)");
            Console.WriteLine("\n0.������");
            int input = ConsoleUtility.GetInput(0, 5);
            switch (input)
            {
                case 0:
                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;

                case 4:

                    break;
                case 5:

                    break;
            }
        }


        public static void StartWork_1()
        {
            Console.WriteLine("[Battle]");
            Monster.SummonMonste(1);


            
        }


    }
}
