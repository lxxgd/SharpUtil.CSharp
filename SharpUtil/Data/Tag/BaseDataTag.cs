namespace SharpUtil.Data.Tag;

public abstract class BaseDataTag : IDataTag
{
    public abstract object GetValue();
    public abstract void Write(BinaryWriter dataOutput);
    public abstract byte GetTagType();

    public override string ToString()
    {
        return "value:" + GetValue();
    }
}