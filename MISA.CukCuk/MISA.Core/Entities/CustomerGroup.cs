using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    //Thông tin nhóm khách hàng
    public class CustomerGroup
    {
        //Khóa chính
        public Guid CustomerGroupId { get; set; }
        //Tên nhóm khách hàng
        public string CustomerGroupName { get; set; }
        //Mô tả
        public string Description { get; set; }
        //Ngày tạo
        public DateTime? CreatedDate { get; set; }
        //Người tạo
        public string CreatedBy { get; set; }
        //Ngày thay đổi
        public DateTime? ModifiedDate { get; set; }
        //Người thay đổi
        public string ModifiedBy { get; set; }
    }
}
