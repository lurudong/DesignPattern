namespace _11_原型模式实现
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Resume resume = new Resume("张三");
            Resume resume1 = (Resume)resume.Clone();
            Console.WriteLine(resume1.Name);
            Console.ReadLine();
        }
    }

    public abstract class ResumePrototype
    {
        public string Name { get; set; }
        public ResumePrototype(string name)
        {
            Name = name;
        }


        public abstract ResumePrototype Clone();
    }

    public class Resume : ResumePrototype
    {
        public Resume(string name) : base(name)
        {
        }

        public override ResumePrototype Clone()
        {
            //浅克隆
            //值类型成轴，全都拷贝一份，并且搞一份新的。
            //引用类型：只是复制引用，并不复制对象
            return (ResumePrototype)this.MemberwiseClone();
        }
    }
}