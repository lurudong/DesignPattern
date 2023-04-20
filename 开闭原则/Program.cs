namespace 开闭原则
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //使用代码,描述不同需求用户去银行办理不同的业务：
            //1、在这程序中，会出现多个对象 ？
            //2、每个对象的属性和行为

            //1.用户 属性：记录不同的用户(存钱、取钱、转账....)
            //2.银行柜员：帮助我们用户处理不同的需求
            //3.银行业务系统：处理存钱，取钱等需求操作系统 

            BankClient bankClient = new BankClient();
            bankClient.BankType = "存钱";
            BankTeller bankTeller = new BankTeller();
            bankTeller.HandleProcess(bankClient);
            Console.ReadLine();
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
                        _bankProcess.Deposite();
                        break;
                    case "取钱":
                        _bankProcess.DrawMoney();
                        break;
                    case "转账":
                        _bankProcess.Transfer();
                        break;
                    default:
                        Console.WriteLine("没法处理");
                        break;
                }
            }
        }

        //不符合单一职责
        public class BankProcess
        {

            public void Deposite()
            {
                Console.WriteLine("用户存钱");
            }

            public void DrawMoney()
            {
                Console.WriteLine("取钱");
            }

            public void Transfer()
            {
                Console.WriteLine("处理用户转账");

            }
        }
    }
}