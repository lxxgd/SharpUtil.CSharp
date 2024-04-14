using System.Text;

namespace SharpUtil;

public static class SharpUtil
{
    public static bool DebugInfo = false;

    public static string GetExceptionMessage(Exception exception)
    {
        return exception.Message + "\n" + exception.StackTrace;
    }
}