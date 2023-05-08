namespace _3_6责任链模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //需要：请假
            //处理人： 项目经理 总监 老板
            //需求：Type Count

            RequestHandler jingLi = new RequestHandler("张三");
            RequestHandler zongJian = new RequestHandler("李四");
            RequestHandler boss = new RequestHandler("王五");
            Request request1 = new Request();
            request1.RequestType = "请假";
            request1.RequestCount = 5;

            Request request2 = new Request();
            request2.RequestType = "涨薪";
            request2.RequestCount = 2000;
            jingLi.HandleRequest("经理", request1);
            zongJian.HandleRequest("总监", request1);
            boss.HandleRequest("老板", request1);
            Console.WriteLine("---------------------------------");

            jingLi.HandleRequest("经理", request2);
            zongJian.HandleRequest("总监", request2);
            boss.HandleRequest("老板", request2);
            Console.ReadKey();
        }


    }

    public class Request
    {

        public string RequestType { get; set; }
        public int RequestCount { get; set; }
    }

    public class RequestHandler
    {

        public string Name { get; set; }

        public RequestHandler(string name)
        {
            Name = name;
        }

        ///问题一：所有要核心判断，都封装到了个方法中，高度耦合
        ///问题二：现在这代码，是模拟了个责任链，便不是真的责任链

        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="handleRole">处理当前请求的角色</param>
        /// <param name="request"></param>
        public void HandleRequest(string handleRole, Request request)
        {
            if (handleRole == "经理" && request.RequestType == "请假")
            {

                if (request.RequestCount <= 2)
                {
                    Console.WriteLine($"经理{this.Name}批准了孙权{request.RequestCount}天的请假");
                }
                else
                {
                    Console.WriteLine($"经理{this.Name}无权批准当前请求");
                }
            }
            else if (handleRole == "总监" && request.RequestType == "请假")
            {
                if (request.RequestCount >= 3 && request.RequestCount <= 6)
                {
                    Console.WriteLine($"总监{this.Name}批准了孙权{request.RequestCount}天的请假");
                }
                else
                {
                    Console.WriteLine($"总监{this.Name}无权批准当前请求");
                }
            }
            else if (handleRole == "老板")
            {

                if (request.RequestType == "请假" && request.RequestCount > 6 && request.RequestCount <= 10)
                {
                    Console.WriteLine($"老板{this.Name}批准了孙权{request.RequestCount}天的请假");
                }
                else if (request.RequestType == "涨薪" && request.RequestCount <= 1000)
                {
                    Console.WriteLine($"老板{this.Name}批准了孙权{request.RequestCount}块的涨薪");
                }
                else
                {
                    Console.WriteLine("滚，给脸不要脸，爱干不干！！！");
                }
            }
        }
    }
}