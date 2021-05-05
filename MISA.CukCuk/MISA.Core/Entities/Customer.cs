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
        [MISARequiredNull("Mã khách hàng không được phép để trống")]
        [MISARequiredExsist("Mã khách hàng đã tồn tại trong hệ thống")]
        [MISAMaxLength(20, msgError: "Mã khách hàng không được dài quá 20 ký tự")]
        public string CustomerCode { get; set; }
        //Họ và tên
        [MISARequiredNull("Tên khách hàng không được phép để trống")]
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
        [MISARequiredNull("Số điện thoại không được phép để trống")]
        [MISARequiredExsist("Số điện thoại đã tồn tại trong hệ thống")]
        public string PhoneNumber { get; set; }
        //Email
        [MISARequiredNull("Email không được phép để trống")]
        [MISARequiredExsist("Email đã tồn tại trong hệ thống")]
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
