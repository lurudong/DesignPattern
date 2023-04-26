using System.Reflection;

namespace _6_工厂方法_反射
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("使用反射处理");
            Console.WriteLine("请输入操作1");
            double d1 = double.Parse(Console.ReadLine()!);

            Console.WriteLine("请输入操作2");
            double d2 = double.Parse(Console.ReadLine()!);

            Console.WriteLine("请输入操作符");
            string oper = Console.ReadLine()!;

            //抽象：描述了一段关系运算符和具体工厂对象的对应关系
            //Attribute:特性

            #region
            ReflectionFactory reflectionFactory = new ReflectionFactory();
            var res = reflectionFactory.Create(oper)?.GetCalculator()?.GetResult(d1, d2);
            Console.WriteLine($"得到结果是：{res}");
            #endregion

            Console.ReadLine();
        }
    }




    //1、把创建对象的这件事，封装成抽象
    //核心
    public interface ICallFactory
    {
        ICalculator GetCalculator();
    }

    public class OperToFacoryAttribute : Attribute
    {
        public OperToFacoryAttribute(string oper)
        {
            Oper = oper;
        }
        public string Oper { get; }
    }

    //程序运行后，拿到这段描述关系,并且返回响应的对象
    public class ReflectionFactory
    {

        private readonly Dictionary<string, ICallFactory> _dic = new Dictionary<string, ICallFactory>();

        public ReflectionFactory()
        {
            //1.当前正在运行的程序集
            var assembly = Assembly.GetExecutingAssembly();
            var operToFacoryAttributes = assembly?.GetTypes().Where(o => !o.IsInterface && typeof(ICallFactory).IsAssignableFrom(o)
            && o.GetCustomAttributes<OperToFacoryAttribute>().Any()).Select(o => new
            {

                Attribute = o.GetCustomAttribute<OperToFacoryAttribute>(),
                Type = o,
            })!;

            foreach (var item in operToFacoryAttributes)
            {
                _dic.TryAdd(item.Attribute?.Oper!, (Activator.CreateInstance(item.Type) as ICallFactory)!);
            }
        }

        public ICallFactory? Create(string op)
        {
            return _dic[op] ?? null;
        }

    }


    //具体工厂角色
    [OperToFacory("+")]
    public class AddFactory : ICallFactory
    {
        public ICalculator GetCalculator()
        {

            return new Add();
        }
    }

    [OperToFacory("-")]
    public class SubFactory : ICallFactory
    {
        public ICalculator GetCalculator()
        {
            return new Sub();
        }
    }

    [OperToFacory("*")]
    public class MulFactory : ICallFactory
    {
        public ICalculator GetCalculator()
        {
            return new Mul();
        }
    }

    [OperToFacory("/")]
    public class DivFactory : ICallFactory
    {
        public ICalculator GetCalculator()
        {
            return new Div();
        }
    }

    /// <summary>
    /// 计算类的接口
    /// </summary>
    /// 抽象产品角色
    public interface ICalculator
    {

        //方法：能返回最终计算的结果
        double GetResult(double d1, double d2);
    }

    //具体产品角色类
    public class Add : ICalculator
    {


        public double GetResult(double d1, double d2)
        {

            return d1 + d2;
        }
    }

    public class Sub : ICalculator
    {


        public double GetResult(double d1, double d2)
        {

            return d1 - d2;
        }
    }

    public class Mul : ICalculator
    {


        public double GetResult(double d1, double d2)
        {

            return d1 * d2;
        }
    }

    public class Div : ICalculator
    {


        public double GetResult(double d1, double d2)
        {

            return d1 / d2;
        }
    }
}