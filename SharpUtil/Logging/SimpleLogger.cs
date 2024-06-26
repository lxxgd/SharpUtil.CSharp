﻿using System.CodeDom.Compiler;

namespace SharpUtil.Logging;

public class SimpleLogger : IDisposable
{
    public IndentedTextWriter LogWriter { get; }
    public string Name { get; }
    public string Path { get; }
    public string FileName { get; }
    public List<string> HistoryLog { get; }
    public int maxLogs = 10;

    public SimpleLogger(string name, string path)
    {
        this.Name = name;
        this.Path = path;
        this.FileName = DateTime.Now.ToString("yyyy-M-dd--HH.mm.ss") + ".log";
        this.HistoryLog = new List<string>();
        if (!Directory.Exists(Path))
        {
            Directory.CreateDirectory(Path);
        }
        string[] logs = Directory.EnumerateFiles(Path, "*.log").ToArray();
        for (int i = 0; i < logs.Length - maxLogs; i++)
        {
            File.Delete(logs[i]);
        }
        this.LogWriter = new IndentedTextWriter(new StreamWriter(File.Open(System.IO.Path.Combine(Path, FileName), FileMode.Append))
        {
            AutoFlush = true
        });
    }

    public string Log(string? msg, LogLevel level)
    {
        string str = "[" + DateTime.Now + "] "
                   + "[" + Thread.CurrentThread.Name + "/" + Name + "] "
                   + "[" + level + "] "
                   + msg;
        LogWriter.WriteLine(str);
        LogWriter.Flush();
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
        LogWriter.Close();
        ((IDisposable)LogWriter).Dispose();
    }
}