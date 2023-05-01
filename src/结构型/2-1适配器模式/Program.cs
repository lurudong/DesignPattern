namespace _2_1适配器模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPhoneCharge phoneCharge = new PhoneChargeAdapter();
            phoneCharge.PhoneCharge();
            Console.ReadKey();
        }
    }

    //安卓充电线
    public class AndroidChargeAdaptee
    {

        public void AndroidCharge()
        {
            Console.WriteLine("安卓充电线充电");
        }
    }

    //苹果手机转接接口
    public interface IPhoneCharge
    {
        void PhoneCharge();
    }

    /// <summary>
    /// 转接口
    /// </summary>
    public class PhoneChargeAdapter : IPhoneCharge
    {
        //在Adapter当中，封装一个Adapter对象，这个对象才是实现功能的对象
        private AndroidChargeAdaptee _androidChageAdaptee = new AndroidChargeAdaptee();
        public void PhoneCharge()
        {
            _androidChageAdaptee.AndroidCharge();
        }
    }

}