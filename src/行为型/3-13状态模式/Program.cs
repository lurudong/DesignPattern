namespace _3_13状态模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkerContext workerContext = new WorkerContext(new Morning());
            workerContext.Hour = 10;
            workerContext.Working();

            workerContext.Hour = 13;
            workerContext.Working();

            workerContext.Hour = 16;
            workerContext.Working();


            workerContext.Hour = 21;
            workerContext.Working();
            //workerContext.Working();
            Console.ReadLine();
        }
    }

    public class WorkerContext
    {

        //State状态，表示当前对象状态
        public State State { get; set; }

        public double Hour { get; set; }

        public bool IsFinish { get; set; }

        public void Working()
        {
            State.SetState(this);
        }
        public WorkerContext(State state)
        {
            State = state;
        }
    }
    public abstract class State
    {

        public abstract void SetState(WorkerContext workerContext);
    }

    public class Morning : State
    {
        public override void SetState(WorkerContext workerContext)
        {

            if (workerContext.Hour <= 12)
            {
                Console.WriteLine("上午精神非常好");
            }
            else
            {
                workerContext.State = new Noon();
                workerContext.Working();
            }
        }
    }

    public class Noon : State
    {
        public override void SetState(WorkerContext workerContext)
        {
            if (workerContext.Hour <= 14)
            {
                Console.WriteLine("中午我要睡觉");
            }
            else
            {
                workerContext.State = new AfterNoon();
                workerContext.Working();
            }
        }
    }

    public class AfterNoon : State
    {
        public override void SetState(WorkerContext workerContext)
        {
            if (workerContext.Hour <= 18)
            {
                Console.WriteLine("下午摸鱼");
            }
            else
            {
                workerContext.State = new Evening();
                workerContext.Working();
            }
        }
    }

    public class Evening : State
    {
        public override void SetState(WorkerContext workerContext)
        {
            if (workerContext.Hour <= 24)
            {
                if (workerContext.IsFinish)
                {
                    Console.WriteLine("回家");
                }
                else
                {
                    Console.WriteLine("继续加班");
                }

            }

        }
    }
}