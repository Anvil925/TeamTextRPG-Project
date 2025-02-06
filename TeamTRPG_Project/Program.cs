namespace TeamTRPG_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.\n원하시는 이름을 입력해주세요.");
                Console.Write("=>");
                string Name = Console.ReadLine();
                Console.WriteLine($"입력하신 이름은 {Name}입니다.\n1.저장 \n2.아니오");
                int save = int.Parse(Console.ReadLine());
                if (save == 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("취소되었습니다.");
                    Thread.Sleep(500);
                    continue;
                }
            }    

            
            GameManager gm = new GameManager();
            gm.MainScreen();

        }
    }
}
