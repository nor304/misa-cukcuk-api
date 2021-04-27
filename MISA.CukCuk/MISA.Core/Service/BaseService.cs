using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Service
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity: class
    {
        //Inject interface IBaseRepository vào class BaseService
        IBaseRepository<MISAEntity> _baseRepository;
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        //Lấy toàn bộ dữ liệu của đối tượng
        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        //Lấy dữ liệu của đối tượng ứng với Id được truyền vào
        public MISAEntity GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        //Thêm đối tượng
        public int Insert(MISAEntity entity)
        {
            // Validate dữ liệu:
            Validate(entity);
            return _baseRepository.Insert(entity);
        }

        //Khởi tạo hàm virtual để các class con có thể overide
        protected virtual void Validate(MISAEntity entity)
        {

        }
        
        //Thay đổi đối tượng
        public int Update(MISAEntity entity)
        {
            return _baseRepository.Update(entity);
        }

        //Xóa đối tượng
        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }
    }
}
