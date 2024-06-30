namespace SharpUtil.Data
{
    public abstract class SimpleSaveData : ZbSaveData
    {
        public string Path { get; }
        public string Name { get; }

        protected SimpleSaveData(string path, string name)
        {
            Path = path;
            Name = name;
        }

        public virtual void Save()
        {
            base.Save(Path, Name);
        }

        public virtual void Load()
        {
            base.Load(Path, Name);
        }
    }
}
