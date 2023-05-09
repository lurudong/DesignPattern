using System.Text;

namespace _3_15解释器模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //cucumber is a good teacher
            //黄瓜是个色批。

            string str = "cucumber is a good teacher";
            StringBuilder sb = new StringBuilder();
            List<IExpression> list = new List<IExpression>();
            var strs = str.Split('.', StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in strs)
            {
                var item1 = item.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var item2 in item1)
                {
                    list.Add(new TextExpression(item2));
                }
                list.Add(new SymbolExpression("."));
            }

            foreach (var item in list)
            {
                item.Interpret(sb);

            }
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }
    }

    public interface IExpression
    {

        void Interpret(StringBuilder sb);
    }

    public class TextExpression : IExpression
    {
        public string Text { get; set; }

        public TextExpression(string text)
        {
            Text = text;
        }

        public void Interpret(StringBuilder sb)
        {

            sb.Append(Context.GetChinese(Text.ToLower()));
        }
    }

    public static class Context
    {
        private static Dictionary<string, string> _dic = new Dictionary<string, string>();
        static Context()
        {
            _dic["cucumber"] = "黄瓜";
            _dic["is"] = "是";
            _dic["a"] = "一个";
            _dic["good"] = "色";
            _dic["teacher"] = "批";
        }

        public static string GetChinese(string str)
        {
            return _dic[str];
        }
    }

    public class SymbolExpression : IExpression
    {
        public string Text { get; set; }

        public SymbolExpression(string text)
        {
            Text = text;
        }
        public void Interpret(StringBuilder sb)
        {
            switch (Text)
            {
                case ".":
                    sb.Append("。");
                    break;
            }
        }
    }
}