using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Services
{
    //Service phục vụ cho đối tượng Khách hàng
    public interface ICustomerService
    {
        //Lấy toàn bộ dữ liệu khách hàng
        public IEnumerable<Customer> GetAll();
        //Lấy dữ liệu khách hàng với Id được truyền vào
        public Customer GetById(Guid customerId);
        //Thêm khách hàng
        public int Insert(Customer customer);
        //Sửa thông tin khách hàng
        public int Update(Customer customer);
        //Xóa khách hàng
        public int Delete(Guid custimerId);
    }
}
