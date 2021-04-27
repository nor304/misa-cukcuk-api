using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Services
{
    //Service phục vụ cho đối tượng nhóm khách hàng
    public interface ICustomerGroupService
    {
        //Lấy toàn bộ dữ liệu nhóm khách hàng
        public IEnumerable<CustomerGroup> GetAll();
        //Lấy dữ liệu nhóm khách hàng với Id được truyền vào
        public CustomerGroup GetById(Guid customerId);
        //Thêm nhóm khách hàng
        public int Insert(CustomerGroup customer);
        //Sửa thông tin nhóm khách hàng
        public int Update(CustomerGroup customer);
        //Xóa nhóm khách hàng
        public int Delete(Guid custimerId);
    }
}
