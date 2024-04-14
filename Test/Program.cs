using SharpUtil;
using SharpUtil.Data.Tag;
using SharpUtil.Logging;

namespace Test
{
    public class Program
    {
        private static TestSaveData data = new TestSaveData();
        public static readonly SimpleLogger Logger = new SimpleLogger("Main","./logs/");

        private static void Main()
        {
            Thread.CurrentThread.Name = "main thread";
            Console.WriteLine("Hello, World!");
            data.uuid.Add(new Guid("976c95e5-bae7-493c-a087-61158d75598a"));
            data.uuid.Add(new Guid("3d5d1df5-3c01-4ba7-9c34-e6c87b3bae9c"));
            data.uuid.Add(new Guid("66bf2d19-ab7d-447c-a6a8-0e7e9f6f0b71"));
            data.anInt = 114514;
            data.anInt2 = 666;
            data.anInt3 = int.MaxValue;
            data.str = "aaa";
            data.Save();
            data = new TestSaveData();
            data.Load();
            Console.WriteLine(data.anInt);
            foreach (Guid guid in data.uuid)
            {
                Console.WriteLine(guid.ToString());
            }
            Console.WriteLine(DataTagUtil.GetRootCompoundTagTagTree("data.compoundDataTag1",data.compoundDataTag1));
            string s = "a\nb\nc\nd";
            Console.WriteLine(StringUtil.AddToLineHeader(s,"-"));
            Console.WriteLine(StringUtil.PrintDirectory(@"F:\sp\SharpUtil\Test"));
            Logger.Info("sss");
            for (int i = 0; i < 10; i++)
            {
                Logger.Info("1:"+StringUtil.GetRandomString(10));
            }
            for (int i = 0; i < 100; i++)
            {
                Logger.Info("2:"+StringUtil.GetRandomString2(32));
            }
            Console.ReadLine();
        }
    }
}
