using System.CodeDom.Compiler;
using System.Runtime.Serialization;
using System.Text;
using Microsoft.VisualBasic;

namespace SharpUtil.Logging;

public class SimpleLogger
{
    public IndentedTextWriter LogWriter { get; }
    public string Name { get;private set; }
    public string Path { get;private set; }
    public string FileName { get;private set; }
    public StringBuilder HistoryLog { get;private set; }
    
    public SimpleLogger(string name, string path) {
        this.Name = name;
        this.Path = path;
        this.FileName = DateTime.Now.ToString("yyyy-M-dd--HH.mm.ss") + ".log";
        this.HistoryLog = new StringBuilder();
        if (!Directory.Exists(Path))
        {
            Directory.CreateDirectory(Path);
        }
        string[] logs = Directory.EnumerateFiles(Path, "*.log").ToArray();
        for (int i = 0; i < logs.Length - 10; i++)
        {
            File.Delete(logs[i]);
        }
        this.LogWriter = new IndentedTextWriter(new StreamWriter(File.Open(Path + FileName,FileMode.Create))
        {
            AutoFlush = true
        });
    }
    
    public string Log(string? msg, LogLevel level)
    {
        string str = "["+ DateTime.Now + "] "
                     + "[" + Thread.CurrentThread.Name + "/" + Name + "] "
                     + "[" + level.ToString()+ "] "
                     + msg;
        LogWriter.WriteLine(str);
        LogWriter.Flush();
        HistoryLog.Append(str).Append('\n');
        Console.WriteLine(str);
        return str;
    }
    
    public string Log(object o,LogLevel level){
        return Log(o.ToString(),level);
    }

    public string Log(string s,LogLevel level,params object[] args){
        return Log(string.Format(s,args),level);
    }

    public string Debug(string? str){
        return Log(str,LogLevel.DEBUG);
    }

    public string Debug(object o){
        return Debug(o.ToString());
    }

    public string Debug(string s,params object[] args){
        return Debug(string.Format(s,args));
    }

    public string Info(string? str){
        return Log(str,LogLevel.INFO);
    }

    public string Info(object o){
        return Info(o.ToString());
    }

    public string Info(string s,params object[] args){
        return Info(string.Format(s,args));
    }

    public string Warn(string? str){
        return Log(str,LogLevel.WARN);
    }

    public string Warn(object o){
        return Warn(o.ToString());
    }

    public string Warn(string s,params object[] args){
        return Warn(string.Format(s,args));
    }

    public string Error(string? s){
        return Log(s,LogLevel.ERROR);
    }

    public string Error(object o){
        return Error(o.ToString());
    }

    public string Error(string s,params object[] args){
        return Error(string.Format(s,args));
    }

    public string Fail(string? s){
        return Log(s,LogLevel.FAIL);
    }

    public string Fail(object o){
        return Fail(o.ToString());
    }

    public string Fail(string s,params object[] args){
        return Fail(string.Format(s,args));
    }
}