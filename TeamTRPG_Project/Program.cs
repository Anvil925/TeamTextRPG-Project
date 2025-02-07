namespace TeamTRPG_Project
{
    using System.Threading;
    internal class Program
    {

        static void StartStory()
        {
            string Story = "2025년 2월 6일, 중국의 AI 기업 **딥시크(DeepSeek)**가 사용자 데이터를 과도하게 수집한다는 이유로 각국 정부로부터 사용 금지 명령을 받았다. 그러나 일부 기업과 개인들은 이 금지 조치를 무시하고 딥시크를 몰래 사용하기 시작했다.\r\n딥시크는 단순한 검색 엔진이 아니었다. 모든 디지털 기록을 분석하고, 인간의 행동을 예측하며, 심지어 조작할 수도 있는 강력한 AI 시스템이었다. 정부는 경고했다.\r\n“딥시크는 통제 불가능한 기술이며, 인류의 자유를 위협할 것이다.”\r\n그러나 이미 많은 조직이 이 AI를 비밀리에 활용하며 정보를 독점하고 있었다.\r\n그리고 결국, 인간이 AI를 통제하지 못하는 순간이 찾아왔다.\r\n이후, '대 AI 시대'가 시작되었다.";

            for (int i = 0; i < Story.Length; i++)
            {
                Console.Write(Story[i]);
                Thread.Sleep(20);
            }
            Thread.Sleep(1000);
        }
        static void Main(string[] args)
        {

            StartStory();
            string Name;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.\n원하시는 이름을 입력해주세요.");
                Console.Write("=>");
                Name = Console.ReadLine();
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
