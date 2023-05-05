namespace _3_1中介者模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //中介者的抽象
            //中介者具体实现
            //参与者的抽象
            //参与者具体实现

            //婚姻中介的案例 给男女配对 百分百配对 --->平台（正规吗？？）

            HongNiang hongNiang = new HongNiang();
            Woman woman = new Woman("翠花", 18, '女', hongNiang, "杨幂");
            Woman woman2 = new Woman("翠花1", 18, '女', hongNiang, "杨幂");
            Woman woman3 = new Woman("翠花2", 18, '女', hongNiang, "杨幂");

            Man man = new Man("加藤鹰", 18, '男', hongNiang, 100000);
            Man man2 = new Man("加藤鹰1", 18, '男', hongNiang, 1000000);
            Man man3 = new Man("加藤鹰2", 18, '男', hongNiang, 100);

            hongNiang.Register(woman);
            hongNiang.Register(woman2);
            hongNiang.Register(woman3);

            hongNiang.Register(man);
            hongNiang.Register(man2);
            hongNiang.Register(man3);

            hongNiang.Match(woman);
            Console.ReadKey();
        }


    }

    public interface IMdeiator
    {
        /// <summary>
        /// 注册
        /// </summary>
        void Register(Person person);
        /// <summary>
        /// 配对
        /// </summary>
        void Match(Person person);
    }

    public class HongNiang : IMdeiator
    {
        /// <summary>
        /// 中介者具体实现,维护一参与者的集合
        /// </summary>
        private readonly List<Person> _people = new List<Person>();
        public void Match(Person person)
        {
            foreach (var item in _people)
            {
                //保证两个人的性别不一样，才能开始按条件配对 给男性找女朋友
                if (item.Gender == '女' && person.Gender != item.Gender)
                {
                    Woman woman = (Woman)item;
                    Man man = (Man)person;
                    if (woman.Face == "杨幂" && man.Money >= 100000)
                    {
                        Console.WriteLine($"{item.Name}跟{person.Name}配对成功");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name}跟{person.Name}不合适");
                    }
                }
                else if (item.Gender == '男' && person.Gender != item.Gender)
                {
                    Man man = (Man)item;
                    if (man.Money >= 100000)
                    {
                        Console.WriteLine($"{item.Name}跟{person.Name}配对成功");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name}别闹了你的钱不够");
                    }

                }
            }
        }

        public void Register(Person person)
        {
            _people.Add(person);
        }
    }

    public abstract class Person
    {
        public string Name { get; set; } = default!;
        public int Age { get; set; }

        public char Gender { get; set; }

        public IMdeiator Mdeiator { get; set; }

        protected Person(string name, int age, char gender, IMdeiator mdeiator)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Mdeiator = mdeiator;

        }
    }

    public class Man : Person
    {
        public Man(string name, int age, char gender, IMdeiator mdeiator, double money) : base(name, age, gender, mdeiator)
        {
            Money = money;
        }

        public double Money { get; init; }


    }

    public class Woman : Person
    {
        public Woman(string name, int age, char gender, IMdeiator mdeiator, string face) : base(name, age, gender, mdeiator)
        {
            Face = face;
        }

        public string Face { get; init; }


    }

}