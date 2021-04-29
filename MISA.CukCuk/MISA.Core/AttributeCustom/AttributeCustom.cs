using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.AttributeCustom
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired:Attribute
    {
        public string MsgError = string.Empty;
        public MISARequired(string msgError = "")
        {
            MsgError = msgError;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISAMaxLength:Attribute
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
