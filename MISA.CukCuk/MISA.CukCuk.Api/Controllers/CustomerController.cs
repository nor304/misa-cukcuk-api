using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Data;
using MISA.Core.Interfaces.Services;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Entities;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : BaseController<Customer>
    {
        //Inject interface ICustomerService vào class CustomerController
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) : base(customerService)
        {
            _customerService = customerService;
        }
    }
}
