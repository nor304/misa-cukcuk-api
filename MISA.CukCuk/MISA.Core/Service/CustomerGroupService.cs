using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Service
{
    public class CustomerGroupService : BaseService<CustomerGroup>, ICustomerGroupService
    {
        //Inject interface ICustomerGroupRepository vào class CustomerGroupService
        ICustomerGroupRepository _customerGroupRepository;
        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository) :base(customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }

        //Overide hàm Validate cho đặc thù riêng của entity CustomerGroup
        protected override void Validate(CustomerGroup entity)
        {
            throw new Exception("Phan Bắc");
        }
        
        //public int Delete(Guid custimerId)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<CustomerGroup> GetAll()
        //{
        //    return _customerGroupRepository.GetAll();
        //}

        //public CustomerGroup GetById(Guid customerGroupId)
        //{
        //    return _customerGroupRepository.GetById(customerGroupId);
        //}

        //public int Insert(CustomerGroup customer)
        //{
        //    throw new NotImplementedException();
        //}

        //public int Update(CustomerGroup customer)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
