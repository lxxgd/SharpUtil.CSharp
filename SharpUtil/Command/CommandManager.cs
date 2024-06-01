namespace SharpUtil.Command;

public class CommandManager
{
    public List<Command> Commands { get; } = new List<Command>();
    public static bool Debug { get; set; } = false;

    public CommandManager()
    {
        Register(new HelpCommand());
    }

    public virtual object? Execute(string? command)
    {
        if (command == null)
        {
            Console.WriteLine("Unknown Command");
            return null;
        }
        string[] args = command.TrimEnd().Split(' ');
        string name = args[0];
        args = args.Skip(1).ToArray();
        if (Debug)
        {
            Console.WriteLine(name);
            foreach (string str in args)
            {
                Console.WriteLine(str);
            }
        }
        foreach (Command command1 in Commands)
        {
            if (command1.CommandName == name)
            {
                return command1.Execute(args);
            }
        }
        Console.WriteLine("Unknown Command");
        return null;
    }
    
    public void Register(Command command)
    {
        command.Owner = this;
        if(!Commands.Contains(command))
            Commands.Add(command);
    }
}