using SharpUtil;
using SharpUtil.Command;
using SharpUtil.Data.Tag;

namespace Test;

public class PrintDirectoryCommand : Command
{
    public override string CommandFormat => "pd <path>";
    public override string CommandDescription => "pd";
    public override string CommandName => "pd";
    public override object? Execute(string[] args)
    {
        Console.WriteLine(StringUtil.PrintDirectory(args[0]));
        return null;
    }
}