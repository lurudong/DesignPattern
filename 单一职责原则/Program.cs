namespace 单一职责原则
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.比如：当一个类只有在添加的时候才会触动类的改变，符合单一职责原则。
            //2.或者：当一个类中只有一个方法会存在修改的情况从而触动类的改变，且不再在类中新增方法时，也符合单一职责原则。
            Console.WriteLine("Hello, World!");
        }
    }



    //变化一：内部的变化，如果TelPhone内部的变化，任意之一，发生了改变，都会需要修改TelPhone，不符合单一职责
    //变化二：外部的变化，如果TelPhone需要加新的方法，也需求修改TelPhone

    //不符合单一职责
    //class TelPhone
    //{

    //    public void Diel(string number)
    //    {
    //        Console.WriteLine($"给{number}打电话");
    //    }

    //    public void HongUp(string phone)
    //    {
    //        Console.WriteLine($"挂掉{phone}电话");
    //    }

    //    public void SendMessage(string message)
    //    {

    //        Console.WriteLine($"发送{message}");
    //    }

    //    public void ReceiveMessage(string message)
    //    {
    //        Console.WriteLine($"接收{message}");
    //    }
    //}

    //明确需求:我们希望，有且只有一个原因（如添加功能），可引起TelPhone类发生变化。
    //思路:给每个方法，都提炼成一个按口，抽象成一种能力，然后分别写类，去实现接口，最终在TelPhone中，只进行使用-
    public interface IDial
    {
        void DielNumber(string phone_number);
    }

    public interface IHongUp
    {
        void HongUpNumbe(string phone_number);
    }

    public interface ISendMessage
    {
        void SendMessage(string message);
    }

    public interface IReceiveMessage
    {
        void ReceiveMessage(string message);
    }


    public class Dial : IDial
    {
        public void DielNumber(string phone_number)
        {
            Console.WriteLine($"给{phone_number}打电话");
        }
    }

    public class HongUp : IHongUp
    {
        public void HongUpNumbe(string phone_number)
        {
            Console.WriteLine($"挂掉{phone_number}电话");
        }
    }

    public class SendMessageImpl : ISendMessage
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"发送{message}");
        }
    }

    public class ReceiveMessageImpl : IReceiveMessage
    {
        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"接收{message}");
        }
    }


    public interface IPowerOn
    {
        void PowerOn();
    }

    public interface IPowerDown
    {
        void PowerDown();
    }

    public class PowerOnImpl : IPowerOn
    {
        public void PowerOn()
        {
            Console.WriteLine("开机");
        }
    }

    public class PowerDownImpl : IPowerDown
    {
        public void PowerDown()
        {
            Console.WriteLine("关机");
        }
    }


    //需要添加功能的时候就会发现变化
    public class TelPhone
    {
        private IDial _dial;
        private IHongUp _hongUp;
        private ISendMessage _sendMessage;
        private IReceiveMessage _receiveMessage;
        private IPowerOn _powerOn;
        private IPowerDown _powerDown;

        public void DielPhoneNumber(string phone_number)
        {
            _dial.DielNumber(phone_number);
        }

        public void HongUpNumber(string phone_number)
        {
            _hongUp.HongUpNumbe(phone_number);
        }

        public void SendMessage(string message)
        {

            _sendMessage.SendMessage(message);
        }

        public void ReceiveMessage(string message)
        {
            _receiveMessage.ReceiveMessage(message);
        }

        public void PowerOn()
        {

            _powerOn.PowerOn();
        }

        public void PowerDown()
        {
            _powerDown.PowerDown();
        }
    }


}