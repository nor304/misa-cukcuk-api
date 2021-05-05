using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Services
{
    //Service chung phục vụ cho mọi đối tượng (Object)
    public interface IBaseService<MISAEntity> where MISAEntity : class
    {
        //Lấy toàn bộ dữ liệu của đối tượng
        public IEnumerable<MISAEntity> GetAll();
        //Lấy dữ liệu của đối tượng ứng với Id được truyền vào
        public MISAEntity GetById(Guid entityId);
        //Thêm đối tượng
        public int Insert(MISAEntity entity);
        //Thay đổi đối tượng
        public int Update(MISAEntity entity);
        //Xóa đối tượng
        public int Delete(Guid entityId);
    }
}
