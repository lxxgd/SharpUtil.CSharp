namespace SharpUtil.Data.Tag;

public class FloatDataTag: BaseDataTag
{
    public float Value;

    public FloatDataTag(float value) {
        this.Value = value;
    }
    
    public override byte GetTagType()
    {
        return IDataTag.FLOAT_DATA_TAG;
    }
    
    public static FloatDataTag Read(BinaryReader dataInput)
    {
        return new FloatDataTag(dataInput.ReadSingle());
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