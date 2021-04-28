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
            using (dbConnection = new MySqlConnection(connectionString))
            {
                // Check dữ liệu:
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_CustomerCode", customerCode);
                var result = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists",
                    dynamicParameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public bool CheckPhoneNumnerExits(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
