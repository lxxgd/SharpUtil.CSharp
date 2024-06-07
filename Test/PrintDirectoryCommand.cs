using SharpUtil;
using SharpUtil.Command;

namespace Test;

public class PrintDirectoryCommand : Command
{
    public override string CommandFormat => "pd <path>";
    public override string CommandDescription => "pd";
    public override string CommandName => "pd";
    public override object? Execute(string[] args)
    {
        if(args.Length == 0)
        {
            Console.WriteLine("未输入路径");
            return null; 
        }
        Console.WriteLine(StringUtil.PrintDirectory(args[0]));
        return null;
    }
}