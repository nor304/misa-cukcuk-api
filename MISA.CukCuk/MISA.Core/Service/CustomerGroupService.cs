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
        protected override void CustomValidate(CustomerGroup entity)
        {
            if(string.IsNullOrEmpty(entity.CustomerGroupName))
            {
                throw new Exception("Tên nhóm khách hàng không được phép để trống");
            }
            
        }
    }
}
