namespace _8_抽象工厂模式实现
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //创建不同品牌（Dell,HP）的鼠标，键盘、主机

            AbastractFactory abastractFactory =
                new DellFactory();
            var keyBoard = abastractFactory.GetKeyBoard();
            var mouse = abastractFactory.GetMouse();
            keyBoard.ShowKeyBoardBrand();
            mouse.ShowMouseBrand();
            Console.ReadLine();
        }
    }


    public interface IKeyBoard
    {
        void ShowKeyBoardBrand();
    }


    public interface IMouse
    {
        void ShowMouseBrand();
    }

    public class DellKeyBoard : IKeyBoard
    {
        public void ShowKeyBoardBrand()
        {
            Console.WriteLine("我是DELL品牌键盘");
        }
    }

    public class HPKeyBoard : IKeyBoard
    {
        public void ShowKeyBoardBrand()
        {
            Console.WriteLine("我是HP品牌键盘");
        }
    }

    public class XMKeyBoard : IKeyBoard
    {
        public void ShowKeyBoardBrand()
        {
            Console.WriteLine("我是MX品牌键盘");
        }
    }

    public class DellMouse : IMouse
    {
        public void ShowMouseBrand()
        {
            Console.WriteLine("我是DELL品牌鼠标");
        }
    }

    public class HPMouse : IMouse
    {
        public void ShowMouseBrand()
        {
            Console.WriteLine("我是HP品牌鼠标");
        }
    }

    public class XMMouse : IMouse
    {
        public void ShowMouseBrand()
        {
            Console.WriteLine("我是XM品牌鼠标");
        }
    }

    public interface AbastractFactory
    {

        IKeyBoard GetKeyBoard();
        IMouse GetMouse();
    }


    public class DellFactory : AbastractFactory
    {
        public IKeyBoard GetKeyBoard()
        {
            return new DellKeyBoard();
        }

        public IMouse GetMouse()
        {
            return new DellMouse();
        }

    }

    public class HPlFactory : AbastractFactory
    {
        public IKeyBoard GetKeyBoard()
        {
            return new HPKeyBoard();
        }

        public IMouse GetMouse()
        {
            return new HPMouse();
        }

    }

    public class XMlFactory : AbastractFactory
    {
        public IKeyBoard GetKeyBoard()
        {
            return new XMKeyBoard();
        }

        public IMouse GetMouse()
        {
            return new XMMouse();
        }

    }
}