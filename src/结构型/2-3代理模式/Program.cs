namespace _2_3代理模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //替隔壁班的老王同学,追自己班的女同学
            //创建班花对象
            ClassFloer classFloer = new ClassFloer();
            classFloer.Name = "Test";

            //创建代理对象
            ISubject subject = new Proxy(new RealSubject(classFloer));
            subject.GiveSmoking();
            subject.GiveBeer();
            subject.GiveJk();
            Console.ReadLine();
        }
    }

    public interface ISubject
    {

        void GiveSmoking();
        void GiveBeer();
        void GiveJk();
    }


    public class ClassFloer
    {
        public string Name { get; set; }
    }

    public class RealSubject : ISubject
    {
        private ClassFloer _classFloer;
        public RealSubject(ClassFloer classFloer)
        {
            _classFloer = classFloer;
        }
        public void GiveBeer()
        {

            Console.WriteLine($"{_classFloer.Name}同学，请你喝酒！！！");
        }

        public void GiveJk()
        {
            Console.WriteLine($"{_classFloer.Name}同学，请你穿JK！！！");
        }

        public void GiveSmoking()
        {
            Console.WriteLine($"{_classFloer.Name}同学，请你穿抽烟！！！");
        }
    }

    public class Proxy : ISubject
    {
        private readonly RealSubject _realSubject;

        public Proxy(RealSubject realSubject)
        {
            _realSubject = realSubject;
        }

        public void GiveBeer()
        {
            _realSubject.GiveBeer();
        }

        public void GiveJk()
        {
            _realSubject.GiveJk();
        }

        public void GiveSmoking()
        {
            _realSubject.GiveSmoking();
        }
    }
}