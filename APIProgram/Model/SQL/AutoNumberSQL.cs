using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace APIProgram.Model.SQL
{
    public class AutoNumberSQL
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private readonly string _connectString = @"Server=LAPTOP-VHAM6CF5\SQLEXPRESS;Database=Project;Trusted_Connection=True;";

        public string GetNumber(string AutoNumberCode)
        {
            string sql =
            @"
                Select RIGHT(REPLICATE('0', [CodingLength]) + CAST([AvailableNumber] as NVARCHAR), [CodingLength]) as CardNo From  [AutoNumber] 
                where [AutoNumberCode] = @AutoNumberCode ;
                update [AutoNumber] 
                set [AvailableNumber] = [AvailableNumber]+1
                where [AutoNumberCode] = @AutoNumberCode ;
            ";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("AutoNumberCode", AutoNumberCode);


            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.QueryFirstOrDefault<AutoNumber>(sql, parameters);
                return result.CardNo;
            }

        }
    }
}