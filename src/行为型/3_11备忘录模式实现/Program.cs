namespace _3_11备忘录模式实现
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerOriginator playerOriginator = new PlayerOriginator(100, 10, 100, 100);
            playerOriginator.Show();
            Console.WriteLine("============================");
            Carataker carataker = new Carataker();
            carataker.Memento = playerOriginator.CreateMemento();

            playerOriginator.FigthBoss();
            playerOriginator.Show();
            Console.WriteLine("============================");

            playerOriginator.RecoveryMemento(carataker
                .Memento);
            playerOriginator.Show();
            Console.ReadLine();
        }
    }

    /// <summary>
    /// 备忘录的发起者
    /// 1、记录自己的相关属性、状态
    /// 2、创建备忘录对象，并且把需要的数据，需要恢复的数据，传送备忘录对象
    /// 3、调用Recovery来恢复到之前状态
    /// </summary>
    public class PlayerOriginator
    {

        public int Life { get; set; }

        public int GuanQia { get; set; }

        public int Attach { get; set; }

        public int Experience { get; set; }

        public PlayerOriginator(int life, int guanQia, int attach, int experience)
        {
            Life = life;
            GuanQia = guanQia;
            Attach = attach;
            Experience = experience;
        }

        /// <summary>
        /// 创建备忘录对象，并且将相关数据传递给备忘录对象
        /// </summary>
        public Memento CreateMemento()
        {
            return new Memento(Life, Experience);
        }

        public void RecoveryMemento(Memento memento)
        {
            this.Life = memento.Life;
            this.Experience = memento.Experience;
        }

        public void Show()
        {
            Console.WriteLine(Life);
            Console.WriteLine(GuanQia);
            Console.WriteLine(Attach);
            Console.WriteLine(Experience);
        }

        public void FigthBoss()
        {
            Console.WriteLine("开始打BOSS");
            Life = 0;
            GuanQia = 9;
            Attach = 50;
            Experience = 0;
            Console.WriteLine("打BOSS失败");
        }
    }

    /// <summary>
    /// 备忘录对象,需要记录要保存的数据
    /// </summary>
    public class Memento
    {
        public int Life { get; private set; }

        public int Experience { get; private set; }

        public Memento(int life, int experience)
        {
            Life = life;
            Experience = experience;
        }
    }

    /// <summary>
    /// 管理者 负责管理所有备忘录
    /// </summary>
    public class Carataker
    {

        public Memento Memento { get; set; }
    }
}