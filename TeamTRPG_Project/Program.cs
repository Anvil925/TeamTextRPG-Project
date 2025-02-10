namespace TeamTRPG_Project
{
    using NAudio.Wave;
    using System.Threading;
    internal class Program
    {
        static void StartStory()
        {
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

        static void Main(string[] args)
        {
            StartStory();
            string Name;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 회사에 오신 여러분 환영합니다.\n원하시는 이름을 입력해주세요.");
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
