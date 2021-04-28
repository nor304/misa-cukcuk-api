using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    public class BaseController<MISAEntity> : Controller where MISAEntity:class
    {
        //Inject interface BaseService và BaseRepository vào class BaseController
        IBaseService<MISAEntity> _baseService;
        IBaseRepository<MISAEntity> _baseRepository; 
        public BaseController(IBaseService<MISAEntity> baseService, IBaseRepository<MISAEntity> baseRepository)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
        }

        //Lấy toàn bộ dữ liệu về đối tượng
        // <returns>
        // HttpStatusCode 200 - có dữ liệu trả về
        // HttpStatusCode 204 - không có dữ liệu
        // </returns>
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseRepository.GetAll();
                if (entities.Count() > 0)
                {
                    return Ok(entities);
                }
                else
                {
                    return NoContent();
                }
        }

        //Lấy thông tin về đối tượng cụ thể với Id được truyền vào
        // <returns>
        // HttpStatusCode 200 - có dữ liệu trả về
        // HttpStatusCode 204 - không có dữ liệu
        // </returns>
        [HttpGet("{entityId}")]
        public IActionResult GetById(Guid entityId){
            var customer = _baseService.GetById(entityId);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NoContent();
            }
        }

        //Thêm mới đối tượng
        // <param name="customer">Thông tin đối tượng</param>
        // <returns>
        // 201 - thêm mới thành công
        // 204 - không thêm được vào db
        // 400 - dữ liệu đầu vào không hợp lệ
        // 500 - có lỗi xảy ra phía server (exception,...)
        // </returns>
        [HttpPost]
        public IActionResult Post(MISAEntity entity){
            var res = _baseService.Insert(entity);
            if (res > 0)
            {
                return StatusCode(201, res);
            }
            else
            {
                return NoContent();
            }
        }

        //Sửa thông tin đối tượng
        // <param name="entityId">Id đối tượng</param>
        // <param name="entity">Đối tượng</param>
        // <returns>Đối tượng được sửa</returns>
        [HttpPut("{entityId}")]
        public IActionResult Put([FromBody] MISAEntity entity)
        {
            var rowAffects = _baseService.Update(entity);
                // Số bản ghi được sửa đổi
                if (rowAffects > 0)
                {
                    return Ok("Sửa thành công");
                }
                return NoContent();
        }

        // Xóa đối tượng
        // <param name="entityId">Id đối tượng</param>
        // <returns>
        // 200 - xóa thành công
        // 204 - không xóa được dữ liệu khỏi DB 
        // </returns>
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var rowAffects = _baseService.Delete(entityId);
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