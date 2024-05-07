using System.Net.Mime;
using SharpUtil.Command;

namespace Test;

public class ExitCommand : Command
{
    public override string CommandFormat => "exit";
    public override string CommandDescription => "退出程序";
    public override string CommandName => "exit";
    public override object? Execute(string[] args)
    {
        Program.running = false;
        return null;
    }
}