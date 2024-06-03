namespace SharpUtil;

public static class SharpUtil
{
    public static bool DebugInfo = false;

    public static string GetExceptionMessage(this Exception exception)
    {
        return exception.GetType().FullName + " : " + exception.Message + "\n" + exception.StackTrace;
    }
}