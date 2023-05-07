namespace _3_2观察者模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //12月31号
            //跨年联欢

            //我----leader 组织跨年晚会  需要定义时间、地点、活动 被观察者-》主题(观察目标)
            //同事们--参与者
            #region 耦合
            //HappyNewYear happyNewYear = new HappyNewYear();
            //Observer observer1 = new Observer()
            //{
            //    Name = "张三",
            //    HappyNewYear = happyNewYear
            //};

            //Observer observer2 = new Observer()
            //{
            //    Name = "李四",
            //    HappyNewYear = happyNewYear
            //};

            //Observer observer3 = new Observer()
            //{
            //    Name = "王五",
            //    HappyNewYear = happyNewYear
            //};

            //Observer observer4 = new Observer()
            //{
            //    Name = "王八",
            //    HappyNewYear = happyNewYear
            //};


            //happyNewYear.Add(observer1);
            //happyNewYear.Add(observer2);
            //happyNewYear.Add(observer3);
            //happyNewYear.Add(observer4);

            ////要约会不去了
            //happyNewYear.Remove(observer4);

            ////去那里玩
            //happyNewYear.Info = "白云山";

            ////通过所有人更新信息
            //happyNewYear.Notify();
            #endregion


            //问题：HappyNewYear和观察者们，是高度耦合的


            ISubject happyNewYear = new HappyNewYear();
            IObserver observer1 = new Observer()
            {
                Name = "张三",
                Subject = happyNewYear
            };

            IObserver observer2 = new Observer()
            {
                Name = "李四",
                Subject = happyNewYear
            };

            IObserver observer3 = new Observer()
            {
                Name = "王五",
                Subject = happyNewYear
            };

            IObserver observer4 = new Observer()
            {
                Name = "王八",
                Subject = happyNewYear
            };



            IObserver student1 = new Student() { Name = "老六", Age = 18, Gerder = '男', Subject = happyNewYear };

            IObserver student2 = new Student() { Name = "老七", Age = 20, Gerder = '女', Subject = happyNewYear };



            happyNewYear.Add(observer1);
            happyNewYear.Add(observer2);
            happyNewYear.Add(observer3);
            happyNewYear.Add(observer4);

            happyNewYear.Add(student1);
            happyNewYear.Add(student2);

            //要约会不去了
            happyNewYear.Remove(observer4);

            //去那里玩
            happyNewYear.Info = "白云山";

            //通过所有人更新信息
            happyNewYear.Notify();

            Console.ReadKey();
        }


    }

    public interface ISubject
    {
        string Info { get; set; }
        void Notify();

        void Add(IObserver observer);

        void Remove(IObserver observer);

    }
    public class HappyNewYear : ISubject
    {

        //需要维护所有观察者的引用 
        private List<IObserver> _observers = new List<IObserver>();

        //存相关信息，也就是要通知的信息
        public string Info { get; set; }

        //通知所有的观察者，更新的信息
        public void Notify()
        {
            foreach (var observer in _observers)
            {

                observer.GoParty();
            }
        }

        public void Add(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            _observers.Remove(observer);
        }

    }

    public interface IObserver
    {

        //接收我们观察的主题，更新后的消息;
        void /*Update()*/GoParty();
    }
    //观察者
    public class Observer : IObserver
    {
        public string Name { get; set; } = default!;

        //在观察者类中，维护一个被观察者的引用 
        public ISubject Subject { get; set; } = default!;
        public void GoParty()
        {
            Console.WriteLine($"{this.Name}被通知，12月31号晚上的活动是{Subject.Info}");
        }
    }

    public class Student : IObserver
    {
        public ISubject Subject { get; set; } = default!;
        public string Name { get; set; }
        public int Age { get; set; }

        public char Gerder { get; set; }
        public void GoParty()
        {
            Console.WriteLine($"我叫{this.Name},我是{this.Gerder}生，我要去{this.Subject.Info}参加我{this.Age}岁的跨年晚会");
        }
    }

}