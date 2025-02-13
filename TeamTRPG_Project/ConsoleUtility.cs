using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    internal class ConsoleUtility
    {

        public static int GetInput(int min, int max)
        {
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력하세요.");
                if (int.TryParse(Console.ReadLine(), out var input) && input >= min && input <= max)
                    return input;
                else
                {
                    Console.WriteLine("올바른 입력을 입력하세요.");
                }
            }
        }
        //글자 색 변경
        public static void ColorWrite(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color; //텍스트 컬러 설정
            Console.WriteLine(str);
            Console.ResetColor();
        }

        //로딩 화면
        public static void Loading()
        {
            Console.Clear();
            string[] Loading = new string[]
            {
                " ____  ____  ____  ____  ____  ____  ____  ____  ____  ____",
                "||L ||||O ||||A ||||D ||||I ||||N ||||G ||||. ||||. ||||. ||",
                "||__||||__||||__||||__||||__||||__||||__||||__||||__||||__||",
                "|/__\\||/__\\||/__\\||/__\\||/__\\||/__\\||/__\\||/__\\||/__\\||/__\\|"

            };
            foreach (var Load in Loading)
            {
                Console.WriteLine(Load);
                Thread.Sleep(200); // 0.2초 대기
            }
            Thread.Sleep(1000);
        }

        public static void Upgrading()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0;i<5; i++)
            {
                Thread.Sleep(100);
                Console.Write("두근 ");

            }
            Console.WriteLine("과연!!!!!");
            Console.ResetColor();
            Thread.Sleep(1000);
        }
        
    }
}