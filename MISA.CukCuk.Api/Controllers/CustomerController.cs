using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using MySqlConnector;
using MISA.CukCuk.Api.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            // 1. Khai báo thông tin kết nối tới Database:
            var connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database= MF0_NVManh_CukCuk02;" +
                "User Id = dev;" +
                "Password= 12345678";
            // 2. Khởi tạo kết nối:
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // 3. Tương tác với Database (lấy dữ liệu, sửa dữ liệu, xóa dữ liệu)
            var sqlCommand = "Proc_DemoGetCustomer";
            var customers = dbConnection.Query<Customer>(sqlCommand, commandType: CommandType.StoredProcedure);
            // 4. Kiểm tra dữ liệu và trả về cho Client
            // - Nếu có dữ liệu thì trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (customers.Count() > 0)
            {
                return Ok(customers);
            }
            else
            {
                return NoContent();
            }

        }

        [HttpGet("Paging")]
        public IActionResult GetPaging(int pageIndex, int pageSize)
        {
            // 1. Khai báo thông tin kết nối tới Database:
            var connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database= MF0_NVManh_CukCuk02;" +
                "User Id = dev;" +
                "Password= 12345678";
            // 2. Khởi tạo kết nối:
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // 3. Tương tác với Database (lấy dữ liệu, sửa dữ liệu, xóa dữ liệu)
            var sqlCommand = "Proc_GetCustomerPaging";
            var param = new
            {
                m_PageIndex = 1,
                m_PageSize = 10
            };

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@m_PageIndex", 1);
            dynamicParameters.Add("@m_PageSize", 10);

            var customers = dbConnection.Query<Customer>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            // 4. Kiểm tra dữ liệu và trả về cho Client
            // - Nếu có dữ liệu thì trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (customers.Count() > 0)
            {
                return Ok(customers);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            // 1. Khai báo thông tin kết nối:
            var connectionString = "" +
               "Host = 47.241.69.179;" +
               "Port = 3306;" +
               "Database= MF0_NVManh_CukCuk02;" +
               "User Id = dev;" +
               "Password= 12345678";
            // 2. Khởi tạo kết nối:
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // 3. Thực thi lệnh lấy dữ liệu trong Database:
            var sqlCommand = $"SELECT * FROM Customer WHERE CustomerId = '{id.ToString()}'";
            var customer = dbConnection.QueryFirstOrDefault<Customer>(sqlCommand);
            // 4. Trả về cho Client:
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            try
            {
                // Validate dữ liệu:
                // -Mã khách hàng không được phép trùng:
                var customerCode = customer.CustomerCode;
                // - Truy cập vào database kiểm tra xem có khách hàng nào có mã tương tự không:

                // 1. Khai báo thông tin kết nối:
                var connectionString = "" +
                   "Host = 47.241.69.179;" +
                   "Port = 3306;" +
                   "Database= MF0_NVManh_CukCuk02;" +
                   "User Id = dev;" +
                   "Password= 12345678";
                // 2. Khởi tạo kết nối:
                IDbConnection dbConnection = new MySqlConnection(connectionString);
                // Kiểm tra trùng mã:
                var customerCodeDuplicate = dbConnection.ExecuteScalar<string>($"SELECT CustomerCode FROM Customer c WHERE c.CustomerCode = '{customerCode}'");
                if (customerCodeDuplicate != null)
                {
                    var mes = new
                    {
                        devMsg = "",
                        userMsg = "",
                        data = customerCodeDuplicate,
                        field = "CustomerCode"
                    };
                    return BadRequest(mes);
                }
                // 3. Thực thi lệnh lấy dữ liệu trong Database:
                var sqlCommand = $"Proc_InsertCustomer";
                var rowAffects = dbConnection.Execute(sqlCommand, param: customer, commandType: CommandType.StoredProcedure);
                // 4. Trả về cho Client:
                if (rowAffects > 0)
                {
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp",
                    field = "CustomerCode"
                };
                return StatusCode(500,mes);
            }

        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
