namespace 依赖注入三种方式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //不同的人，开不用的车
            //Student student = new Student();
            //student.Drive(new Hq());
            //Student student = new Student(new Hq());
            //student.Drive();
            Student student = new Student();
            student.SetDrive(new Hq());
            student.Drive();
            Console.ReadLine();
        }

        public interface ICar
        {
            void Run();
        }

        public interface IDriver
        {

            //在接口，类中，将要注入的服务对象，以参数的形式注入，我们称之为接口注入
            //void Drive(ICar car);
            void Drive();
            //属性依赖
            void SetDrive(ICar car);

        }

        public class Hq : ICar
        {
            public void Run()
            {
                Console.WriteLine("红旗在跑");
            }
        }

        public class Student : IDriver
        {
            //public void Drive(ICar car)
            //{
            //    car.Run();
            //}
            private ICar _car;

            //public Student(ICar car)
            //{
            //    _car = car;
            //}
            public void Drive()
            {
                _car.Run();
            }


            public void SetDrive(ICar car)
            {
                _car = car;
            }
        }

        //接口注入
    }


}