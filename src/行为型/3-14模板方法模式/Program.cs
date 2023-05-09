namespace _3_14模板方法模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cooking cooking = new ZS();
            cooking.ChaoCai();
            Console.ReadLine();
        }
    }

    public abstract class Cooking
    {
        //炒菜:1
        //放油
        //爆香
        //放菜
        //翻炒
        //调味
        //关火
        //起钢
        public abstract void FY();
        public abstract void BX();
        public abstract void FC();

        public abstract void TW();

        public void ChaoCai()
        {
            FY();
            BX();
            FC();
            TW();
        }
    }

    public class ZS : Cooking
    {
        public override void BX()
        {
            Console.WriteLine("张三2");
        }

        public override void FC()
        {
            Console.WriteLine("张三3");
        }

        public override void FY()
        {
            Console.WriteLine("张三1");
        }

        public override void TW()
        {
            Console.WriteLine("张三4");
        }
    }
}