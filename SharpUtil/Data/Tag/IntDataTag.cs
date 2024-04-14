namespace SharpUtil.Data.Tag;

public class IntDataTag : BaseDataTag
{
    public int Value;

    public IntDataTag(int value) {
        this.Value = value;
    }
    
    public override byte GetTagType()
    {
        return IDataTag.INT_DATA_TAG;
    }
    
    public static IntDataTag Read(BinaryReader dataInput)
    {
        return new IntDataTag(dataInput.ReadInt32());
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