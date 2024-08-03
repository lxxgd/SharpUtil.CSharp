using System.Text;

namespace SharpUtil;

public static class StringUtil
{
    private static readonly Random _random = new();

    public static bool IsNullOrEmpty(this string? str)
    {
        return string.IsNullOrEmpty(str);
    }

    public static string ToStringForEnumerable<T>(this IEnumerable<T> enumerable)
    {
        string formattedByteList = $"[{string.Join(", ", enumerable)}]";
        return formattedByteList;
    }

    public static string ToStringForEnumerableWithNull<T>(this IEnumerable<T> enumerable)
    {
        List<string> strings = [];
        foreach (T item in enumerable)
        {
            if (item == null)
            {
                strings.Add("null");
            }
            else
            {
                strings.Add(item.ToString() ?? "null");
            }
        }
        return ToStringForEnumerable(strings);
    }

    public static string AddToLineHeader(string str, string symbol)
    {
        str = str.Trim();
        string[] strings = str.Split("\n");
        StringBuilder stringBuilder = new();
        for (int i = 0; i < strings.Length; i++)
        {
            string s = symbol + strings[i];
            stringBuilder.Append(s).Append('\n');
        }
        return stringBuilder.ToString();
    }

    public static string AddToLineHeaderFix(string str, string symbol)
    {
        string[] strings = str.Split("\n");
        StringBuilder stringBuilder = new();
        for (int i = 0; i < strings.Length; i++)
        {
            if (!strings[i].Equals(string.Empty))
            {
                string s = symbol + strings[i];
                stringBuilder.Append(s).Append('\n');
            }
        }
        return stringBuilder.ToString();
    }

    public static string AddToLineHeader(string str, string symbol, string start, string end)
    {
        string[] strings = str.Split("\n");
        StringBuilder stringBuilder = new();
        for (int i = 0; i < strings.Length; i++)
        {
            string s;
            if (i == 0)
                s = start + strings[i];
            else if (i == strings.Length - 1)
                s = end + strings[i];
            else
                s = symbol + strings[i];
            stringBuilder.Append(s).Append('\n');
        }
        return stringBuilder.ToString();
    }

    public static string AddToLineHeaderFix(string str, string symbol, string start, string end)
    {
        str = str.Trim();
        string[] strings = str.Split("\n");
        StringBuilder stringBuilder = new();
        for (int i = 0; i < strings.Length; i++)
        {
            if (!strings[i].Equals(string.Empty))
            {
                string s;
                if (i == 0)
                    s = start + strings[i];
                else if (i == strings.Length - 1)
                    s = end + strings[i];
                else
                    s = symbol + strings[i];
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
            return PrintDirectory(path, 0, " ");
        }
        Console.WriteLine("No Found Dir");
        return "";
    }

    private static string PrintDirectory(string dir_path, int depth, string prefix)
    {
        StringBuilder stringBuilder = new();
        DirectoryInfo dif = new(dir_path);
        if (depth == 0)
            stringBuilder.Append(prefix + dif.Name).Append('\n');
        else
        {
            //stringBuilder.Append(prefix.Substring(0, prefix.Length - 2) + "| ").Append('\n');
            stringBuilder.Append(string.Concat(prefix.AsSpan(0, prefix.Length - 2), "|-", dif.Name)).Append('\n');
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
            int start = _random.Next(0, str.Length - 1);
            ReadOnlySpan<char> value = str.AsSpan(start, 1);
            s.Append(value);
        }
        return s.ToString();
    }

    public static String GetRandomString2(int length)
    {
        StringBuilder sb = new();
        for (int i = 0; i < length; i++)
        {
            long result = _random.Next(93) + 33;
            sb.Append((char)(int)result);
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

    public static string Map2DToString<T>(this Map2D<T> map)
    {
        StringBuilder sb = new();
        for (int x = 0; x < map.Width; x++)
        {
            for (int y = 0; y < map.Height; y++)
            {
                T? value = map[x, y];
                sb.Append((value == null ? "null" : value.ToString()) + ", ");
            }
            sb.Append('\n');
        }
        return sb.ToString();
    }
}