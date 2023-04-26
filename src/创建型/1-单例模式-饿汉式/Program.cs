namespace _1_单例模式_饿汉式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //单例模式:要求在一个程序的运行过中，有，并且，只有一个实例
            var singleHungry1 = SingleHungry.GetInstance();
            var singleHungry2 = SingleHungry.GetInstance();
            var singleHungry3 = SingleHungry.GetInstance();

            Console.WriteLine(singleHungry1.GetHashCode());
            Console.WriteLine(singleHungry2.GetHashCode());
            Console.WriteLine(singleHungry3.GetHashCode());
            Console.ReadKey();
        }
    }

    //这种称为，饿汉式，不建议使用，该对象还没有被调用，就在内存中，造成资源浪费。

    public class SingleHungry
    {

        //1、构造函数私有化
        private SingleHungry()
        {

        }

        //2、创建一个唯一的对象
        //private:迪米特，没有必要暴露给外界的成员，都写成private
        //static:静态成员，保存在内存的唯一性
        //readonly：只读，不可以修改
        private static readonly SingleHungry _singleHungry = new SingleHungry();

        //3、创建一个方法，实现对外提供获取类唯一对象能力

        public static SingleHungry GetInstance()
        {
            return _singleHungry;
        }
    }
}