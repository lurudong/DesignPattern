namespace _2_8享元模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //共享自行车

            BikeFactory bikeFactory = new BikeFactory();
            FlyWeigthBike flyWeigthBike = bikeFactory.GetBike();
            flyWeigthBike.Ride("张三");
            flyWeigthBike.Back("张三");

            FlyWeigthBike flyWeigthBike2 = bikeFactory.GetBike();
            flyWeigthBike2.Ride("李四");

            FlyWeigthBike flyWeigthBike3 = bikeFactory.GetBike();
            flyWeigthBike3.Ride("王五");
            Console.ReadLine();
        }
    }

    public abstract class FlyWeigthBike
    {
        //内部状态 BikeId State 0--锁定中 1--骑行中
        //外部状态 用户

        public string BikeId { get; set; }

        public int State { get; set; }

        public abstract void Ride(string userName);
        public abstract void Back(string userName);
    }

    public class YellowBike : FlyWeigthBike
    {
        public YellowBike(string id)
        {
            BikeId = id;
        }
        public override void Back(string userName)
        {
            State = 0;
            Console.WriteLine($"用户{userName}归还了ID是{BikeId}的自行车");
        }
        public override void Ride(string userName)
        {
            State = 1;
            Console.WriteLine($"用户{userName}正在骑行ID是{BikeId}的自行车");
        }
    }

    public class BikeFactory
    {
        private readonly List<FlyWeigthBike> _bikePool = new List<FlyWeigthBike>();
        public BikeFactory()
        {
            for (int i = 0; i < 3; i++)
            {
                _bikePool.Add(new YellowBike(i.ToString()));
            }
        }

        public FlyWeigthBike GetBike()
        {
            for (int i = 0; i < _bikePool.Count; i++)
            {
                if (_bikePool[i].State == 0)
                {
                    return _bikePool[i];
                }
            }
            return null!;
        }
    }
}