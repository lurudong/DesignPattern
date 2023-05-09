namespace _3_12状态模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //客厅大灯的打开和关闭
            ContextLigth contextLigth = new ContextLigth(new TurnOff());

            contextLigth.Turn();
            contextLigth.Turn();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 客厅对象，状态模式的入口，（发生状态改变的对象）
    /// </summary>
    public class ContextLigth
    {
        //维护了一个抽象的State对象 
        public State State { get; set; }

        public ContextLigth(State state)
        {
            State = state;
        }

        /// <summary>
        /// 我们在外面，打开或者关闭的操作
        /// 当这个方法，一但被执行，就是说明状态发生了改变，说需要执行具体状态类中的方法，来改变大灯的状态
        /// </summary>
        public void Turn()
        {
            //调用具体的状态代码
            this.State.TurnLight(this);
        }
    }

    /// <summary>
    /// 状态对象
    /// </summary>
    public abstract class State
    {
        public abstract void TurnLight(ContextLigth context);
    }

    /// <summary>
    /// 打开
    /// </summary>
    public class TurnOn : State
    {
        public override void TurnLight(ContextLigth context)
        {
            Console.WriteLine("把大灯关闭");
            //改变ContextLigth状态

            context.State = new TurnOff();

        }
    }

    public class TurnOff : State
    {
        public override void TurnLight(ContextLigth context)
        {
            Console.WriteLine("把大灯打开");
            context.State = new TurnOn();
        }
    }


}