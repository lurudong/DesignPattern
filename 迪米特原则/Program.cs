namespace 迪米特原则
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //实现 人 关机
            People people = new People();
            people.CloseComputer(new Computer());
            Console.ReadLine();
        }


    }

    public class Computer
    {
        private void SaveCurrentTask()
        {
            Console.WriteLine("保存当时程序");
        }

        private void CloseScreen()
        {
            Console.WriteLine("关闭屏幕");
        }

        private void ShutDown()
        {
            Console.WriteLine("关闭电脑");
        }

        public void CloseComputer()
        {
            this.SaveCurrentTask();
            this.CloseScreen();
            this.ShutDown();
        }

    }

    public class People
    {

        public void CloseComputer(Computer computer)
        {
            //不符合迪米特原则
            //相应的绝对顺序
            //computer.SaveCurrentTask();
            //computer.CloseScreen();
            //computer.ShutDown();
            computer.CloseComputer();
        }



    }

    public class TestA
    {
        public void TestMethod(TestB testB /*直接朋友*/)
        {
            TestC testC = new TestC(); //不是直接朋友
        }

        //直接朋友
        private TestD _testD;

        public TestB /*直接朋友*/ GetTestB()
        {
            return new TestB();
        }

        private List<int> list = new List<int>();
    }

    public class TestB
    { }
    public class TestC
    { }
    public class TestD
    { }

}

