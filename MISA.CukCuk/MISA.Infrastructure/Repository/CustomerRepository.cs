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
    public class CustomerRepository : ICustomerRepository
    {
        public bool CheckCustomerCodeExist(string customerCode)
        {
            // Khởi tạo kết nối:

            // Check dữ liệu:
            return false;

        }

        public bool CheckPhoneNumnerExits(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid customerId)
        {
            string connectionString = "" +
                 "Host = 47.241.69.179;" +
                 "Port = 3306;" +
                 "Database = MF0_NVManh_CukCuk02;" +
                 "User Id= dev;" +
                 "Password = 12345678;";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var rowsAffect = dbConnection.Execute("Proc_DeleteCustomerById", param: parameters,
                commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }

        public IEnumerable<Customer> GetAll()
        {
            string connectionString = "" +
               "Host = 47.241.69.179;" +
               "Port = 3306;" +
               "Database = MF0_NVManh_CukCuk02;" +
               "User Id= dev;" +
               "Password = 12345678;";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //var customers = dbConnection.Query<Customer>("SELECT * FROM Customer WHERE 1=0");
            var customers = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            return customers;
        }

        public Customer GetById(Guid customerId)
        {
            string connectionString = "" +
              "Host = 47.241.69.179;" +
              "Port = 3306;" +
              "Database = MF0_NVManh_CukCuk02;" +
              "User Id= dev;" +
              "Password = 12345678;";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //var customers = dbConnection.Query<Customer>("SELECT * FROM Customer WHERE 1=0");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var customer = dbConnection.QueryFirstOrDefault<Customer>("Proc_GetCustomerById",
                param: parameters, commandType: CommandType.StoredProcedure);
            return customer;
        }

        public int Insert(Customer customer)
        {
            string connectionString = "" +
                   "Host = 47.241.69.179;" +
                   "Port = 3306;" +
                   "Database = MF0_NVManh_CukCuk02;" +
                   "User Id= dev;" +
                   "Password = 12345678;";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var rowsAffect = dbConnection.Execute("Proc_InsertCustomer", param: customer, 
                commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }

        public int Update(Customer customer)
        {
            string connectionString = "" +
                  "Host = 47.241.69.179;" +
                  "Port = 3306;" +
                  "Database = MF0_NVManh_CukCuk02;" +
                  "User Id= dev;" +
                  "Password = 12345678;";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var rowsAffect = dbConnection.Execute("Proc_UpdateCustomer", param: customer,
                commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }
    }
}
