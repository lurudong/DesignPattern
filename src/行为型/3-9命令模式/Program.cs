namespace _3_9命令模式
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //用户---->命令下达角色
            //烧烤师傅--->命令执行角色
            //BakeMan bakeMan = new BakeMan();
            //bakeMan.BakeSheep();
            //bakeMan.BakeSheep();
            //bakeMan.BakeSheep();
            //bakeMan.BakeSheep();
            //bakeMan.BakeSheep();

            //bakeMan.BakeChicken();
            //bakeMan.BakeChicken();
            //bakeMan.BakeChicken();

            //耦合
            //1、我点的，跟你端上来的，永远都不太一样
            //2、无法撤销
            //3、用户端还要去判断存货数量


            BakeMan bakeMan = new BakeMan();
            Waiter waiter = new Waiter();

            CommondBakeSheep commondBakeSheep = new CommondBakeSheep(bakeMan);

            CommondBakeChicken commondBakeChicken = new CommondBakeChicken(bakeMan);

            waiter.SetCommand(commondBakeSheep);
            waiter.SetCommand(commondBakeSheep);
            waiter.SetCommand(commondBakeSheep);
            waiter.SetCommand(commondBakeSheep);

            //waiter.Notify();
            waiter.SetCommand(commondBakeChicken);
            waiter.Notify();
            //问题一：下单一条命令，就要Notify一次，不符合真实业务场景
            //问题二：没人去判断存货的数量（服务员）
            //问题三：没有办法撤销操作，没有记录日起信息
            Console.ReadKey();
        }
    }

    public class BakeMan
    {
        public void BakeSheep()
        {
            Console.WriteLine("烤羊肉串");
        }

        public void BakeChicken()
        {

            Console.WriteLine("烤鸡腿");
        }
    }


    /// <summary>
    /// 抽象的命令角色
    /// </summary>
    public abstract class Command
    {
        //让烧烤师傅，去执行具体的命令
        //1、需要维护一个对烧烤师傅对象的引用 
        public BakeMan BakeMan { get; set; }
        protected Command(BakeMan bakeMan)
        {
            BakeMan = bakeMan;
        }

        //2、让烧烤师傅，按照具体的执行进行烤串

        public abstract void ExecuteCommand();

    }

    /// <summary>
    /// 服务员点餐
    /// </summary>
    public class Waiter
    {

        //改动一：声明一个集合，用来存储所有命令

        private List<Command> commands = new List<Command>();
        //private Command Command { get; set; }

        public void SetCommand(Command command)
        {
            //改动二：判断数量
            if (command.GetType().Name == "CommondBakeChicken")
            {
                Console.WriteLine("鸡腿没有了。");
            }
            else
            {
                //改动一 给集合赋值
                commands.Add(command);
                Console.WriteLine($"订单信息:{command.ToString()}下单时间:{DateTime.Now},下单价格100");
            }


        }
        //改动三：实现命令的撤销操作
        public void RemoveCommand(Command command)
        {
            commands.Remove(command);
        }
        public void Notify()
        {
            //改动一
            //this.Command.ExecuteCommand();
            foreach (var command in commands)
            {
                command.ExecuteCommand();
            }
        }
    }

    /// <summary>
    /// 要执行命令
    /// </summary>
    public class CommondBakeSheep : Command
    {
        public CommondBakeSheep(BakeMan bakeMan) : base(bakeMan)
        {
        }

        public override void ExecuteCommand()
        {
            BakeMan.BakeSheep();
        }
    }

    public class CommondBakeChicken : Command
    {
        public CommondBakeChicken(BakeMan bakeMan) : base(bakeMan)
        {
        }

        public override void ExecuteCommand()
        {
            BakeMan.BakeChicken();
        }
    }

}