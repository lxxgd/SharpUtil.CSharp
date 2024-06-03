using SharpUtil;
using SharpUtil.Command;
using SharpUtil.Data.Tag;
using SharpUtil.Logging;

namespace Test
{
    public class Program
    {
        public static TestSaveData data = new TestSaveData();
        public static readonly SimpleLogger logger = new SimpleLogger("Main","./logs/");
        public static bool running;
        public static readonly CommandManager commandManager = new CommandManager();

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
            data.Save();
            data = new TestSaveData();
            logger.Info(StringUtil.GetRandomString2(32));
            data.Load();
            try
            {
                string[] strings = new string[] { "s", null };  
                ValidateUtil.NoNullElements(strings);
            }
            catch(Exception ex) 
            {
                logger.Error(ex.GetExceptionMessage());
            }
            while (running)
            {
                string? input =  Console.ReadLine();
                if(!string.IsNullOrEmpty(input) && input[0] != ' ')
                    commandManager.Execute(input);
            }
        }

        struct Test 
        {
            private int max;

            public Test() { this.max = 16;}
        }
    }
}
