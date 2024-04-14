namespace SharpUtil.Data.Tag;

public class LongDataTag : BaseDataTag
{
    public long Value;

    public LongDataTag(long value)
    {
        this.Value = value;
    }

    public override byte GetTagType()
    {
        return IDataTag.LONG_DATA_TAG;
    }

    public static LongDataTag Read(BinaryReader dataInput)
    {
        return new LongDataTag(dataInput.ReadInt64());
    }

    public override object GetValue()
    {
        return Value;
    }

    public override void Write(BinaryWriter dataOutput)
    {
        dataOutput.Write(Value);
    }
}