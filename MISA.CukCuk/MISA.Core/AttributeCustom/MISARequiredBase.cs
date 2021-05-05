using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.AttributeCustom
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequiredBase : Attribute
    {
        public string MsgError = string.Empty;
        public MISARequiredBase(string msgError = "")
        {
            MsgError = msgError;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISAMaxLength : Attribute
    {
        public int MaxLength = 0;
        public string MsgError = string.Empty;
        public MISAMaxLength(int maxLength = 0, string msgError = "")
        {
            MaxLength = maxLength;
            MsgError = msgError;
        }
    }
}
