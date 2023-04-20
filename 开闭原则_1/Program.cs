namespace 开闭原则_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankClient bankClient = new BankClient();
            bankClient.BankType = "存钱";
            BankTeller bankTeller = new BankTeller();
            bankTeller.HandleProcess(bankClient);

            Console.ReadLine();
        }
    }

    public class BankClient
    {
        public string BankType { get; set; }
    }

    public class BankTeller
    {
        private BankProcess _bankProcess = new BankProcess();
        public void HandleProcess(BankClient bankClient)
        {
            switch (bankClient.BankType)
            {
                case "存钱":
                    _bankProcess.Deposite = new DepositeImpl();
                    _bankProcess.DepositeFunc();
                    break;
                case "取钱":
                    _bankProcess.DrawMoney = new DrawMoneyImpl();
                    _bankProcess.DrawMoneyFunc();
                    break;
                case "转账":
                    _bankProcess.Transfer = new TransferImpl();
                    _bankProcess.TransferFunc();
                    break;
                default:
                    Console.WriteLine("没法处理");
                    break;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class BankProcess
    {
        public IDeposite Deposite { get; set; }

        public IDrawMoney DrawMoney { get; set; }

        public ITransfer Transfer { get; set; }

        public void DepositeFunc()
        {
            this.Deposite.Deposited();
        }

        public void DrawMoneyFunc()
        {
            this.DrawMoney.DrawMoneyd();
        }

        public void TransferFunc()
        {
            this.Transfer.Transferd();
        }
    }

    public interface IDeposite
    {
        void Deposited();
    }

    public interface IDrawMoney
    {
        void DrawMoneyd();
    }

    public interface ITransfer
    {
        void Transferd();
    }

    public class DepositeImpl : IDeposite
    {
        public void Deposited()
        {
            Console.WriteLine("用户存钱");
        }
    }

    public class DrawMoneyImpl : IDrawMoney
    {
        public void DrawMoneyd()
        {
            Console.WriteLine("用户取钱");
        }
    }

    public class TransferImpl : ITransfer
    {
        public void Transferd()
        {
            Console.WriteLine("用户转账");
        }
    }
}