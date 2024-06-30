namespace SharpUtil.Data.Tag;

public class BooleanDataTag : BaseDataTag
{
    public bool Value;

    public BooleanDataTag(bool value)
    {
        this.Value = value;
    }

    public override byte GetTagType()
    {
        return IDataTag.BOOLEAN_DATA_TAG;
    }

    public static BooleanDataTag Read(BinaryReader dataInput)
    {
        return new BooleanDataTag(dataInput.ReadBoolean());
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