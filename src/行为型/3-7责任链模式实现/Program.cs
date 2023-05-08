namespace _3_7责任链模式实现
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager("张三");
            ZongJian zongJian = new ZongJian("李四");
            Boss boss = new Boss("王八");
            manager.SetHandler(zongJian);
            zongJian.SetHandler(boss);
            Request request =
                new Request()
                {
                    RequestType = "请假",
                    RequestCount = 5
                };

            manager.HandlerRequest(request);
            Console.ReadLine();
        }
    }

    public class Request
    {
        public string RequestType { get; set; }

        public int RequestCount { get; set; }
    }

    public abstract class Handler
    {

        public string Name { get; set; }

        protected Handler(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 在抽象的管理者父类中，通过一个父类类型的属性，记录下一个处理对象是谁？
        /// </summary>
        public Handler HandlerProcess { get; set; } //让某个子类，维护一个对下一个处理对象的引用

        /// <summary>
        /// 具体的处理对象，调用该方法，能够该方法，能够设置自己的一个请求处理对象
        /// </summary>
        /// <param name="handler"></param>
        public void SetHandler(Handler handler)
        {
            this.HandlerProcess = handler;
        }

        public abstract void HandlerRequest(Request request);
    }

    public class Manager : Handler
    {
        public Manager(string name) : base(name)
        {
        }

        public override void HandlerRequest(Request request)
        {
            if (request.RequestType == "请假" && request.RequestCount <= 2)
            {
                Console.WriteLine($"经理{this.Name}批准了孙权{request.RequestCount}天的请假");
            }
            else
            {
                //把请求传给下一个处理者
                this.HandlerProcess.HandlerRequest(request);
            }
        }
    }

    public class ZongJian : Handler
    {
        public ZongJian(string name) : base(name)
        {
        }

        public override void HandlerRequest(Request request)
        {
            if (request.RequestType == "请假" && request.RequestCount >= 3 && request.RequestCount <= 6)
            {
                Console.WriteLine($"总监{this.Name}批准了孙权{request.RequestCount}天的请假");
            }
            else
            {
                //把请求传给下一个处理者
                this.HandlerProcess.HandlerRequest(request);
            }
        }
    }


    public class Boss : Handler
    {
        public Boss(string name) : base(name)
        {
        }

        public override void HandlerRequest(Request request)
        {
            if (request.RequestType == "请假" && request.RequestCount > 6 && request.RequestCount <= 10)
            {
                Console.WriteLine($"老板{this.Name}批准了孙权{request.RequestCount}天的请假");
            }
            else
            {
                Console.WriteLine("滚，给脸不要脸，爱干不干！！！");
            }
        }
    }
}