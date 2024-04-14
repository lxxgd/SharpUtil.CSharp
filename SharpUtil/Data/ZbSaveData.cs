
namespace SharpUtil.Data
{
    public abstract class ZbSaveData
    {
        protected abstract void Read(BinaryReader datainputstream, FileInfo file);
        protected abstract void Write(BinaryWriter dataOutputStream, FileInfo file);

        protected void Save(string path,string name) 
        {
            FileInfo fileInfo = new FileInfo(Path.Join(path, name));
            using FileStream fileStream = new FileStream(Path.Join(path, name), FileMode.OpenOrCreate);
            using BufferedStream bufferedStream = new BufferedStream(fileStream);
            using BinaryWriter streamWriter = new BinaryWriter(bufferedStream);
            try
            {
                Write(streamWriter, fileInfo);
            }
            catch (Exception e)
            {
                ExceptionHandling(true,e,fileInfo);
            }
        }

        protected void Load(string path, string name)
        {
            FileInfo fileInfo = new FileInfo(Path.Join(path, name));
            using FileStream fileStream = new FileStream(Path.Join(path, name), FileMode.OpenOrCreate);
            using BufferedStream bufferedStream = new BufferedStream(fileStream);
            using BinaryReader streamWriter = new BinaryReader(bufferedStream);
            try
            {
                Read(streamWriter, fileInfo);
            }
            catch (Exception e)
            {
                ExceptionHandling(false,e,fileInfo);
            }
        }

        protected virtual void ExceptionHandling(bool saveOrLoad,Exception exception,FileInfo fileInfo)
        {
            Console.WriteLine(exception.Message + "\n" + exception.StackTrace);
        }
    }
}
