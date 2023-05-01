namespace _2_2装饰器模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //如果我想要一杯奶茶，
            //加两份布丁，一份珍珠，该如何实现?
            //假如不用装饰器，子类组合数量爆增。

            MilkTea milkTea = new MilkTea();
            Buding buding1 = new Buding();
            Buding buding2 = new Buding();
            ZhenZhu zhenZhu = new ZhenZhu();

            //给奶茶添加布丁
            buding1.SetComponent(milkTea);

            //给奶茶添加第二份布丁
            buding2.SetComponent(buding1);

            //给奶茶添加珍珠
            zhenZhu.SetComponent(buding2);


            Console.WriteLine(zhenZhu.Cost());
            Console.ReadKey();
        }
    }

    //部件
    public abstract class YinLiao
    {
        public abstract double Cost();
    }

    //具体部件

    public class MilkTea : YinLiao
    {
        public override double Cost()
        {

            Console.WriteLine("奶茶20元一怀");
            return 20;
        }
    }

    public class FruitTea : YinLiao
    {
        public override double Cost()
        {

            Console.WriteLine("水果茶30元一怀");
            return 30;
        }
    }

    public class SoDaTea : YinLiao
    {
        public override double Cost()
        {

            Console.WriteLine("苏打饮料40元一怀");
            return 40;
        }
    }

    //装饰
    public abstract class Decorator : YinLiao
    {

        //protected Decorator(YinLiao yinLiao)
        //{ 
        //    _yinLiao = yinLiao;
        //}
        //添加父类的引用
        private YinLiao? _yinLiao;

        //通过set方法，给他赋值
        public void SetComponent(YinLiao yinLiao)
        {
            _yinLiao = yinLiao;
        }

        public override double Cost()
        {
            return _yinLiao!.Cost();
        }

    }

    /// <summary>
    /// 具体装饰
    /// </summary>
    public class Buding : Decorator
    {
        private static double _meney = 5;

        public override double Cost()
        {
            Console.WriteLine("布丁5元");
            //一定要调用父类的Cost不是无法实现
            return base.Cost() + _meney;
        }

    }

    public class XianCao : Decorator
    {
        private static double _meney = 6;
        public override double Cost()
        {
            Console.WriteLine("仙草6元");
            return base.Cost() + _meney;
        }
    }

    public class ZhenZhu : Decorator
    {
        private static double _meney = 7;
        public override double Cost()
        {
            Console.WriteLine("珍珠7元");
            return base.Cost() + _meney;
        }
    }
}