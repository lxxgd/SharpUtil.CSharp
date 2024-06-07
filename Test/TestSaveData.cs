using SharpUtil.Data;
using SharpUtil.Data.Tag;

namespace Test;

public class TestSaveData : SimpleSaveData
{
    public List<Guid> uuid = new List<Guid>();
    public int anInt;
    public int anInt2;
    public int anInt3;
    public CompoundDataTag compoundDataTag1;
    public CompoundDataTag compoundDataTag2;
    public string str;
    public decimal de;

    public TestSaveData() : base(AppDomain.CurrentDomain.BaseDirectory, "test")
    {
    }
    
    protected override void Read(BinaryReader datainputstream, FileInfo file)
    {
        CompoundDataTag compoundDataTag = CompoundDataTag.Read(datainputstream);
//        for (String key : compoundDataTag.tags.keySet()){
//            if (key.startsWith("UUID-")) {
//                IntArrayDataTag dataTag = (IntArrayDataTag) compoundDataTag.tags.get(key);
//                UUID uuid1 = UUIDUtil.uuidFromIntArray(dataTag.value);
//                uuid.add(uuid1);
//            }
//        }
        ListDataTag listDataTag = (ListDataTag) compoundDataTag.Get("uuid");
        foreach (var uuid1 in listDataTag.TagList.Select(dataTag => new Guid(((CompoundDataTag)dataTag).GetByteArray("UUID"))))
        {
            uuid.Add(uuid1);
        }
        compoundDataTag1 = compoundDataTag;
        compoundDataTag2 = (CompoundDataTag) compoundDataTag.Get("WOW");
        anInt = compoundDataTag.GetInt("int");
        anInt2 = compoundDataTag.GetInt("int2");
        anInt3 = compoundDataTag.GetInt("int3");
        str = compoundDataTag.GetString("str");
        DecimalDataTag decimalDataTag = (DecimalDataTag)compoundDataTag.Get("de");
        de = decimalDataTag.value;
    }

    protected override void Write(BinaryWriter dataOutputStream, FileInfo file)
    {
        CompoundDataTag compoundDataTag = new CompoundDataTag();
        ListDataTag listDataTag = new ListDataTag();
        foreach (var variable in uuid)
        {
            byte[] b = variable.ToByteArray();
            CompoundDataTag compoundDataTag3 = new CompoundDataTag();
            compoundDataTag3.PutByteArray("UUID",b);
            listDataTag.TagList.Add(compoundDataTag3);
        }
        compoundDataTag.PutInt("int",anInt);
        compoundDataTag.PutInt("int2",anInt2);
        compoundDataTag.PutInt("int3",anInt3);
        CompoundDataTag compoundDataTag1 = new CompoundDataTag();
        compoundDataTag1.PutInt("AN",741);
        compoundDataTag.Put("WOW",compoundDataTag1);
        compoundDataTag.Put("uuid",listDataTag);
        compoundDataTag.PutString("str",str);
        compoundDataTag.PutLong("long!",long.MaxValue);
        compoundDataTag.PutDouble("double?",double.MaxValue);
        compoundDataTag.PutFloat("Float!",float.MaxValue);
        compoundDataTag.PutBoolean("Boolean!",true);
        compoundDataTag.PutByte("Byte!",byte.MaxValue);
        DecimalDataTag decimalDataTag = new DecimalDataTag(de);
        compoundDataTag.Put("de",decimalDataTag);
        compoundDataTag.Write(dataOutputStream);
    }

    protected override void ExceptionHandling(bool saveOrLoad, Exception exception, FileInfo fileInfo)
    {
        if(saveOrLoad)
            Program.logger.Error("Could save file " + fileInfo.Name + "\n" +SharpUtil.SharpUtil.GetExceptionMessage(exception));
        else
            Program.logger.Error("Could load file " + fileInfo.Name + "\n" +SharpUtil.SharpUtil.GetExceptionMessage(exception));
    }
}