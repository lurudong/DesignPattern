namespace _2_6桥接模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car qyCar = new SunCar();
            qyCar.Move(new Green());
            Console.ReadLine();
        }
    }

    public interface IColor
    {
        string ShowColor();
    }

    public class Red : IColor
    {
        public string ShowColor()
        {

            return "红色";
        }
    }

    public class White : IColor
    {
        public string ShowColor()
        {

            return "白色";
        }
    }

    public class Black : IColor
    {
        public string ShowColor()
        {

            return "黑色";
        }
    }

    public class Green : IColor
    {
        public string ShowColor()
        {

            return "绿色";
        }
    }

    public abstract class Car
    {
        public abstract void Move(IColor color);
    }

    public class QyCar : Car
    {
        public override void Move(IColor color)
        {
            Console.WriteLine($"{color.ShowColor()}颜色的汽油汽车在跑");
        }
    }

    public class DDCar : Car
    {
        public override void Move(IColor color)
        {
            Console.WriteLine($"{color.ShowColor()}颜色的电车汽车在跑");
        }
    }

    public class SunCar : Car
    {
        public override void Move(IColor color)
        {
            Console.WriteLine($"{color.ShowColor()}颜色的太阳能汽车在跑");
        }
    }
}