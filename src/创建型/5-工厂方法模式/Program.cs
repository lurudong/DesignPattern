namespace _5_工厂方法模式
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("请输入操作1");
            double d1 = double.Parse(Console.ReadLine()!);

            Console.WriteLine("请输入操作2");
            double d2 = double.Parse(Console.ReadLine()!);

            Console.WriteLine("请输入操作符");
            string oper = Console.ReadLine()!;
            ICallFactory callFactory = null!;
            switch (oper)
            {
                case "+":
                    callFactory = new AddFactory();
                    break;
                case "-":
                    callFactory = new SubFactory();
                    break;
                case "*":
                    callFactory = new MulFactory();
                    break;
                case "/":
                    callFactory = new DivFactory();
                    break;
            }
            ICalculator calculator = callFactory.GetCalculator();
            Console.WriteLine(calculator.GetResult(d1, d2));
            Console.ReadKey();
        }
    }

    //1、创建对象所有的逻辑，都集合到了一个方法中，风险比较高
    //2、现在是抽象依赖细节，我们需要细节依赖抽象
    public class CallFactory
    {
        public static ICalculator GetCalculator(string oper)
        {
            ICalculator calculator = null!;
            switch (oper)
            {
                case "+":
                    calculator = new Add();
                    break;
                case "-":
                    calculator = new Sub();
                    break;
                case "*":
                    calculator = new Mul();
                    break;
                case "/":
                    calculator = new Div();
                    break;
            }
            return calculator;

        }
    }




    //1、把创建对象的这件事，封装成抽象
    //核心
    //抽象工厂角色
    public interface ICallFactory
    {
        ICalculator GetCalculator();
    }

    //具体工厂角色
    public class AddFactory : ICallFactory
    {
        public ICalculator GetCalculator()
        {

            return new Add();
        }
    }


    public class SubFactory : ICallFactory
    {
        public ICalculator GetCalculator()
        {
            return new Sub();
        }
    }


    public class MulFactory : ICallFactory
    {
        public ICalculator GetCalculator()
        {
            return new Mul();
        }
    }

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
