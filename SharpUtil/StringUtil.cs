using System.Text;

namespace SharpUtil;

public static class StringUtil
{
    private static readonly Random _random = new();

    public static bool isNull(this string? str)
    {
        return str != null&&str != string.Empty;
    }
    
    public static string FormatList<T>(List<T> list)
    {
        string formattedByteList = $"[{string.Join(", ", list.ToArray())}]";
        return formattedByteList;
    }
    
    public static string FormatArray<T>(IEnumerable<T> list)
    {
        string formattedByteList = $"[{string.Join(", ", list)}]";
        return formattedByteList;
    }

    public static string AddToLineHeader(string str,string symbol){
        string[] strings = str.Split("\n");
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < strings.Length; i++) {
            string s = symbol + strings[i];
            stringBuilder.Append(s).Append('\n');
        }
        return stringBuilder.ToString();
    }

    public static string AddToLineHeaderFix(string str,string symbol){
        string[] strings = str.Split("\n");
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < strings.Length; i++) {
            if (!strings[i].Equals(string.Empty))
            {
                string s = symbol + strings[i];
                stringBuilder.Append(s).Append('\n');
            }
        }
        return stringBuilder.ToString();
    }

    public static string AddToLineHeader(string str,string symbol,string start,string end){
        string[] strings = str.Split("\n");
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < strings.Length; i++) {
            string s;
            if(i==0)
                s = start + strings[i];
            else if (i== strings.Length-1)
                s = end + strings[i];
            else
                s = start + strings[i];
            stringBuilder.Append(s).Append('\n');
        }
        return stringBuilder.ToString();
    }

    public static string AddToLineHeaderFix(string str,string symbol,string start,string end){
        string[] strings = str.Split("\n");
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < strings.Length; i++) {
            if (!strings[i].Equals(string.Empty))
            {
                string s;
                if(i==0)
                    s = start + strings[i];
                else if (i== strings.Length-1)
                    s = end + strings[i];
                else
                    s = start + strings[i];
                stringBuilder.Append(s).Append('\n');
            }
        }
        return stringBuilder.ToString();
    }

    public static string PrintDirectory(string path)
    {
        Console.WriteLine(path);
        if (Directory.Exists(path))
        {
            return PrintDirectory(path, 0, "");
        }
        Console.WriteLine("No Found Dir");
        return "";
    }

    private static string PrintDirectory(string dir_path, int depth, string prefix)
    {
        StringBuilder stringBuilder = new StringBuilder();
        DirectoryInfo dif = new DirectoryInfo(dir_path);
        if (depth == 0)
            stringBuilder.Append(prefix + dif.Name).Append('\n');
        else
        {
            //stringBuilder.Append(prefix.Substring(0, prefix.Length - 2) + "| ").Append('\n');
            stringBuilder.Append(prefix.Substring(0, prefix.Length - 2) + "|-" + dif.Name).Append('\n');
        }

        for (int counter = 0; counter < dif.GetDirectories().Length; counter++)
        {
            DirectoryInfo di = dif.GetDirectories()[counter];
            if (counter != dif.GetDirectories().Length - 1 ||
                dif.GetFiles().Length != 0)
                stringBuilder.Append(PrintDirectory(di.FullName, depth + 1, prefix + "| "));
            else
                stringBuilder.Append(PrintDirectory(di.FullName, depth + 1, prefix + " "));
        }

        for (int counter = 0; counter < dif.GetFiles().Length; counter++)
        {
            FileInfo f = dif.GetFiles()[counter];
            // if (counter == 0)
            //     stringBuilder.Append(prefix + "|").Append('\n');
            stringBuilder.Append(prefix + "|-" + f.Name).Append('\n');
        }

        return stringBuilder.ToString();
    }
    
    public static string GetRandomString(int length)
    {
        if (length <= 0)
        {
            return "";
        }
        StringBuilder s = new();
        for (int i = 0; i < length; i++)
        {
            string str = "︴ÀÁÂÈÊËÍÓÔÕÚßãõğİıŒœŞşŴŵžȇ!\"#;$%&'^_¿`@()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ^_`abcdefghijklmnopqrstuvwxyz[]‖§{|}~ ÇüéâäàåçêëèïîìÄÅÉæÆôöòûùÿÖÜø£Ø×ƒáíóúñÑªº¿®¬½¼¡«»αβΓπΣσμτΦΘΩδ∞∅∈∩≡±≥≤⌠⌡÷≈°∙·√ⁿ²■ ∶∴∏≯≮≡≠±％∭∰℉¼$¥￥£￠€฿￡₠γζψονω";
            s.Append(str.AsSpan(_random.Next(0, str.Length - 1), 1));
        }
        return s.ToString();
    }
    
    public static String GetRandomString2(int length) {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < length; i++) {
            long result = (_random.Next(93) + 33);
            sb.Append(((char)(int)result));
        } 
        return sb.ToString();
    }
    
    public static string Formatting(string input, string[] chars, double delay)
    {
        StringBuilder sb = new(input.Length * 3);
        if (delay <= 0.0D)
        {
            delay = 0.001D;
        }
        int offset = (int)Math.Floor(DateTime.Now.Ticks * delay) % chars.Length;
        for (int i = 0; i < input.Length; ++i)
        {
            char c = input[i];
            if (c != '\n')
            {
                sb.Append(chars[(chars.Length + i - offset) % chars.Length]);
                sb.Append(c);
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

}