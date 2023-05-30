namespace _3_5访问者模式实现
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //我们要访问的对象集合
            EmployeeList employeeList = new EmployeeList();

            //创建相关的被访问者，并且添加到访问者集合中
            IEmployee employee1 = new FullTimeEmp("张三", 180, 20000);
            IEmployee employee2 = new FullTimeEmp("李四", 200, 30000);
            IEmployee employee3 = new FullTimeEmp("王五", 100, 10000);

            IEmployee employee4 = new PartTimeEmp("赵六", 100, 100);
            IEmployee employee5 = new PartTimeEmp("田七", 80, 100);
            IEmployee employee6 = new PartTimeEmp("王八", 120, 100);
            employeeList.Add(employee1);
            employeeList.Add(employee2);
            employeeList.Add(employee3);
            employeeList.Add(employee4);
            employeeList.Add(employee5);
            employeeList.Add(employee6);

            MoneyDepartment moneyDepartment = new MoneyDepartment();
            HrDepartment hrDepartment = new HrDepartment();
            employeeList.EmployeeListAccept(moneyDepartment);
            Console.WriteLine("*************************************");
            employeeList.EmployeeListAccept(hrDepartment);
            Console.ReadLine();
        }
    }

    /// <summary>
    /// 抽象访问者接口 提供相应的方法，明确出要访问的元素
    /// </summary>
    public abstract class Visitors
    {
        public abstract void Visit(FullTimeEmp fullTimeEmp); //
        public abstract void Visit(PartTimeEmp partTimeEmp); //
    }

    /// <summary>
    /// 具体访问者：财务部，完成了对被访问者全职员工和被访问者兼职员工的相关操作
    /// </summary>

    public class MoneyDepartment : Visitors
    {
        /// <summary>
        /// 财务对正式员工操作
        /// </summary>
        /// <param name="fullTimeEmp"></param>

        public override void Visit(FullTimeEmp fullTimeEmp)
        {
            double workTime = fullTimeEmp.WorkTime;
            double monthMoney = fullTimeEmp.MonthMoney;
            Console.WriteLine($"正式员工{fullTimeEmp.Name},正常的月薪是{fullTimeEmp.MonthMoney}");
            if (workTime >= 160)
            {
                Console.WriteLine($"正式员工{fullTimeEmp.Name},本月的薪资（包含加班费）合计是{monthMoney + (workTime - 160) * 100}");
            }
            else
            {
                Console.WriteLine($"正式员工{fullTimeEmp.Name},由于本月缺勤，工资合计{monthMoney - (160 - workTime) * 80}");
            }
        }

        /// <summary>
        /// 财务对外包工员操作
        /// </summary>
        /// <param name="partTimeEmp"></param>

        public override void Visit(PartTimeEmp partTimeEmp)
        {
            double workTime = partTimeEmp.WorkTime;
            double hourMoney = partTimeEmp.HourMoney;
            Console.WriteLine($"临时员工{partTimeEmp.Name}本月薪资合计{hourMoney * workTime}");
        }
    }
    public class HrDepartment : Visitors
    {
        /// <summary>
        /// 人事对正式员工操作
        /// </summary>
        /// <param name="fullTimeEmp"></param>

        public override void Visit(FullTimeEmp fullTimeEmp)
        {
            double workTime = fullTimeEmp.WorkTime;

            if (workTime >= 160)
            {
                Console.WriteLine($"正式员工{fullTimeEmp.Name},本月应出勤160小时，实际出勤{workTime}小时，合计加班{fullTimeEmp.WorkTime - 160}");
            }
            else
            {
                Console.WriteLine($"正式员工{fullTimeEmp.Name},本月应出勤160小时，实际出勤{workTime}小时，合计缺勤{160 - fullTimeEmp.WorkTime}");
            }

        }

        /// <summary>
        /// 人事对临时员工操作
        /// </summary>
        /// <param name="partTimeEmp"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Visit(PartTimeEmp partTimeEmp)
        {
            Console.WriteLine($"临时员工{partTimeEmp.Name},本月出勤{partTimeEmp.WorkTime}小时");
        }
    }

    /// <summary>
    /// 被访问者的父类，对外提供一个可以被访问的接口
    /// </summary>
    public interface IEmployee
    {
        void Accept(Visitors visitors);
    }

    /// <summary>
    /// 被访问元素集合
    /// </summary>
    public class EmployeeList
    {
        private List<IEmployee> list = new List<IEmployee>();

        public void Add(IEmployee employee)
        {
            list.Add(employee);
        }

        public void EmployeeListAccept(Visitors visitors)
        {
            foreach (var item in list)
            {
                item.Accept(visitors);
            }
        }
    }

    /// <summary>
    /// 被访问者1
    /// </summary>

    public class FullTimeEmp : IEmployee
    {
        public string Name { get; set; }
        public double WorkTime { get; set; }
        public double MonthMoney { get; set; }

        public FullTimeEmp(string name, double workTime, double monthMoney)
        {
            Name = name;
            WorkTime = workTime;
            MonthMoney = monthMoney;
        }

        public void Accept(Visitors visitors)
        {
            visitors.Visit(this);
        }
    }

    /// <summary>
    /// 被访问者2,通过Accept方法，接受访问
    /// </summary>
    public class PartTimeEmp : IEmployee
    {
        public string Name { get; set; }
        public double WorkTime { get; set; }
        public double HourMoney { get; set; }

        public PartTimeEmp(string name, double workTime, double hourMoney)
        {
            Name = name;
            WorkTime = workTime;
            HourMoney = hourMoney;
        }

        public void Accept(Visitors visitors)
        {
            visitors.Visit(this);
        }
    }
}