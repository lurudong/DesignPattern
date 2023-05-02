namespace _2_5外观模式
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Police police = new Police();
            //police.GetHuJi();

            //Street street = new Street();
            //street.GetHuKou();

            //Hospital hospital = new Hospital();
            //hospital.GetBorn();
            DaTing daTing = new DaTing();
            daTing.KaiZhengMing();
            Console.ReadLine();
        }
    }


    public class DaTing
    {
        private Police _police = new Police();
        private Street _street = new Street();
        private Hospital _hospital = new Hospital();

        public void KaiZhengMing()
        {
            _police.GetHuJi();
            _street.GetHuKou();
            _hospital.GetBorn();
        }
    }
    public class Police
    {
        public void GetHuJi()
        {
            Console.WriteLine("开具户籍证明");
        }
    }

    public class Street
    {

        public void GetHuKou()
        {
            Console.WriteLine("开具户口证明");
        }
    }

    public class Hospital
    {
        public void GetBorn()
        {
            Console.WriteLine("开具出生证明");
        }
    }
}