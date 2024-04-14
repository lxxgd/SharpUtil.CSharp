namespace SharpUtil.Data.Tag;

public class IntArrayDataTag : BaseDataTag
{
    public int[] Value;

    public IntArrayDataTag(int[] value) {
        this.Value = value;
    }
    
    public override byte GetTagType()
    {
        return IDataTag.INT_ARRAY_DATA_TAG;
    }
    
    public static IntArrayDataTag Read(BinaryReader dataInput)
    {
        int length = dataInput.ReadInt32();
        int[] v = new int[length];
        for(int j = 0; j < length; j++) {
            v[j] = dataInput.ReadInt32();
        }
        return new IntArrayDataTag(v);
    }

    public override void Write(BinaryWriter dataOutput)
    {
        dataOutput.Write(Value.Length);
        foreach (int i in Value){
            dataOutput.Write(i);
        }
    }
    
    public override Object GetValue()
    {
        List<int> list = new List<int>();
        foreach (var variable in Value)
        {
            list.Add(variable);
        }
        return StringUtil.FormatList(list);;
    }
}