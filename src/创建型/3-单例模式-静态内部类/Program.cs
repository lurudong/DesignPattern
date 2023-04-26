namespace _3_单例模式_静态内部类
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var signleton1 = InnerSignleton.GetInstance();

            var signleton2 = InnerSignleton.GetInstance();

            Console.WriteLine(signleton1.GetHashCode());
            Console.WriteLine(signleton2.GetHashCode());


            Console.ReadKey();
        }
    }

    public class InnerSignleton
    {
        private static class InnerClassHolder
        {
            public static readonly InnerSignleton _singleton = new InnerSignleton();
        }
        private InnerSignleton()
        {
        }
        public static InnerSignleton GetInstance()
        {
            return InnerClassHolder._singleton;
        }

    }


}