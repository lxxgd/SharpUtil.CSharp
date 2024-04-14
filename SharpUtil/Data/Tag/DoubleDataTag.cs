namespace SharpUtil.Data.Tag;

public class DoubleDataTag: BaseDataTag
{
    public double Value;

    public DoubleDataTag(double value) {
        this.Value = value;
    }
    
    public override byte GetTagType()
    {
        return IDataTag.DOUBLE_DATA_TAG;
    }
    
    public static DoubleDataTag Read(BinaryReader dataInput)
    {
        return new DoubleDataTag(dataInput.ReadDouble());
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