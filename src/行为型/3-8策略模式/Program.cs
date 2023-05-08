namespace _3_8策略模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RealDuck realDuck = new RealDuck();
            ToyDuck toyDuck = new ToyDuck();
            realDuck.PerformBark();
            realDuck.PerformFly();

            toyDuck.PerformBark();
            toyDuck.PerformFly();
            Console.ReadLine();
        }
    }


    public interface IFly
    {

        object Fly();
    }

    public class FlyWithWings : IFly
    {
        public object Fly()
        {

            return "翅膀";
        }
    }

    public class FlyWithMachine : IFly
    {
        public object Fly()
        {
            return "机器";
        }
    }

    public interface IBark
    {
        object Bark();

    }

    public class BarkWithMouse : IBark
    {
        public object Bark()
        {
            return "嘴";
        }
    }

    public class BarkWithMachine : IBark
    {
        public object Bark()
        {
            return "嘴";
        }
    }

    public class Duck
    {
        private IFly _fly;
        private IBark _bark;

        public void PerformFly()
        {
            Console.WriteLine(this._fly.Fly());
        }

        public void PerformBark()
        {
            Console.WriteLine(this._bark.Bark());
        }

        public void SetFly(IFly fly)
        {
            this._fly = fly;
        }

        public void SetBark(IBark bark)
        {
            this._bark = bark;
        }
    }

    public class RealDuck : Duck
    {
        /// <summary>
        /// 调用自己合适的策略/方法
        /// </summary>
        public RealDuck()
        {
            //相当于创建对象的时候，给自己装上了翅膀，装上了嘴
            base.SetFly(new FlyWithWings());
            base.SetBark(new BarkWithMouse());
        }
    }

    public class ToyDuck : Duck
    {
        public ToyDuck()
        {
            base.SetFly(new FlyWithMachine());
            base.SetBark(new BarkWithMachine());
        }
    }

}