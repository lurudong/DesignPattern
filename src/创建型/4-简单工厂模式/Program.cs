namespace _4_简单工厂模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //实现计算中加减乘除功能

            //4个对象：加减乘除



            Console.WriteLine("请输入操作1");
            double d1 = double.Parse(Console.ReadLine()!);

            Console.WriteLine("请输入操作2");
            double d2 = double.Parse(Console.ReadLine()!);

            Console.WriteLine("请输入操作符");
            string oper = Console.ReadLine()!;

            //ICalculator calculator = null!;

            //switch (oper)
            //{
            //    case "+":
            //        calculator = new Add();
            //        break;
            //    case "-":
            //        calculator = new Sub();
            //        break;
            //    case "*":
            //        calculator = new Mul();
            //        break;
            //    case "/":
            //        calculator = new Div();
            //        break;
            //}


            //静态工厂方法：实际上就是把创建对象的过程，封装到静态方法中，在客户端直接调用就可以了
            //实现了客户端和创建对象的解耦
            //明确职责

            ICalculator calculator = CallFactory.GetCalculator(oper);
            var res = calculator.GetResult(d1, d2);
            Console.WriteLine(res);

            Console.ReadKey();
        }
    }

    //工厂创建类
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

    /// <summary>
    /// 计算类的接口
    /// </summary>
    public interface ICalculator
    {

        //方法：能返回最终计算的结果
        double GetResult(double d1, double d2);
    }

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