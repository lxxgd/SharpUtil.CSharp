namespace SharpUtil.Command;

public abstract class Command
{
    public abstract string CommandFormat
    {
        get;
    }
    public abstract string CommandDescription
    {
        get;
    }
    public abstract string CommandName
    {
        get;
    }

    public CommandManager Owner { get; set; }

    public abstract object? Execute(string[] args);

    public override bool Equals(object? obj)
    {
        return obj is Command command && command.CommandName == CommandName;
    }

    public override int GetHashCode()
    {
        int hash = 27;
        hash += 21 * CommandName.GetHashCode();
        return hash;
    }
}