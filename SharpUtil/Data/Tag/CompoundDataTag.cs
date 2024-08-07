﻿using System.Text;

namespace SharpUtil.Data.Tag;

public class CompoundDataTag : BaseDataTag
{
    public Dictionary<string, IDataTag> Tags;

    public CompoundDataTag(Dictionary<string, IDataTag> value)
    {
        this.Tags = value;
    }

    public CompoundDataTag()
    {
        Tags = [];
    }

    public override byte GetTagType()
    {
        return IDataTag.COMPOUND_DATA_TAG;
    }

    public static CompoundDataTag Read(BinaryReader dataInput)
    {
        Dictionary<string, IDataTag> map = [];
        byte b;
        while ((b = dataInput.ReadByte()) != 0)
        {
            IDataTag? tag;
            string name;
            name = dataInput.ReadString();
            tag = IDataTag.ReadTag(b, dataInput);
            if (tag == null)
                Console.WriteLine($"Unkown DataTag ID: {b}");
            if (name != string.Empty && tag != null)
                map.Add(name, tag);
        }
        return new CompoundDataTag(map);
    }

    public string GetTagTree()
    {
        StringBuilder stringBuilder = new();
        foreach (var key in Tags.Keys)
        {
            IDataTag.GetTagTreeNode(stringBuilder, Tags[key], key);
        }
        return stringBuilder.ToString();
    }

    public override object GetValue()
    {
        return Tags;
    }

    public override void Write(BinaryWriter dataOutput)
    {
        foreach (var key in Tags.Keys)
        {
            IDataTag tag = Tags[key];
            WriteTags(key, tag, dataOutput);
        }
        dataOutput.Write(IDataTag.END_DATA_TAG);
    }

    private static void WriteTags(string key, IDataTag tag, BinaryWriter dataOutput)
    {
        dataOutput.Write(tag.GetTagType());
        if (tag.GetTagType() != 0)
        {
            dataOutput.Write(key);
            tag.Write(dataOutput);
        }
    }

    public override string ToString()
    {
        return "";
    }

    public void PutInt(string key, int v)
    {
        IntDataTag tag = new(v);
        Tags.Add(key, tag);
    }

    public int GetInt(string key)
    {
        return ((IntDataTag)Tags[key]).Value;
    }

    public void Put(string key, IDataTag tag)
    {
        Tags.Add(key, tag);
    }

    public IDataTag Get(string key)
    {
        return Tags[key];
    }

    public void PutIntArray(string key, int[] v)
    {
        IntArrayDataTag intArrayDataTag = new(v);
        Tags.Add(key, intArrayDataTag);
    }

    public int[] GetIntArray(string key)
    {
        return ((IntArrayDataTag)Tags[key]).Value;
    }

    public void PutString(string key, string value)
    {
        StringDataTag stringDataTag = new(value);
        Tags.Add(key, stringDataTag);
    }

    public string GetString(string key)
    {
        return ((StringDataTag)Tags[key]).Value;
    }

    public void PutBoolean(string key, bool v)
    {
        BooleanDataTag tag = new(v);
        Tags.Add(key, tag);
    }

    public bool GetBoolean(string key)
    {
        return ((BooleanDataTag)Tags[key]).Value;
    }

    public void PutLong(string key, long v)
    {
        LongDataTag tag = new(v);
        Tags.Add(key, tag);
    }

    public long GetLong(string key)
    {
        return ((LongDataTag)Tags[key]).Value;
    }

    public void PutFloat(string key, float v)
    {
        FloatDataTag tag = new(v);
        Tags.Add(key, tag);
    }

    public float GetFloat(string key)
    {
        return ((FloatDataTag)Tags[key]).Value;
    }

    public void PutDouble(string key, double v)
    {
        DoubleDataTag tag = new(v);
        Tags.Add(key, tag);
    }

    public double GetDouble(string key)
    {
        return ((DoubleDataTag)Tags[key]).Value;
    }

    public void PutByte(string key, byte v)
    {
        ByteDataTag tag = new(v);
        Tags.Add(key, tag);
    }

    public byte GetByte(string key)
    {
        return ((ByteDataTag)Tags[key]).Value;
    }

    public void PutDecimal(string key, decimal v)
    {
        DecimalDataTag tag = new(v);
        Tags.Add(key, tag);
    }

    public decimal GetDecimal(string key)
    {
        return ((DecimalDataTag)Tags[key]).value;
    }

    public void PutByteArray(string key, byte[] v)
    {
        ByteArrayDataTag intArrayDataTag = new(v);
        Tags.Add(key, intArrayDataTag);
    }

    public byte[] GetByteArray(string key)
    {
        return ((ByteArrayDataTag)Tags[key]).Value;
    }
}