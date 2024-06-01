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
    
    void Write(BinaryWriter dataOutput);
    byte GetTagType();
    object GetValue();
    
    static IDataTag? ReadTag(byte b, BinaryReader dataInput) {
        IDataTag? tag = null;
        if(b == COMPOUND_DATA_TAG){
            tag = CompoundDataTag.Read(dataInput);
        } else if(b == INT_DATA_TAG){
            tag = IntDataTag.Read(dataInput);
        } else if (b == INT_ARRAY_DATA_TAG) {
            tag = IntArrayDataTag.Read(dataInput);
        } else if (b == LIST_DATA_TAG) {
            tag = ListDataTag.Read(dataInput);
        } else if (b == STRING_DATA_TAG) {
            tag = StringDataTag.Read(dataInput);
        } else if (b == BOOLEAN_DATA_TAG) {
            tag = BooleanDataTag.Read(dataInput);
        } else if (b == LONG_DATA_TAG) {
            tag = LongDataTag.Read(dataInput);
        } else if (b == FLOAT_DATA_TAG) {
            tag = FloatDataTag.Read(dataInput);
        } else if (b == DOUBLE_DATA_TAG) {
            tag = DoubleDataTag.Read(dataInput);
        } else if (b == BYTE_DATA_TAG) {
            tag = ByteDataTag.Read(dataInput);
        } else if (b == BYTE_ARRAY_DATA_TAG)
        {
            tag = ByteArrayDataTag.Read(dataInput);
        }

        return tag;
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