namespace _3_4访问者模式
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //正式员工 临时员工 人事部门 财务部门
            Console.ReadLine();
        }
    }

    public class Employee
    {

    }

    //正式员工
    public class FullTimeEmp : Employee
    {

    }

    //临时员工
    public class PartTimeEmp : Employee
    {

    }

    /// <summary>
    ///
    /// </summary>
    //算工资
    //不同的数据类型，有不同的操作方式。
    //问题一：如果添加了新的操作，则必须要修改源代码，不符合开闭原则
    //问题二：EmpList封装了几乎所有业务操作，难以维护，不符合单一原则
    //问题三：大量用到if elseif 这种逻辑判断，屎山。
    public class EmpList
    {
        private List<Employee> employees = new List<Employee>();
        public void AddEmp(Employee emp)
        {
            employees.Add(emp);
        }

        public void GetSalary(string depName)
        {
            //人事部门考核考勤
            if (depName == "人事部")
            {
                foreach (var item in employees)
                {
                    if (item.GetType().Equals("FullTimeEmp"))
                    {
                        Console.WriteLine("正式员工的考勤操作");
                    }
                    else
                    {
                        Console.WriteLine("临时员工的考勤操作");
                    }
                }
            }
            else if (depName == "财务部")
            {
                foreach (var item in employees)
                {
                    if (item.GetType().Equals("FullTimeEmp"))
                    {
                        Console.WriteLine("正式员工的工资操作");
                    }
                    else
                    {
                        Console.WriteLine("临时员工的工资操作");
                    }
                }
            }
            //财务部门根据考勤，计算工资

        }
    }
}