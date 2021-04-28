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
    public class CustomerGroupController : ControllerBase
    {
        //Inject interface ICustomerGroupService và ICustomerGroupRepository vào class CustomerGroupController
        ICustomerGroupService _customerGroupService;
        ICustomerGroupRepository _customerGroupRepository;
        public CustomerGroupController(ICustomerGroupService customerGroupService, ICustomerGroupRepository customerGroupRepository)
        {
            _customerGroupService = customerGroupService;
            _customerGroupRepository = customerGroupRepository;
        }

        // Lấy dữ liệu toàn bộ nhóm khách hàng
        // <returns>
        // HttpStatusCode 200 - có dữ liệu trả về
        // HttpStatusCode 204 - không có dữ liệu
        // </returns>
        [HttpGet]
        public IActionResult Get()
        {
            var customersGroups = _customerGroupRepository.GetAll();
            if (customersGroups.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(customersGroups);
            }
        }

        // Lấy dữ liệu nhóm khách hàng với Id được truyền vào
        // <returns>
        // HttpStatusCode 200 - có dữ liệu trả về
        // HttpStatusCode 204 - không có dữ liệu
        // </returns>
        [HttpGet("{customerGroupId}")]
        public IActionResult Get(Guid customerGroupId)
        {
            var customerGroup = _customerGroupRepository.GetById(customerGroupId);
            if (customerGroup == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(customerGroup);
            }
        }

        // Thêm mới nhóm khách hàng
        // <param name="customerGroup">Thông tin nhóm khách hàng</param>
        // <returns>
        // 201 - thêm mới thành công
        // 204 - không thêm được vào db
        // 400 - dữ liệu đầu vào không hợp lệ
        // 500 - có lỗi xảy ra phía server (exception,...)
        // </returns>
        [HttpPost]
        public IActionResult Post(CustomerGroup customerGroup)
        {
            var res = _customerGroupService.Insert(customerGroup);
            if (res > 0)
            {
                return StatusCode(201, res);
            }
            else
            {
                return NoContent();
            }
        }

        // Sửa thông tin nhóm khách hàng 
        // <param name="customerGroup">Đối tượng nhóm khách hàng</param>
        // <returns>Nhóm khách hàng được sửa</returns>
        [HttpPut("{customerGroupId}")]
        public IActionResult Put([FromBody] CustomerGroup customerGroup) {
            var rowAffects = _customerGroupService.Update(customerGroup);
            // Số bản ghi được sửa đổi
            if (rowAffects > 0)
            {
                return Ok("Sửa thành công"); 
            }
            else
            {
                return NoContent();
            }
        }

        //Xóa nhóm khách hàng
        //<param name="id">Id khách hàng</param>
        // <returns>
        // 200 - xóa thành công
        // 204 - không xóa được dữ liệu khỏi DB 
        // </returns>
        [HttpDelete("{customerGroupId}")]
        public IActionResult Delete(Guid customerGroupId)
        {
            var rowAffects = _customerGroupService.Delete(customerGroupId);
            if (rowAffects > 0)
            {
                return Ok("Xóa thành công");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
