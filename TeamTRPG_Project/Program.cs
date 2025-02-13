namespace TeamTRPG_Project
{
    using NAudio.Wave;
    using System.Threading;
    internal class Program
    {
        static void StartStory()
        {
            Console.Clear();
            string Story = "\"네가 원하던 대기업에 드디어 입사했다!\"\r\n수많은 면접과 인적성, 그리고 그 많던 경쟁자를 제치고 당당히 입사한 너!\r\n하지만 출근 첫날, 넌 깨닫게 된다… 이 회사, 뭔가 이상하다.\r\n\r\n● 커피 한 잔 타러 갔다가, 사내 정치의 한복판에 서 있고\r\n● 보고서 한 장 쓰려다, 내 커리어가 끝날 위기에 처하며\r\n● 회의실에 들어갔을 뿐인데, 칼과 창이 난무하는 전쟁이 벌어진다.\r\n\r\n여긴 평범한 회사가 아니다.\r\n → 직급이 곧 전투력이다.\r\n → 보고서는 무기이며, 회의는 전장이다.\r\n → 상사의 눈빛은 피의 맹세를 요구하고, 인사팀의 한 마디는 생사를 결정한다.\r\n\r\n하지만 포기할 수 없다.\r\n이 험난한 회사에서 살아남고, 결국은 CEO의 자리에 오르는 것!";
            for (int i = 0; i < Story.Length; i++)
            {
                Console.Write(Story[i]);
                //Thread.Sleep(30);
                if (i % 4 == 0)
                    Console.Beep(500, 50);
            }
            Thread.Sleep(2000);
        }
        static void StartArt()
        {
            string[] StartScene = new string[]
            {
            "                       ____________________________",
            "                      |                            |",
            "                      |      [스 파 르 타]         |",
            "                      |    ┌─────────────────┐     |",
            "                      |    │  ###########    │     |",
            "                      |    │  ###########    │     |",
            "                      |    │  ###########    │     |",
            "                      |    └─────────────────┘     |",
            "                      |____________________________|",
            "                                 ||",
            "       ___________________       ||",
            "      /                  \\      ||",
            "     |   .------------.   |     ||",
            "     |   |  (●)   (●)  |   |     ||",
            "     |   |     \\_/     |   |     ||",
            "     |   |    _____    |   |     ||",
            "     |   |   /     \\   |   |     ||",
            "     |   |  |       |  |   |     ||",
            "     |   |   \\_____/   |   |     ||",
            "     |   '------------'   |     ||",
            "     |     [회사원]       |     ||",
            "      \\__________________/      ||",
            "          /   |       |        ||",
            "         /    |       |        ||",
            "        /     |       |        ||",
            "   ____/______|_______|_______||",
            "  /                       \\     ||",
            " /      [서류가방]          \\    ||",
            "/___________________________\\   ||",
            "        |     |     |     |     ||",
            "        |     |     |     |     ||",
            "        '-----'-----'-----'-----'"
            };
            foreach (var Scene in StartScene)
            {
                Console.WriteLine(Scene);
                Thread.Sleep(100); // 0.1초 대기
            }

            // 아스키 아트가 끝난 후, 사용자 입력을 대기
            Console.WriteLine("\n Salaried Worker Chronicle, 시작하려면 아무키나 눌러주세요...");
            Console.ReadKey();  // 사용자 입력 대기
        }

        static void Main(string[] args)
        {
            StartArt();
            StartStory();
            string Name;
            while (true)
            {
                ConsoleUtility.Loading();
                Console.Clear();
                Console.WriteLine("스파르타 회사에 오신 여러분 환영합니다.\n원하시는 이름을 입력해주세요.");
                Console.Write("=>");
                Name = Console.ReadLine();
                Console.WriteLine($"입력하신 이름은 {Name}입니다.\n1.저장 \n2.아니오");
                string save = Console.ReadLine();
                if (save == "1")
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

            //솔루션 -> 패키지 관리자 -> NAduio 설치 
            //mp3 파일을 bin/Debug/net9.0 에 추가할 것 (실행파일이 있는 위치)
            using (AudioFileReader audioFile = new AudioFileReader("DungeonBGM.mp3"))
            using (var outputDevice = new WaveOutEvent())
            {
                audioFile.Volume = 0.1f;
                outputDevice.Init(audioFile);

                outputDevice.Play();

                GameManager.Instance.SetPlayerName(Name);
                Shop shop = new Shop(GameManager.Instance);
                GameManager.Instance.SetShop(shop);

                GameManager.Instance.MainScreen();
                outputDevice.Stop();
            }

        }
    }
}
