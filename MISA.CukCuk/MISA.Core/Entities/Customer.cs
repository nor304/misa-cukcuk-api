using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    // Thông tin khách khách
    public class Customer
    {
        // Khóa chính
        public Guid CustomerId { get; set; }
        // Mã khách hàng
        public string CustomerCode { get; set; }
        // Họ và tên
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string MemberCardCode { get; set; }
        public Guid? CustomerGroupId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTaxCode { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}
