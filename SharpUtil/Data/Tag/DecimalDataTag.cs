namespace SharpUtil.Data.Tag
{
    public class DecimalDataTag : BaseDataTag
    {
        public decimal value;

        public DecimalDataTag(decimal v)
        {
            value = v;
        }

        public override byte GetTagType()
        {
            return IDataTag.DECIMAL_DATA_TAG;
        }

        public override object GetValue()
        {
            return value;
        }

        public static DecimalDataTag Read(BinaryReader dataInput)
        {
            return new DecimalDataTag(dataInput.ReadDecimal());
        }

        public override void Write(BinaryWriter dataOutput)
        {
            dataOutput.Write(value);
        }
    }
}
