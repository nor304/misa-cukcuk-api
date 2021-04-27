using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
         public bool CheckCustomerCodeExist(string customerCode)
        {
            // Khởi tạo kết nối:

            // Check dữ liệu:
            // TODO: Validate dữ liệu
            return true;
        }

        public bool CheckPhoneNumnerExits(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
