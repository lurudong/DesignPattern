namespace 迪米特原则_2
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //打印公司总部员工Id和分公司员工的Id

            //类1：总公司员工类
            //类2：总公司员工管理类
            //1、获取总公司所有员工
            //2、打印总公司所有员工ID
            //
            //类3：分公司员工类
            //类4：分公司员工管理类
            //1、获取分公司所有员工
            //2、打印分公司所有员工ID


            HeadOfficeManager headOfficeManager = new HeadOfficeManager();
            BranchOfficeManager branchOfficeManager = new BranchOfficeManager();
            // headOfficeManager.Print(branchOfficeManager);
            headOfficeManager.Print();
            branchOfficeManager.Print();
            Console.ReadLine();
        }


    }

    class HeadOfficeEmployee
    {
        public int Id { get; set; }
    }

    class BranchOfficeEmployee
    {
        public int Id { get; set; }
    }

    //HeadOfficeEmployee 直接朋友
    //BranchOfficeManager 直接朋友
    //BranchOfficeEmployee 不是直接朋友
    class HeadOfficeManager
    {
        //获取总公司所有员工
        public List<HeadOfficeEmployee> GetHeadOfficeEmployees()
        {
            List<HeadOfficeEmployee> headOfficeEmployees = new List<HeadOfficeEmployee>();
            for (int i = 0; i < 10; i++)
            {

                headOfficeEmployees.Add(new HeadOfficeEmployee() { Id = i });
            }
            return headOfficeEmployees;
        }

        //打印总公司所有员工ID和打印分公司所有员工ID
        public void Print()
        {
            Console.WriteLine("总公司的员ID是：");
            foreach (var headOfficeEmployee in this.GetHeadOfficeEmployees())
            {
                Console.WriteLine(headOfficeEmployee.Id);
            }



            #region listBranch 通过局部变量创建来的，所以不是直接朋友
            //   Console.WriteLine("分公司的员ID是：");
            //var listBranch = branchOfficeManager.GetBranchOfficeEmployees();
            //foreach (var item in listBranch)
            //{
            //    Console.WriteLine(item.Id);
            //}
            #endregion

        }
    }

    class BranchOfficeManager
    {
        //获取分公司所有员工
        private List<BranchOfficeEmployee> GetBranchOfficeEmployees()
        {
            List<BranchOfficeEmployee> branchOfficeEmployees = new List<BranchOfficeEmployee>();
            for (int i = 0; i < 4; i++)
            {

                branchOfficeEmployees.Add(new BranchOfficeEmployee() { Id = i });
            }
            return branchOfficeEmployees;
        }

        public void Print()
        {
            Console.WriteLine("分公司的员ID是：");
            foreach (var item in this.GetBranchOfficeEmployees())
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}