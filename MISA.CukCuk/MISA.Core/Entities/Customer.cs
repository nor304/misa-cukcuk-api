using MISA.Core.AttributeCustom;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    //Thông tin khách khách
    public class Customer
    {
        //Khóa chính
        public Guid CustomerId { get; set; }
        //Mã khách hàng
        [MISARequired("Mã khách hàng không được phép để trống")]
        [MISAMaxLength(20, msgError: "Mã khách hàng không được dài quá 20 ký tự")]
        public string CustomerCode { get; set; }
        //Họ và tên
        [MISARequired]
        public string FullName { get; set; }
        //Ngày sinh
        public DateTime DateOfBirth { get; set; }
        //Giới tính
        public int? Gender { get; set; }
        //Mã thẻ thành viênn
        public string MemberCardCode { get; set; }
        //ID nhóm khách hàng
        public Guid? CustomerGroupId { get; set; }
        //Số điện thoại
        public string PhoneNumber { get; set; }
        //Email
        public string Email { get; set; }
        //Tên công ty
        public string CompanyName { get; set; }
        //Mã số thuế công ty
        public string CompanyTaxCode { get; set; }
        //Địa chỉ
        public string Address { get; set; }
        //Ghi chú
        public string Note { get; set; }
        //Ngày tạo
        public DateTime? CreatedDate { get; set; }
        //Người tạo
        public string CreatedBy { get; set; }
        //Ngày thay đổi
        public DateTime ModifiedDate { get; set; }
        //Người thay đổi
        public string ModifiedBy { get; set; }

    }
}
