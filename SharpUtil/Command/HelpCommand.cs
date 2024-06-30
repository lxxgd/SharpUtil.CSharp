namespace SharpUtil.Command;

public class HelpCommand : Command
{
    public override string CommandFormat => "help";

    public override string CommandDescription => "获取所有命令";

    public override string CommandName => "help";

    public override object Execute(string[] args)
    {
        string[] strings = new string[] { };
        Console.WriteLine("Command List:");
        foreach (Command command in Owner.Commands)
        {
            Console.WriteLine(command.CommandFormat + "        " + command.CommandDescription);
            strings.Append(command.CommandFormat);
        }
        return strings;
    }
}