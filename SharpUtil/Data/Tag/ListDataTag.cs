using System.Text;

namespace SharpUtil.Data.Tag;

public class ListDataTag : BaseDataTag
{
    public List<IDataTag> TagList;

    public ListDataTag(List<IDataTag> tagList)
    {
        this.TagList = tagList;
    }

    public ListDataTag()
    {
        TagList = [];
    }

    public override byte GetTagType()
    {
        return IDataTag.LIST_DATA_TAG;
    }

    public static ListDataTag Read(BinaryReader dataInput)
    {
        int size = dataInput.ReadInt32();
        List<IDataTag> tagList = new(size);
        for (int i = 0; i < size; i++)
        {
            IDataTag? tag;
            byte b = dataInput.ReadByte();
            tag = IDataTag.ReadTag(b, dataInput);
            if (tag == null)
                Console.WriteLine($"Unkown DataTag ID: {b}");
            else
                tagList.Add(tag);
        }
        return new ListDataTag(tagList);
    }

    public override object GetValue()
    {
        return TagList;
    }

    public String GetTagTree()
    {
        StringBuilder stringBuilder = new();
        foreach (var kDataTag in TagList)
        {
            IDataTag.GetTagTreeNode(stringBuilder, kDataTag, null);
        }
        return stringBuilder.ToString();
    }

    public override string ToString()
    {
        return "";
    }

    public override void Write(BinaryWriter dataOutput)
    {
        dataOutput.Write(TagList.Count);
        foreach (IDataTag tag in TagList)
        {
            dataOutput.Write(tag.GetTagType());
            if (tag.GetTagType() != 0)
            {
                tag.Write(dataOutput);
            }
        }
    }
}