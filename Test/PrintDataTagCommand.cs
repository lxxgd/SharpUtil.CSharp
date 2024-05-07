using SharpUtil.Command;
using SharpUtil.Data.Tag;

namespace Test;

public class PrintDataTagCommand : Command
{
    public override string CommandFormat => "pdt";
    public override string CommandDescription => "pdt";
    public override string CommandName => "pdt";
    public override object? Execute(string[] args)
    {
        Console.WriteLine(Program.data.anInt);
        foreach (Guid guid in Program.data.uuid)
        {
            Console.WriteLine(guid.ToString());
        }
        Console.WriteLine(DataTagUtil.GetRootCompoundTagTagTree("data.compoundDataTag1",Program.data.compoundDataTag1));
        return null;
    }
}