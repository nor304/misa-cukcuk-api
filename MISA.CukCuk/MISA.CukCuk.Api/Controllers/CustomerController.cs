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
    public class CustomerController : ControllerBase
    {
        //Inject interface ICustomerService và ICustomerRepository vào class CustomerController
        ICustomerService _customerService;
        ICustomerRepository _customerRepository;
        public CustomerController(ICustomerService customerService, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _customerService = customerService;
        }

        // Lấy dữ liệu toàn bộ khách hàng
        // <returns>
        // HttpStatusCode 200 - có dữ liệu trả về
        // HttpStatusCode 204 - không có dữ liệu
        // </returns>
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerRepository.GetAll();
            if (customers.Count() > 0)
            {
                return Ok(customers);
            }
            else
            {
                return NoContent();
            }
        }

        // Lấy dữ liệu khách hàng với Id được truyền vào
        // <returns>
        // HttpStatusCode 200 - có dữ liệu trả về
        // HttpStatusCode 204 - không có dữ liệu
        // </returns>
        [HttpGet("{customerId}")]
        public IActionResult GetById(Guid customerId)
        {
            var customer = _customerService.GetById(customerId);
            if (customer==null)
            {
                return NoContent();
            }
            else
            {
                return Ok(customer);
            }
        }

        // Thêm mới khách hàng
        // <param name="customer">Thông tin đối tượng khách hàng</param>
        // <returns>
        // 201 - thêm mới thành công
        // 204 - không thêm được vào db
        // 400 - dữ liệu đầu vào không hợp lệ
        // 500 - có lỗi xảy ra phía server (exception,...)
        // </returns>
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            var res = _customerService.Insert(customer);
            if (res>0)
            {
                return StatusCode(201,res);
            }
            else
            {
                return NoContent();
            }
            // - Check mã có trùng hay không?
            //    string connectionString = "" +
            //         "Host = 47.241.69.179;" +
            //         "Port = 3306;" +
            //         "Database = MF0_NVManh_CukCuk02;" +
            //         "User Id= dev;" +
            //         "Password = 12345678;";
            //     IDbConnection dbConnection = new MySqlConnection(connectionString);

                // DynamicParameters dynamicParameters = new DynamicParameters();
                // dynamicParameters.Add("@m_CustomerCode", customer.CustomerCode);
                // var customerCodeExists = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists", dynamicParameters, commandType: CommandType.StoredProcedure);
                // if (customerCodeExists == true)
                // {
                //     var response = new
                //     {
                //         devMsg = "Mã khách hàng đã tồn tại trong hệ thống!",
                //         MISACode = "002"
                //     };
                //     return BadRequest(response);
                // }
            //FIXME: is this necessery???
        }

        // Sửa thông tin khách hàng 
        // <param name="id">Id khách hàng</param>
        // <param name="customer">Khách hàng</param>
        // <returns>Khách hàng được sửa</returns>
        [HttpPut("{customerId}")]
        public IActionResult Put([FromBody] Customer customer)
        {
            // Số bản ghi được sửa đổi
            var rowAffects = _customerService.Update(customer);
            if (rowAffects > 0)
            {
                return Ok("Sửa thành công");
            }
            return NoContent();
        }

        // Xóa khách hàng 
        // <param name="customerId">Id khách hàng</param>
        // <returns>
        // 200 - xóa thành công
        // 204 - không xóa được dữ liệu khỏi DB 
        // </returns>
        [HttpDelete("{customerId}")]
        public IActionResult Delete(Guid customerId)
        {
            var rowAffects = _customerService.Delete(customerId);
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
