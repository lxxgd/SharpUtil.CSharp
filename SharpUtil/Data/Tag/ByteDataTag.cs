namespace SharpUtil.Data.Tag;

public class ByteDataTag: BaseDataTag
{
    public byte Value;

    public ByteDataTag(byte value) {
        this.Value = value;
    }
    
    public override byte GetTagType()
    {
        return IDataTag.BYTE_DATA_TAG;
    }
    
    public static ByteDataTag Read(BinaryReader dataInput)
    {
        return new ByteDataTag(dataInput.ReadByte());
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