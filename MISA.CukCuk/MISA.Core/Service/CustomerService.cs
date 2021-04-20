using MISA.Core.Entities;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Service
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public int Delete(Guid customerId)
        {
            var rowsAffect = _customerRepository.Delete(customerId);
            return rowsAffect;
        }

        public IEnumerable<Customer> GetAll()
        {
            var customers = _customerRepository.GetAll();
            return customers;
        }

        public Customer GetById(Guid customerId)
        {
            var customers = _customerRepository.GetById(customerId);
            return customers;
        }

        public int Insert(Customer customer)
        {
            // validate dữ liệu:
            // Validate dữ liệu:
            // - Check các thông tin bắt buộc nhập:
            CustomerException.CheckCustomerCodeEmpty(customer.CustomerCode);

            // Check trùng mã:
            var isExits = _customerRepository.CheckCustomerCodeExist(customer.CustomerCode);
            if (isExits == true)
            {
                throw new CustomerException("MÃ khách hàng đã tồn tại trên hệ thống!.");
            }
            var rowsAffect = _customerRepository.Insert(customer);
            return rowsAffect;
        }

        public int Update(Customer customer)
        {
            var rowsAffect = _customerRepository.Update(customer);
            return rowsAffect;
        }
    }
}
