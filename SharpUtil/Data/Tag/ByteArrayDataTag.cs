namespace SharpUtil.Data.Tag;

public class ByteArrayDataTag : BaseDataTag
{
    public byte[] Value;

    public ByteArrayDataTag(byte[] value) {
        this.Value = value;
    }
    
    public override byte GetTagType()
    {
        return IDataTag.BYTE_ARRAY_DATA_TAG;
    }
    
    public static ByteArrayDataTag Read(BinaryReader dataInput)
    {
        int length = dataInput.ReadInt32();
        byte[] v = new byte[length];
        for(int j = 0; j < length; j++) {
            v[j] = dataInput.ReadByte();
        }
        return new ByteArrayDataTag(v);
    }

    public override Object GetValue()
    {
        List<byte> list = new List<byte>();
        foreach (var variable in Value)
        {
            list.Add(variable);
        }
        return StringUtil.FormatArray(Value);
    }

    public override void Write(BinaryWriter dataOutput)
    {
        dataOutput.Write(Value.Length);
        foreach (byte i in Value){
            dataOutput.Write(i);
        }
    }
}