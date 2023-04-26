namespace _2_单例模式_懒汉式
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var instance1 = LazyManSigle.GetInstance();
            //var instance2 = LazyManSigle.GetInstance();
            //Console.WriteLine(instance1.GetHashCode());
            //Console.WriteLine(instance2.GetHashCode());
            //问题：会有线程安全问题
            //案例：写一个循环，模拟多个线程，执行单例模式
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 50; i++)
            {

                tasks.Add(Task.Factory.StartNew(() => LazyManSigle.GetInstance(), TaskCreationOptions.LongRunning));


            }
            Task.WaitAll(tasks.ToArray());
            Console.ReadLine();
        }
    }

    public class LazyManSigle
    {
        //volatile 关键字，防止字节码执行阶段CLR或者CPU重排序执行
        private static object _lock = new object();
        private volatile static LazyManSigle _lazyManSigle;
        private LazyManSigle()
        {
        }


        public static LazyManSigle GetInstance()
        {

            //没有创建，就创建，假如创建了，就返回
            //先判断 if 加锁 然后判断，可以提升一点性能，不是一直锁等待
            if (_lazyManSigle == null)
            {
                //加锁
                lock (_lock)
                {

                    if (_lazyManSigle == null)
                    {
                        _lazyManSigle = new LazyManSigle();
                        Console.WriteLine("我被创建了");
                    }

                }

            }
            return _lazyManSigle;
        }
    }
}