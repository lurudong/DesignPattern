namespace _10_原型模式导入
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //简历中包含:姓名、性别、年龄、工作经验.....….需求:复制三份简历对象

            Resume resume = new Resume();
            resume.SetInfo("张三", 18, '男');
            resume.SetWordExperience("2018-2020", "开发工程师");
            resume.ShowResume();
            Console.ReadLine();
        }
    }

    public class Resume
    {

        public string Name { get; set; }

        public int Age { get; set; }

        public char Gender { get; set; }

        public string TimeArea { get; set; }

        public string Company { get; set; }

        public void SetInfo(string name, int age, char gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public void SetWordExperience(string timeArea, string company)
        {
            this.TimeArea = timeArea;
            this.Company = company;
        }

        public void ShowResume()
        {
            Console.WriteLine($"{this.Name}{this.Age}{this.Gender}");
            Console.WriteLine($"{this.TimeArea}{this.Company}");
        }
    }
}