using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/customer-groups")]
    [ApiController]
    public class CustomerGroupController : BaseController<CustomerGroup>
    {
        //Inject interface ICustomerGroupService và ICustomerGroupRepository vào class CustomerGroupController
        ICustomerGroupService _customerGroupService;
        public CustomerGroupController(ICustomerGroupService customerGroupService) : base(customerGroupService)
        {
            _customerGroupService = customerGroupService;
        }

       
    }
}
