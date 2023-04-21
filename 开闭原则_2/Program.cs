namespace 开闭原则_2
{
    internal class Program
    {
        //封装，抽象不是目的，目的是封装变化。
        //只有把变化封装了，我们的程序，才能做单一、才能做到开闭封闭
        static void Main(string[] args)
        {
            //在类中，将每一个方法都进行接口抽象，也是比较极端。所以，还是根据实际的业务流程，减少接口的封装（根据业务，进行高度抽象封装）
            //BankClient bankClient = new BankClient();
            //bankClient.BankType = "存钱";
            //BankTeller bankTeller = new BankTeller();
            //bankTeller.HandleProcess(bankClient);

            //没有什么包一层解决不了的，假如有再包一层

            #region 重构后的
            //创建存钱对象
            IBankClient bankClient = new DrawMoneyClient();  //new DepositeClient();
            //创建业务员对象
            BankTeller1 bankTeller1 = new BankTeller1();
            bankTeller1.HandleProcess(bankClient);
            #endregion
            Console.ReadLine();
        }
    }



    public class BankClient
    {
        public string BankType { get; set; }
    }


    //通过抽象（接口）封装变化

    public interface IBankClient
    {
        //变化是什么？
        IBankProcess GetBankProcess();
    }

    public class DepositeClient : IBankClient
    {
        public IBankProcess GetBankProcess()
        {
            return new DepositeImpl();
        }
    }

    public class DrawMoneyClient : IBankClient
    {
        public IBankProcess GetBankProcess()
        {
            return new DrawMoneyImpl();
        }
    }


    public class TransferClient : IBankClient
    {
        public IBankProcess GetBankProcess()
        {
            return new TransferImpl();
        }
    }


    public class BankTeller
    {
        private IBankProcess _bankProcess;
        public void HandleProcess(BankClient bankClient)
        {
            //这里也会发生变化
            switch (bankClient.BankType)
            {
                case "存钱":
                    _bankProcess = new DepositeImpl();
                    _bankProcess.BankProcess();
                    break;
                case "取钱":
                    _bankProcess = new DrawMoneyImpl();
                    _bankProcess.BankProcess();
                    break;
                case "转账":
                    _bankProcess = new TransferImpl();
                    _bankProcess.BankProcess();
                    break;
                default:
                    Console.WriteLine("没法处理");
                    break;
            }
        }
    }
    public class BankTeller1
    {
        private IBankProcess _bankProcess;
        public void HandleProcess(IBankClient bankClient)
        {
            ///用户端调用 自己的GetBankProcess 方法，返回我们的业务处理对象（IBankProcess）
            _bankProcess = bankClient.GetBankProcess();
            //业务处理对象，调用 BankProcess执行业务操作方法
            _bankProcess.BankProcess();
        }
    }
    public interface IBankProcess
    {

        void BankProcess();
    }




    public class DepositeImpl : IBankProcess
    {
        public void BankProcess()
        {
            Console.WriteLine("用户存钱");
        }


    }

    public class DrawMoneyImpl : IBankProcess
    {
        public void BankProcess()
        {
            Console.WriteLine("用户取钱");
        }


    }

    public class TransferImpl : IBankProcess
    {
        public void BankProcess()
        {
            Console.WriteLine("用户转账");
        }


    }


}