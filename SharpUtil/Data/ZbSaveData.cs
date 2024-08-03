
namespace SharpUtil.Data
{
    public abstract class ZbSaveData
    {
        protected abstract void Read(BinaryReader datainputstream, FileInfo file);
        protected abstract void Write(BinaryWriter dataOutputStream, FileInfo file);

        protected void Save(string path, string name)
        {
            FileInfo fileInfo = new(Path.Join(path, name));
            using FileStream fileStream = new(Path.Join(path, name), FileMode.OpenOrCreate);
            using BufferedStream bufferedStream = new(fileStream);
            using BinaryWriter streamWriter = new(bufferedStream);
            try
            {
                Write(streamWriter, fileInfo);
            }
            catch (Exception e)
            {
                SaveExceptionHandling(e, fileInfo);
            }
        }

        protected void Load(string path, string name)
        {
            FileInfo fileInfo = new(Path.Join(path, name));
            using FileStream fileStream = new(Path.Join(path, name), FileMode.OpenOrCreate);
            using BufferedStream bufferedStream = new(fileStream);
            using BinaryReader streamWriter = new(bufferedStream);
            try
            {
                Read(streamWriter, fileInfo);
            }
            catch (Exception e)
            {
                LoadExceptionHandling(e, fileInfo);
            }
        }

        protected virtual void SaveExceptionHandling(Exception exception, FileInfo fileInfo)
        {
            Console.WriteLine(exception.Message + "\n" + exception.StackTrace);
        }

        protected virtual void LoadExceptionHandling(Exception exception, FileInfo fileInfo)
        {
            Console.WriteLine(exception.Message + "\n" + exception.StackTrace);
        }
    }
}
