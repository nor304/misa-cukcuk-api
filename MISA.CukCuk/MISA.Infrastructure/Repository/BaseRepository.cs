using Dapper;
using MISA.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity>: IBaseRepository<MISAEntity> where MISAEntity: class
    {
        //Khởi tạo variable dùng chung, không lặp lại code
        string tableName = typeof(MISAEntity).Name;
        protected string connectionString = "" +
            "Host = 47.241.69.179;" +
            "Port = 3306;" +
            "Database = MF0_NVManh_CukCuk02;" +
            "User Id= dev;" +
            "Password = 12345678;";
        protected IDbConnection dbConnection;

        //Lấy toàn bộ dữ liệu của đối tượng
        public IEnumerable<MISAEntity> GetAll()
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var entities = dbConnection.Query<MISAEntity>($"Proc_Get{tableName}s", commandType: CommandType.StoredProcedure);
                return entities;
            }
        }

        //Lấy dữ liệu của đối tượng ứng với Id được truyền vào
        public MISAEntity GetById(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{tableName}Id", entityId);
                var entity = dbConnection.QueryFirstOrDefault<MISAEntity>($"Proc_Get{tableName}ById",
                    param: parameters, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        //Thêm đối tượng
        public int Insert(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var rowsAffect = dbConnection.Execute($"Proc_Insert{tableName}", param: entity,
                commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }

        //Thay đổi đối tượng
        public int Update(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var rowsAffect = dbConnection.Execute($"Proc_Update{tableName}", param: entity,
               commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }

        //Xóa đối tượng
        public int Delete(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{tableName}Id", entityId);
                var rowsAffect = dbConnection.Execute($"Proc_Delete{tableName}ById", param: parameters,
                    commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }

    }
}