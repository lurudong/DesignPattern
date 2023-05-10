namespace _3_16空对象模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AbstractCustomer customer1 = CustomerFactory.GetCustomer("Rob");
            //AbstractCustomer customer2 = CustomerFactory.GetCustomer("Bob");
            //Console.WriteLine(customer1.GetName());
            //Console.WriteLine(customer2.GetName());
            Client client = new Client();
            client.DoSomething(new NullMyObject());
            Console.ReadLine();
        }
    }

    public abstract class AbstractCustomer
    {
        protected string Name { get; set; }

        public abstract bool IsNull();
        public abstract string GetName();
    }

    public class RealCustomer : AbstractCustomer
    {
        public RealCustomer(string name)
        {
            Name = name;
        }

        public override string GetName()
        {
            return Name;
        }

        public override bool IsNull()
        {
            return false;
        }
    }

    public class NullCustomer : AbstractCustomer
    {

        public override string GetName()
        {
            return "客户数据中不可用";
        }

        public override bool IsNull()
        {

            return true;
        }
    }

    public class CustomerFactory
    {
        public static string[] _names = new[] { "Rob", "Joe", "Julie" };
        public static AbstractCustomer GetCustomer(string name)
        {
            for (int i = 0; i < _names.Length; i++)
            {
                if (_names[i].Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return new RealCustomer(name);
                }
            }
            return new NullCustomer();
        }
    }



    public interface IMyObject
    {
        void DoSomething();
    }

    public class MyObject : IMyObject
    {
        public void DoSomething()
        {
            Console.WriteLine("MyObject.DoSomething()");
        }
    }

    public class NullMyObject : IMyObject
    {
        public void DoSomething()
        {
            // 空实现
        }
    }

    public class Client
    {
        public void DoSomething(IMyObject myObject)
        {
            myObject.DoSomething();
        }
    }
}