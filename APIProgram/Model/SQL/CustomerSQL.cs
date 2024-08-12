using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProgram.Model.SQL
{
    public class CustomerSQL : AppConfigurationService
    {

        /// <summary>
        /// 查詢會員
        /// </summary>
        /// <returns></returns>
        public Customer GetCustomer(string cardNo)
        {
            string sql =
            @"
                SELECT * 
                FROM Customer 
                Where cardNo = @cardNo
            ";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cardNo", cardNo);

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.QueryFirstOrDefault<Customer>(sql, parameters);
                return result;
            }
        }


        /// <summary>
        /// 新增會員
        /// </summary>
        /// <param name="item">參數</param>
        /// <returns></returns>
        public int Create(Customer item)
        {
            item.cardNo = GetCardNo();

            string sql =
            @"
                INSERT INTO Customer 
                (
                     [cardNo]
                    ,[CustomerName]
                    ,[phone]
                    ,[birthdate]
                ) 
                VALUES 
                (
                    @cardNo
                   ,@CustomerName
                   ,@phone
                   ,@birthdate
                );
        
                SELECT @@IDENTITY;
            ";

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.QueryFirstOrDefault<int>(sql, item);
                return result;
            }
        }

        /// <summary>
        /// 修改會員
        /// </summary>
        /// <param name="cardNo">cardNo</param>
        /// <param name="item">Customer</param>
        /// <returns></returns>
        public bool Update(string cardNo, Customer item)
        {
            string sql =
            @"
                UPDATE Customer
                SET 
                     [cardNo] = @cardNo
                    ,[CustomerName] = @CustomerName
                    ,[phone] = @phone
                    ,[birthdate] = @birthdate
                WHERE 
                    cardNo = @cardNo
            ";

            DynamicParameters parameters = new DynamicParameters(item);
            parameters.Add("cardNo", cardNo, System.Data.DbType.Int64);

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.Execute(sql, parameters);
                return result > 0;
            }
        }

        /// <summary>
        /// 刪除會員
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>

        public bool deleteCustomer(int id)
        {
            string sql =
            @"
                delete Customer 
                Where id = @id
            ";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", id);

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.Execute(sql, parameters);
                return result > 0;
            }
        }

        /// <summary>
        /// 取得目前可用卡號
        /// </summary>
        public string GetCardNo()
        {
            return new AutoNumberSQL().GetNumber("CardNo");
        }

    }
}
