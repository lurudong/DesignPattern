namespace _12_简化原型模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Resume resume = new Resume();
            resume.SetInfo("张三", 18, '男');
            resume.SetWordExperience("2018-2020", "开发工程师");
            Resume resume2 = (Resume)resume.Clone();
            resume.ShowResume();
            resume2.ShowResume();
            Console.ReadLine();
        }
    }

    public class Resume : ICloneable
    {

        public string Name { get; set; }

        public int Age { get; set; }

        public char Gender { get; set; }

        public string TimeArea { get; set; }

        public string Company { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

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