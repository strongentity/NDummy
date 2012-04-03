namespace NDummy.Tests.CustomTypes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CustomClass
    {
        public int CustomClassID { get; set; }

        private string privateMemberValue;
        protected string ProtectedMemberValue;
        public string PublicMemberValue;

        private string PrivatePropertyValue { get; set; }
        protected string ProtectedPropertyValue { get; set; }

        private string readonlyPropertyValue = string.Empty;
        public string ReadonlyPropertyValue
        {
            get { return readonlyPropertyValue; }
        }

        private string writeOnlyPropertyValue = string.Empty;
        public string WriteOnlyPropertyValue
        {
            set { writeOnlyPropertyValue = value; }
        }

        public bool BoolValue { get; set; }
        public byte ByteValue { get; set; }
        public sbyte SByteValue { get; set; }
        public short Int16Value { get; set; }
        public int Int32Value { get; set; }
        public long Int64Value { get; set; }
        public decimal DecimalValue { get; set; }
        public float SingleValue { get; set; }
        public double DoubleValue { get; set; }
        public ushort UInt16Value { get; set; }
        public uint UInt32Value { get; set; }
        public ulong UInt64Value { get; set; }
        public char CharValue { get; set; }
        public Guid GuidValue { get; set; }
        public DateTime DateTimeValue { get; set; }
        public bool? NullableOfBooleanValue { get; set; }
        public byte? NullableOfByteValue { get; set; }
        public sbyte? NullableOfSByteValue { get; set; }
        public short? NullableOfInt16Value { get; set; }
        public int? NullableOfInt32Value { get; set; }
        public long? NullableOfInt64Value { get; set; }
        public decimal? NullableOfDecimalValue { get; set; }
        public float? NullableOfSingleValue { get; set; }
        public double? NullableOfDoubleValue { get; set; }
        public ushort? NullableOfUShortValue { get; set; }
        public uint? NullableOfUInt32Value { get; set; }
        public ulong? NullableOfUInt64Value { get; set; }
        public char? NullableOfCharValue { get; set; }
        public DateTime? NullableOfDateTimeValue { get; set; }
        public Guid? NullableOfGuidValue { get; set; }
        public string StringValue { get; set; }

        public CustomStruct StructValue { get; set; }
        public ICustomInterface InterfaceValue { get; set; }
        public CustomAbstractClass AbstractClassValue { get; set; }
        public CustomEnum EnumValue { get; set; }


    }
}
