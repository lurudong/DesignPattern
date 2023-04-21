namespace 合成复用原则
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Car car = new QyCar();
            car.Run(new Red());
            Console.ReadLine();
        }
    }

    public interface IColor
    {
        string ShowColor();
    }

    public class Green : IColor
    {
        public string ShowColor()
        {

            return "绿色的车";
        }
    }

    public class Red : IColor
    {
        public string ShowColor()
        {

            return "红色的车";
        }
    }

    public abstract class Car
    {
        /// <summary>
        /// 接口依赖（使用你）
        /// </summary>
        /// <param name="color"></param>
        public abstract void Run(IColor color);
    }

    public class QyCar : Car
    {
        public override void Run(IColor color)
        {
            Console.WriteLine($"汽油{color.ShowColor()}颜色的车，在跑");
        }
    }

    public class DCar : Car
    {
        public override void Run(IColor color)
        {
            Console.WriteLine($"电车{color.ShowColor()}颜色的车，在跑");
        }
    }

    public class Animal
    {
        private char _gender;
        public void Eat()
        {
            Console.WriteLine("吃屎");
        }

        public void Sleep()
        {
            Console.WriteLine("睡觉");
        }
    }

    public class Tiger : Animal, IClimb
    {
        public string Name { get; set; }

        private Leg _leg;

        //关联关系
        private Food food;

        //组合关系
        public Tiger(Leg leg)
        {
            _leg = leg;
        }

        public Tiger()
        {
            //这种写法跟构造函数一样的
            this._leg = new Leg();
        }

        //依赖关系
        public void Drink(Water water)
        {
        }
        public void Climb()
        {
            Console.WriteLine("老师在爬树，啪啪");
        }
    }

    public class Food
    {
        private string _FoodName;
        private string _FoodColor;
    }
    public class TigerGrop
    {

        //聚合关系，弱拥有
        private Tiger[] _tigers;
    }

    public class Water
    {
        private float _weight;
    }

    public interface IClimb
    {
        void Climb();
    }

    public class Leg
    {
        private int _Cout;
    }
}