using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Exceptions
{
    public class CustomerException:Exception
    {
        public CustomerException(string msg):base(msg)
        {

        }

        public static void CheckFullNameEmpty(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                var response = new
                {
                    devMsg = "Tên khách hàng không được phép để trống",
                    MISACode = "001"
                };
                throw new CustomerException("Tên khách hàng không được phép để trống.");
            }    
        }

        public static void CheckCustomerCodeEmpty(string customerCode)
        {
            if (string.IsNullOrEmpty(customerCode))
            {
                var response = new
                {
                    devMsg = "Mã khách hàng không được phép để trống",
                    MISACode = "001"
                };
                throw new CustomerException("Mã khách hàng không được phép để trống.");
            }
        }

        public static void CheckPhoneNumberEmpty(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                var response = new
                {
                    devMsg = "Số điện thoại không được phép để trống",
                    MISACode = "001"
                };
                throw new CustomerException("Số điện thoại không được phép để trống.");
            }
        }

        public static void CheckEmailEmpty(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                var response = new
                {
                    devMsg = "Email không được phép để trống",
                    MISACode = "001"
                };
                throw new CustomerException("Email không được phép để trống.");
            }
        }
    }
}
