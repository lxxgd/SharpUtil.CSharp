namespace SharpUtil.Data.Tag;

public class StringDataTag: BaseDataTag
{
    public string Value;

    public StringDataTag(string value) {
        this.Value = value;
    }
    
    public override byte GetTagType()
    {
        return IDataTag.STRING_DATA_TAG;
    }
    
    public static StringDataTag Read(BinaryReader dataInput)
    {
        return new StringDataTag(dataInput.ReadString());
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