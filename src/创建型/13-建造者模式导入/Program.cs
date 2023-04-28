namespace _13_建造者模式导入
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer();
            computer.AddPort("I5CPU");
            computer.AddPort("256G的硬盘");
            computer.AddPort("32G内存");
            computer.AddPort("17寸的显示器");
            computer.AddPort("winodws7的操作系统");
            computer.ShowComputer();
            Console.ReadKey();
        }
    }

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
}