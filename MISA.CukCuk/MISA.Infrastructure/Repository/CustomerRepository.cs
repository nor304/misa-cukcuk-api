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
         // Kiểm tra mã nhân viên có trùng không
         public bool CheckCustomerCodeExist(string customerCode)
        {
            // Khởi tạo kết nối:
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_CustomerCode", customerCode);
                var result = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists",
                    dynamicParameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        // Kiểm tra số điện thoại có trùng không
        public bool CheckPhoneNumnerExits(string phoneNumber)
        {
            // Khởi tạo kết nối:
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_PhoneNumber", phoneNumber);
                var result = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckPhoneNumberExists",
                    dynamicParameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        // Kiểm tra email có trùng không
        public bool CheckEmailExists(string email)
        {
            // Khởi tạo kết nối:
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_Email", email);
                var result = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckEmailExists",
                    dynamicParameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
