namespace _2_4代理模式应用
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RealOrder realOrder = new RealOrder(12, "张三", "王五");
            ProxyOrder proxyOrder = new ProxyOrder(realOrder);
            proxyOrder.SetOrderNum(200, "王五");
            Console.WriteLine(proxyOrder.GetOrderNum());
            Console.ReadLine();
        }
    }

    /// <summary>
    /// 封装了实体对象和代理对象的公用接口
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// 获取订单中，产品的名称
        /// </summary>

        void SetProductName(string productName, string user);

        int GetOrderNum();

        void SetOrderNum(int orderNum, string user);

        string GetOrderUser();

        void SetOrderUser(string orderUserName, string user);
    }


    public class RealOrder : IOrder
    {
        public RealOrder(int productCount, string productName, string orderUser)
        {
            ProductCount = productCount;
            ProductName = productName;
            OrderUser = orderUser;
        }

        public int ProductCount { get; set; }

        public string ProductName { get; set; }

        public string OrderUser { get; set; }

        public int GetOrderNum()
        {
            return ProductCount;
        }

        public string GetOrderUser()
        {
            return OrderUser;
        }

        public void SetOrderNum(int orderNum, string user)
        {
            ProductCount = orderNum;

        }

        public void SetOrderUser(string orderUserName, string user)
        {

            OrderUser = orderUserName;
        }

        public void SetProductName(string productName, string user)
        {
            ProductName = productName;
        }
    }

    public class ProxyOrder : IOrder
    {
        private readonly RealOrder _realOrder;
        public ProxyOrder(RealOrder realOrder)
        {
            _realOrder = realOrder;
        }
        public int GetOrderNum()
        {
            return _realOrder.GetOrderNum();
        }

        public string GetOrderUser()
        {
            return _realOrder.GetOrderUser();
        }

        public void SetOrderNum(int orderNum, string user)
        {
            //对权限进行判断，有权限的，可以访问，没有权限的，不行
            if (user != null && user.Equals(this._realOrder.OrderUser))
            {
                _realOrder.SetOrderNum(orderNum, user);
            }
            else
            {

                Console.WriteLine("没有权限修改订单数据");
            }

        }

        public void SetOrderUser(string orderUserName, string user)
        {
            if (user != null && user.Equals(this._realOrder.OrderUser))
            {
                _realOrder.SetOrderUser(orderUserName, user);
            }
            else
            {

                Console.WriteLine("没有权限修改订单数据");
            }
        }

        public void SetProductName(string productName, string user)
        {
            if (user != null && user.Equals(this._realOrder.OrderUser))
            {
                _realOrder.SetProductName(productName, user);
            }
            else
            {

                Console.WriteLine("没有权限修改订单数据");
            }
        }
    }
}