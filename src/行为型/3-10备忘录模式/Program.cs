namespace _3_10备忘录模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //点击游戏---打boos

            Player player = new Player();
            player.GuanQia = 9;
            player.Life = 100;
            player.Attach = 100;
            player.Experience = 100;

            player.ShowProerty();
            Console.WriteLine("************************************");
            player.FigthBass();
            Console.WriteLine("开始");
            player.ShowProerty();

            Console.WriteLine("结束");

            Console.ReadLine();
        }
    }

    public class Player
    {
        public int GuanQia { get; set; }

        public int Life { get; set; }

        public int Attach { get; set; }

        public int Experience { get; set; }

        public void ShowProerty()
        {

            Console.WriteLine("游戏当前相关信息");
            Console.WriteLine(this.GuanQia);
            Console.WriteLine(this.Life);
            Console.WriteLine(this.Attach);
            Console.WriteLine(this.Experience);
        }

        public void FigthBass()
        {
            Life = 0;
            Attach = 50;
            Experience = 50;
        }

        public void RecoveryGame(Player player)
        {
            Life = player.Life;
            Attach = player.Attach;
            Experience = player.Experience;
            GuanQia = player.GuanQia;
        }
    }
}