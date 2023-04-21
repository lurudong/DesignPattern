namespace 依赖倒转原则
{
    /// <summary>
    /// 歌手唱不同中国的歌曲
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //歌手唱中国的歌曲
            //歌手 对象一：唱哥
            //歌曲 ：返回歌曲的歌词

            #region
            //不满足，没有依赖抽象，垃圾代码，代码冗余。不合适开闭原则，单一职责
            //高层模块不应该依赖低层模块
            Singer singer = new Singer();
            singer.SingerASong(new ChineseSong());
            singer.SingerBSong(new EnglishSong());
            #endregion
            #region 
            //依赖抽象
            Console.WriteLine("---------------重构后-----------------");
            SingerImpl singerImpl = new SingerImpl();
            singerImpl.SingerSong(new ChineseSongImpl());
            singerImpl.SingerSong(new EnglishSongImpl());
            #endregion
            //依赖注入：在客户类中（调用 者/高层模块中），定义一个注入点，用来注入服务类（低层模块）
            Console.ReadLine();
        }
    }

    public interface ISongWard
    {
        string GetSongWards();
    }

    public class ChineseSongImpl : ISongWard
    {
        public string GetSongWards()
        {
            return "中国歌曲";
        }
    }

    public class EnglishSongImpl : ISongWard
    {
        public string GetSongWards()
        {
            return "外国歌曲";
        }
    }

    public class ChineseSong
    {
        public string GetSongWards()
        {
            return "中国歌曲";
        }
    }

    public class EnglishSong
    {
        public string GetEnglishSong()
        {
            return "外国歌曲";
        }
    }

    //Singer作为高层模块，目前是严格依赖低层模块
    //不符合依赖倒置原则，赖倒置原则是核心  ---->开闭原则--->单一职责原则

    public class Singer
    {

        public void SingerASong(ChineseSong chineseSong)
        {
            Console.WriteLine($"歌手正在唱{chineseSong.GetSongWards()}");
        }

        public void SingerBSong(EnglishSong englishSong)
        {
            Console.WriteLine($"歌手正在唱{englishSong.GetEnglishSong()}");
        }
    }

    public class SingerImpl
    {
        public void SingerSong(ISongWard songWard)
        {
            Console.WriteLine($"歌手正在唱{songWard.GetSongWards()}");
        }
    }
}