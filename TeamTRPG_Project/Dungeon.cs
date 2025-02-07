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
            ConsoleUtility.ColorWrite("업무 시작", ConsoleColor.Magenta);
            Console.WriteLine("1.꼰대 차장의 오점뭐?");
            Console.WriteLine("2.파일 어디갔니 미궁");
            Console.WriteLine("3.서버실의 열기");
            Console.WriteLine("\n0.나가기");
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
            ConsoleUtility.ColorWrite("승진시험", ConsoleColor.Magenta);
            Console.WriteLine("1.흡연실 - 승진을 원하는 동료");
            Console.WriteLine("2.탕비실 - 무능한 간부 (권장Lv:3)");
            Console.WriteLine("3.부장님자리(권장Lv:5)");
            Console.WriteLine("4.부장님자리(권장Lv:7)");
            Console.WriteLine("5.부장님자리(권장Lv:10)");
            Console.WriteLine("\n0.나가기");
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
