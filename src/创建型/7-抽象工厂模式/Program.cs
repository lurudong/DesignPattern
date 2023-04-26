namespace _7_抽象工厂导入
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //创建不同品牌键盘
            Console.ReadLine();
        }


    }

    public interface IKeyboard
    {

        void ShouBrand();
    }

    public class DellKeyboard : IKeyboard
    {
        public void ShouBrand()
        {
            Console.WriteLine("我是DELL品牌键盘");
        }
    }

    public class HPKeyboard : IKeyboard
    {
        public void ShouBrand()
        {
            Console.WriteLine("我是HP品牌键盘");
        }
    }

    public class XMKeyboard : IKeyboard
    {
        public void ShouBrand()
        {
            Console.WriteLine("我是XM品牌键盘");
        }
    }

    public class KeyBoardFactory
    {


        public static IKeyboard? GetKeyBoard(string board)
        {
            IKeyboard? keyboard = null!;
            switch (board)
            {
                case "Dell":
                    keyboard = new DellKeyboard();
                    break;
                case "HP":
                    keyboard = new HPKeyboard();
                    break;
                case "XM":
                    keyboard = new XMKeyboard();
                    break;
            }
            return keyboard;
        }
    }


    public interface IKeyBoardFactory
    {
        IKeyboard GetKeyBoard();
    }

    public class DellFactory : IKeyBoardFactory
    {
        public IKeyboard GetKeyBoard()
        {

            return new DellKeyboard();
        }
    }

    public class HPFactory : IKeyBoardFactory
    {
        public IKeyboard GetKeyBoard()
        {

            return new HPKeyboard();
        }
    }

    public class XMFactory : IKeyBoardFactory
    {
        public IKeyboard GetKeyBoard()
        {

            return new XMKeyboard();
        }
    }
}