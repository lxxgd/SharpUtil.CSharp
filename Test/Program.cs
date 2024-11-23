using SharpUtil;
using SharpUtil.Command;
using SharpUtil.Logging;
using System.Data;
using ExtendedNumerics;
using SharpUtil.Data.Tag;

namespace Test
{
    public class Program
    {
        public static TestSaveData data = new TestSaveData();
        public static readonly SimpleLogger logger = new("Main", "./logs/");
        public static bool running;
        public static readonly CommandManager commandManager = new();

        private static void Main()
        {
            Thread.CurrentThread.Name = "main thread";
            running = true;
            commandManager.Register(new ExitCommand());
            commandManager.Register(new PrintDirectoryCommand());
            commandManager.Register(new PrintDataTagCommand());
            Console.WriteLine("Hello, World!");
            data.uuid.Add(new Guid("976c95e5-bae7-493c-a087-61158d75598a"));
            data.uuid.Add(new Guid("3d5d1df5-3c01-4ba7-9c34-e6c87b3bae9c"));
            data.uuid.Add(new Guid("66bf2d19-ab7d-447c-a6a8-0e7e9f6f0b71"));
            data.anInt = 114514;
            data.anInt2 = 666;
            data.anInt3 = int.MaxValue;
            data.str = "aaa";
            data.de = 15;
            data.Save();
            data = new TestSaveData();
            logger.Info(StringUtil.GetRandomString2(32));
            data.Load();
            try
            {
            }
            catch (Exception ex)
            {
                logger.Error(ex.GetExceptionMessage());
            }
            DataTable table = new();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("name", typeof(string));
            table.Rows.Add(1, "a");
            table.Rows.Add(2, "b");
            table.Rows.Add(3, "c");

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine(row["id"] + " " + row["name"]);
            }

            Console.WriteLine("原始Map:");

            Map2D<string> map = new(3, 3);
            map[0, 0] = "a";
            map[1, 1] = "b";
            map[2, 2] = "c";

            Console.Write(map.Map2DToString());

            Console.WriteLine("交换元素:");

            map.Exchange(0, 0, 1, 1);
            map.Exchange(1, 1, 2, 2);
            map.Exchange(2, 2, 0, 0);

            Console.Write(map.Map2DToString());

            Console.WriteLine("重新设定大小并设置元素:");

            map.Resize(5, 5);
            map[3, 3] = "d";
            map[4, 4] = "e";

            Console.Write(map.Map2DToString());
            Console.WriteLine(map.ToStringForEnumerableWithNull());

            Console.WriteLine("复制元素实验:");

            Map2D<string> map2 = new(4, 4);
            map2.Fill("x");
            Map2D<string> map3 = new(5, 5);
            map3.CopyFrom(map2, false);//不重新设定大小
            Console.WriteLine("不重新设定大小:");
            Console.Write(map3.Map2DToString());
            map3.CopyFrom(map2, true);//重新设定大小
            Console.WriteLine("重新设定大小:");
            Console.Write(map3.Map2DToString());

            LimitedQueue<int> queue = new(5);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            Console.WriteLine("队列满时再入队:");
            queue.Enqueue(6);
            Console.WriteLine(queue.ToStringForEnumerable());

            MemoryStream memoryStream = new();
            BinaryWriter writer = new(memoryStream);
            CompoundDataTag compoundDataTag = new();
            compoundDataTag.PutInt("Int", 123);
            compoundDataTag.PutString("String", "Hello, World!");
            compoundDataTag.PutFloat("Float", 3.14f);
            compoundDataTag.Write(writer);

            MemoryStream memoryStream2 = new(memoryStream.ToArray());
            BinaryReader reader = new(memoryStream2);
            CompoundDataTag tag = CompoundDataTag.Read(reader);
            Console.WriteLine(tag.GetInt("Int"));
            Console.WriteLine(tag.GetString("String"));
            Console.WriteLine(tag.GetFloat("Float"));
            Console.WriteLine(memoryStream2.ToArray().ToStringForEnumerable());
   
            Console.WriteLine(10000- float.PositiveInfinity);

            while (running)
            {
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input[0] != ' ')
                    commandManager.Execute(input);
            }
        }

        static void method()
        {
            Test t = new Test();

        }

        struct Test
        {
            public int max;
            public int Min { get; set; } = 15;

            public Test() { max = 16; }
        }
    }
}
