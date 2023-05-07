namespace _3_3迭代器模式
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ConcreteAggregate aggregate = new ConcreteAggregate();

            aggregate[0] = 1;
            aggregate[1] = 2;
            aggregate[2] = 3;


            ConcreteIterator concreteIterator = new ConcreteIterator();

            concreteIterator.ConcreteAggregate = aggregate;
            while (!concreteIterator.IsDone())
            {
                Console.WriteLine(concreteIterator.CurrentItem());
                concreteIterator.Next();
            }
            Console.ReadLine();
        }
    }

    public interface Iterator
    {
        //抽象的迭代器接口 定义了具体的迭代器类，应该实现的功能
        //返回第一个元素
        object Fist();

        ///Next返回下一个元素
        object Next();

        //CurrentItem 返回当前元素
        object CurrentItem();

        //判断是否完成 完成返回True,否则false
        bool IsDone();

    }

    public interface Aggregate
    {
        Iterator GetIterator();
    }

    public class ConcreteIterator : Iterator
    {
        private int index;
        public ConcreteAggregate ConcreteAggregate { get; set; } = default!;
        public object CurrentItem()
        {
            return ConcreteAggregate[index];
        }

        public object Fist()
        {
            return ConcreteAggregate[0];
        }

        public bool IsDone()
        {
            return index >= ConcreteAggregate.Count ? true : false;
        }

        public object Next()
        {
            object result = null!;
            index++;
            //迭代没结束
            if (index < ConcreteAggregate.Count)
            {
                result = ConcreteAggregate[index];
            }
            return result!;

        }
    }

    public class ConcreteAggregate : Aggregate
    {
        private List<object> _list = new List<object>();
        //索引器
        public object this[int index]
        {
            get { return _list[index]; }
            set { _list.Insert(index, value); }
        }

        public int Count
        { get { return _list.Count; } }


        /// <summary>
        /// 添加一个索引器
        /// </summary>
        /// <returns></returns>
        public Iterator GetIterator()
        {

            return new ConcreteIterator();
        }
    }


}