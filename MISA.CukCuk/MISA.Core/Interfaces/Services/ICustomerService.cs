using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Services
{
    // Service phục vụ cho đối tượng Khách hàng
    public interface ICustomerService
    {
        // Lấy toàn bộ dữ liệu khách hàng
        // <returns>Danh sách khách hàng</returns>
        public IEnumerable<Customer> GetAll();
        public Customer GetById(Guid customerId);
        public int Insert(Customer customer);
        public int Update(Customer customer);
        public int Delete(Guid custimerId);
    }
}
