namespace 接口隔离原则
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //把接口细分
            Console.ReadLine();
        }

        //这样的话，接口方法太多了，应该把接口细分
        //高耦合
        public interface IScore
        {
            void QueryScore();

            void UpdateScore();

            void AddScore();

            void DeleteScore();

            double GetSumScore();

            double GetAvgScore();

            void PringScore();

            void SendScore();
        }


        public class Teacher : ITeacherScore
        {
            public void AddScore()
            {
                Console.WriteLine("老师添加分数");
            }

            public void DeleteScore()
            {
                Console.WriteLine("老师删除分数");
            }

            public double GetAvgScore()
            {
                return 0;
            }

            public double GetSumScore()
            {
                return 0;
            }

            public void PringScore()
            {
                Console.WriteLine("打印分数");
            }

            public void SendScore()
            {
                Console.WriteLine("发送分数");
            }
        }


        public class Student : IStudentScore
        {
            public void PringScore()
            {
                Console.WriteLine("学生打印分数");
            }

            public void QueryScore()
            {
                Console.WriteLine("查询分数");
            }
        }

        public interface IStudentScore
        {
            void QueryScore();

            void PringScore();

        }

        public interface ITeacherScore
        {
            void AddScore();

            void DeleteScore();

            double GetSumScore();

            double GetAvgScore();

            void PringScore();

            void SendScore();
        }
    }
}