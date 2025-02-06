using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    internal class GameManager
    {
        //Player Player;
        //List<Item> ItemList;
        //List<Item> Inventory = new List<Item>();

        public GameManager() 
        {
            //player = new Player(~플레이어 정보);
            //ItemList = new List<Item>();
            {
                ///아이템 정보
            };


        }
       
        public void MainScreen()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine();

            
        }
    }
}
