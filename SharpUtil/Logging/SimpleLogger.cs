namespace SharpUtil.Logging;

public class SimpleLogger : IDisposable
{
    private readonly TextWriter _logWriter;
    public string Name { get; }
    public string Path { get; }
    public string FileName { get; }
    public List<string> HistoryLog { get; }
    public int maxLogs = 10;

    public SimpleLogger(string name, string path)
    {
        Name = name;
        Path = path;
        FileName = DateTime.Now.ToString("yyyy-M-dd--HH.mm.ss") + ".log";
        HistoryLog = [];
        if (!Directory.Exists(Path))
        {
            _ = Directory.CreateDirectory(Path);
        }

        try
        {
            string[] logs = Directory.EnumerateFiles(Path, "*.log").ToArray();
            for (int i = 0; i < logs.Length - maxLogs; i++)
            {
                File.Delete(logs[i]);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.GetExceptionMessage());
            System.Diagnostics.Debug.WriteLine(e.GetExceptionMessage());
        }
        catch { }

        _logWriter = TextWriter.Synchronized(new StreamWriter(new BufferedStream(new FileStream(System.IO.Path.Combine(Path, FileName), FileMode.Append, FileAccess.Write, FileShare.Read)))
        {
            AutoFlush = true
        });
        //Trace.Listeners.Add(new TextWriterTraceListener(System.IO.Path.Combine(Path, FileName)));
        //Trace.AutoFlush = true;
        //_listener = new TextWriterTraceListener(System.IO.Path.Combine(Path, FileName));
    }

    public string Log(string? msg, LogLevel level)
    {
        string str = $"[{DateTime.Now}] [{Thread.CurrentThread.Name}/{Name}] [{level}] {msg}";
        try
        {
            //Trace.WriteLine(str);
            //_listener.WriteLine(str);
            //_listener.Flush();
            _logWriter.WriteLine(str);
            //_logWriter.Flush();
        }
        catch (IOException e)
        {
            Console.WriteLine("日志记录失败：" + e.GetExceptionMessage());
            System.Diagnostics.Debug.WriteLine("日志记录失败：" + e.GetExceptionMessage());
        }
        HistoryLog.Add(str);
        Console.WriteLine(str);
        System.Diagnostics.Debug.WriteLine(str);
        return str;
    }

    public string Log(object o, LogLevel level)
    {
        return Log(o.ToString(), level);
    }

    public string Log(string s, LogLevel level, params object[] args)
    {
        return Log(string.Format(s, args), level);
    }

    public string Debug(string? str)
    {
        return Log(str, LogLevel.DEBUG);
    }

    public string Debug(object o)
    {
        return Debug(o.ToString());
    }

    public string Debug(string s, params object[] args)
    {
        return Debug(string.Format(s, args));
    }

    public string Info(string? str)
    {
        return Log(str, LogLevel.INFO);
    }

    public string Info(object o)
    {
        return Info(o.ToString());
    }

    public string Info(string s, params object[] args)
    {
        return Info(string.Format(s, args));
    }

    public string Warn(string? str)
    {
        return Log(str, LogLevel.WARN);
    }

    public string Warn(object o)
    {
        return Warn(o.ToString());
    }

    public string Warn(string s, params object[] args)
    {
        return Warn(string.Format(s, args));
    }

    public string Error(string? s)
    {
        return Log(s, LogLevel.ERROR);
    }

    public string Error(object o)
    {
        return Error(o.ToString());
    }

    public string Error(string s, params object[] args)
    {
        return Error(string.Format(s, args));
    }

    public string Fail(string? s)
    {
        return Log(s, LogLevel.FAIL);
    }

    public string Fail(object o)
    {
        return Fail(o.ToString());
    }

    public string Fail(string s, params object[] args)
    {
        return Fail(string.Format(s, args));
    }

    public void Dispose()
    {
        _logWriter.Close();
        GC.SuppressFinalize(this);
    }
}