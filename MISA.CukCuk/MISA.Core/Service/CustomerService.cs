using MISA.Core.Entities;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        //Inject interface ICustomerRepository vào class CustomerService
        ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) :base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //Overide hàm Validate cho đặc thù riêng của entity Customer
        protected override void Validate(Customer entity)
        {
            if (entity is Customer)
            {
                var customer = entity as Customer;
                // Validate dữ liệu:
                // Check các thông tin bắt buộc nhập:
                CustomerException.CheckCustomerCodeEmpty(customer.CustomerCode);
                // Check trùng mã:
                var isExits = _customerRepository.CheckCustomerCodeExist(customer.CustomerCode);
                if (isExits == true)
                {
                    throw new CustomerException("MÃ khách hàng đã tồn tại trên hệ thống!.");
                }
            }
           
        }

        // public IEnumerable<Customer> GetAll()
        // {
        //     var customers = _customerRepository.GetAll();
        //     return customers;
        // }

        // public Customer GetById(Guid customerId)
        // {
        //     var customers = _customerRepository.GetById(customerId);
        //     return customers;
        // }

        // public int Insert(Customer customer)
        // {
        //     // Validate dữ liệu:
        //     // - Check các thông tin bắt buộc nhập:
        //     CustomerException.CheckCustomerCodeEmpty(customer.CustomerCode);

        //     // Check trùng mã:
        //     var isExits = _customerRepository.CheckCustomerCodeExist(customer.CustomerCode);
        //     if (isExits == true)
        //     {
        //         throw new CustomerException("MÃ khách hàng đã tồn tại trên hệ thống!.");
        //     }
        //     var rowsAffect = _customerRepository.Insert(customer);
        //     return rowsAffect;
        // }

        // public int Update(Customer customer)
        // {
        //     var rowsAffect = _customerRepository.Update(customer);
        //     return rowsAffect;
        // }

        // public int Delete(Guid customerId)
        // {
        //     var rowsAffect = _customerRepository.Delete(customerId);
        //     return rowsAffect;
        // }
    }
}
