namespace _14_建造者模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBuilderComputer b1 = new GoodComputer();
            IBuilderComputer b2 = new BadComputer();
            //创建监工对象
            Directory directory = new Directory();
            //让b1这个具体的建造者，按照稳定的过程（要求的逻辑），进行复杂对象的创建
            directory.BuildComputer(b1);
            var goodComputer = b1.GetComputer();
            goodComputer.ShowComputer();

            directory.BuildComputer(b2);
            var badComputer = b2.GetComputer();
            badComputer.ShowComputer();
            Console.ReadLine();
        }

        public interface IBuilderComputer
        {
            //1.封装创建各个部件的过程
            //2.将创建好的复杂返回
            void BuildCpu();
            void BuildDisk();
            void BuildMemory();

            void BuildScreen();

            void BuildSystem();

            Computer GetComputer();

        }

        //创建部件
        public class GoodComputer : IBuilderComputer
        {
            //可以不同
            private Computer _computer = new Computer();
            public void BuildCpu()
            {
                _computer.AddPort("I7CPU");
            }

            public void BuildDisk()
            {
                _computer.AddPort("520GB的硬盘");
            }

            public void BuildMemory()
            {
                _computer.AddPort("32G内存");
            }

            public void BuildScreen()
            {
                _computer.AddPort("17寸的显示器");
            }

            public void BuildSystem()
            {
                _computer.AddPort("winodws11的操作系统");
            }

            public Computer GetComputer()
            {
                return _computer;
            }



        }

        //创建部件
        public class BadComputer : IBuilderComputer
        {
            //可以不同
            private Computer _computer = new Computer();
            public void BuildCpu()
            {
                _computer.AddPort("I3CPU");
            }

            public void BuildDisk()
            {
                _computer.AddPort("200GB的硬盘");
            }

            public void BuildMemory()
            {
                _computer.AddPort("8G内存");
            }

            public void BuildScreen()
            {
                _computer.AddPort("13寸的显示器");
            }

            public void BuildSystem()
            {
                _computer.AddPort("winodws7的操作系统");
            }

            public Computer GetComputer()
            {
                return _computer;
            }



        }

        //产品
        public class Computer
        {

            private List<string> listPart = new List<string>();

            public void AddPort(string part)
            {
                listPart.Add(part);
            }

            public void ShowComputer()
            {
                foreach (string part in listPart)
                {

                    Console.WriteLine(part);
                }
            }
        }




        //这个类的职责就是监工
        public class Directory
        {
            //稳定创建各个部件（稳定创建对象）的过种

            public void BuildComputer(IBuilderComputer builderComputer)
            {
                builderComputer.BuildCpu();
                builderComputer.BuildDisk();
                builderComputer.BuildMemory();
                builderComputer.BuildScreen();
                builderComputer.BuildSystem();

            }
        }


    }
}