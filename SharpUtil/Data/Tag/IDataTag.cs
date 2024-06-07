using System.Text;

namespace SharpUtil.Data.Tag;

public interface IDataTag
{
    const byte END_DATA_TAG = 0;
    const byte COMPOUND_DATA_TAG = 1;
    const byte INT_DATA_TAG = 2;
    const byte INT_ARRAY_DATA_TAG = 3;
    const byte LIST_DATA_TAG = 4;
    const byte STRING_DATA_TAG = 5;
    const byte BOOLEAN_DATA_TAG = 6;
    const byte LONG_DATA_TAG = 7;
    const byte FLOAT_DATA_TAG = 8;
    const byte DOUBLE_DATA_TAG = 9;
    const byte BYTE_DATA_TAG = 10;
    const byte BYTE_ARRAY_DATA_TAG = 11;
    const byte DECIMAL_DATA_TAG = 12;

    public delegate IDataTag read_data_tag_delegate(byte b, BinaryReader binaryReader);
    private static readonly Dictionary<byte, read_data_tag_delegate> read_Data_Tag_Delegates = [];

    void Write(BinaryWriter dataOutput);
    byte GetTagType();
    object GetValue();

    static IDataTag() 
    {
        RegisterDataTag(COMPOUND_DATA_TAG, (id, dataInput) => CompoundDataTag.Read(dataInput));
        RegisterDataTag(INT_DATA_TAG, (id, dataInput) => IntDataTag.Read(dataInput));
        RegisterDataTag(INT_ARRAY_DATA_TAG, (id, dataInput) => IntArrayDataTag.Read(dataInput));
        RegisterDataTag(LIST_DATA_TAG, (id, dataInput) => ListDataTag.Read(dataInput));
        RegisterDataTag(STRING_DATA_TAG, (id, dataInput) => StringDataTag.Read(dataInput));
        RegisterDataTag(BOOLEAN_DATA_TAG, (id, dataInput) => BooleanDataTag.Read(dataInput));
        RegisterDataTag(LONG_DATA_TAG, (id, dataInput) => LongDataTag.Read(dataInput));
        RegisterDataTag(FLOAT_DATA_TAG, (id, dataInput) => FloatDataTag.Read(dataInput));
        RegisterDataTag(DOUBLE_DATA_TAG, (id, dataInput) => DoubleDataTag.Read(dataInput));
        RegisterDataTag(BYTE_DATA_TAG, (id, dataInput) => ByteDataTag.Read(dataInput));
        RegisterDataTag(BYTE_ARRAY_DATA_TAG, (id, dataInput) => ByteArrayDataTag.Read(dataInput));
        RegisterDataTag(DECIMAL_DATA_TAG, (id, dataInput) => DecimalDataTag.Read(dataInput));
    }
    
    static IDataTag? ReadTag(byte b, BinaryReader dataInput) {
        IDataTag? tag = null;

        if(b > read_Data_Tag_Delegates.Count) 
        {
            throw new ArgumentException($"Unkown DataTag ID: {b}");
        }
        tag = read_Data_Tag_Delegates[b]?.Invoke(b, dataInput);

        return tag;
    }

    public static void RegisterDataTag(byte id,read_data_tag_delegate read_Data_Tag_Delegate) 
    {
        read_Data_Tag_Delegates.Add(id,read_Data_Tag_Delegate);
    }


    static void GetTagTreeNode(StringBuilder stringBuilder, IDataTag dataTag,string name) {
        if(!name.isNull())
            stringBuilder.Append('[').Append(dataTag.GetType().Name).Append("] ").Append(name).Append(' ').Append(dataTag).Append('\n');
        else
            stringBuilder.Append('[').Append(dataTag.GetType().Name).Append("] ").Append(dataTag).Append('\n');
        if(dataTag.GetTagType()==COMPOUND_DATA_TAG){
            string str = ((CompoundDataTag)dataTag).GetTagTree();
            stringBuilder.Append(StringUtil.AddToLineHeaderFix(str,"──"));
        } else if (dataTag.GetTagType() == LIST_DATA_TAG) {
            string str = ((ListDataTag)dataTag).GetTagTree();
            stringBuilder.Append(StringUtil.AddToLineHeaderFix(str,"──"));
        }
    }
}