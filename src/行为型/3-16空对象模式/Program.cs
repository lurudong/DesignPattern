namespace _3_16空对象模式
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Person person = new Person();
            person.Hear(new Dog());
            person.Hear(new NullAnimal());
            Console.ReadLine();
        }
    }




    /// <summary>
    /// 定义动物接口
    /// </summary>
    public interface IAnimal
    {
        public void MakeSound();
    }

    //定义一个小狗
    public class Dog : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Wang Wang Wang!");
        }
    }

    public class Person
    {
        //听到动物叫声
        public void Hear(IAnimal animal)
        {
            if (animal != null)
            {
                animal.MakeSound();
            }
        }

    }

    public class NullAnimal : IAnimal
    {
        public void MakeSound()
        {

        }
    }
}