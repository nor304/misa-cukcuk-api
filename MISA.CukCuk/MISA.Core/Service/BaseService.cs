using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.Core.Exceptions;
using MISA.Core.AttributeCustom;

namespace MISA.Core.Service
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity : class
    {
        //Inject interface IBaseRepository vào class BaseService
        IBaseRepository<MISAEntity> _baseRepository;

        protected List<Object> listValidate;
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            listValidate = new List<Object>();
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
        private void Validate(MISAEntity entity)
        {
            //Lấy ra tất cả property của class
            var properties = typeof(MISAEntity).GetProperties();
            foreach(var property in properties)
            {
                var requiredProperties = property.GetCustomAttributes(typeof(MISAEntity), true);
                var maxLengthProperties = property.GetCustomAttributes(typeof(MISAEntity), true);
                if(requiredProperties.Length > 0)
                {
                    // Lấy giá trị
                    var propertyValue = property.GetValue(entity);
                    //Kiểm tra giá trị
                    if(string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        listValidate.Add(new { devMsg = (requiredProperties[0] as MISARequiredNull).MsgError });
                    }
                }

                // Check maxlength:
                if (maxLengthProperties.Length > 0)
                {
                    // Lấy giá trị:
                    var propertyValue = property.GetValue(entity);
                    var maxLength = (maxLengthProperties[0] as MISAMaxLength).MaxLength;
                    // Kiểm tra giá trị:
                    if (propertyValue.ToString().Length > maxLength)
                    {
                        var msgError = (maxLengthProperties[0] as MISAMaxLength).MsgError;
                        throw new CustomerException(msgError);
                    }
                }
            }

            CustomValidate(entity);
        }

        protected virtual void CustomValidate(MISAEntity entity)
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
