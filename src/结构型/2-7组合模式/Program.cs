namespace _2_7组合模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Component根节点 公司
            //Composite 树枝 部门
            //Leaf 树叶 员工

            Component company = new DepartComposite("大黄瓜传媒有限公司");

            //创建部门
            Component dep1 = new DepartComposite("导演部");

            //创建员工
            Component boss = new Employee("大黄瓜");

            //把部门添加到公司下
            company.Add(dep1);

            //把员工添加到部门下
            dep1.Add(boss);

            company.Display(3);
            Console.ReadKey();
        }
    }

    //定义了子类中所有共性的内容
    public abstract class Component
    {
        protected string Name { get; set; }

        protected Component(string name)
        {
            Name = name;
        }

        public abstract void Add(Component component);

        public abstract void Remove(Component component);
        public abstract void Display(int depth);
    }

    /// <summary>
    /// 部门类，树枝
    /// </summary>
    public class DepartComposite : Component
    {
        //存储部门或员工
        private readonly List<Component> _components = new List<Component>();
        public DepartComposite(string name) : base(name)
        {

        }
        public override void Add(Component component)
        {
            _components.Add(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine($"{new string('-', depth)}{Name}");

            foreach (Component component in _components)
            {
                ///递归 就是多输出几个---
                component.Display(depth + 4);
            }
        }

        public override void Remove(Component component)
        {
            _components.Remove(component);
        }
    }

    /// <summary>
    /// Employee 是我们的Leaf节点，也就是树叶，树叶是无法继续添加
    /// </summary>
    public class Employee : Component
    {
        public Employee(string name) : base(name)
        {

        }
        public override void Add(Component component)
        {

        }

        public override void Display(int depth)
        {
            Console.WriteLine($"{new string('-', depth)}{Name}");
        }

        public override void Remove(Component component)
        {

        }
    }

}