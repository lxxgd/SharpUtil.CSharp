namespace SharpUtil.Data.Tag;

public static class DataTagUtil
{
    public static string GetRootCompoundTagTagTree(string root,CompoundDataTag compoundDataTag){
        return root + "\n" + StringUtil.AddToLineHeaderFix(compoundDataTag.GetTagTree(),"├─","├─","└");
    }
}