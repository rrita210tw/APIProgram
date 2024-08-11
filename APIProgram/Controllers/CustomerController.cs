using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIProgram.Model;
using APIProgram.Model.SQL;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace APIProgram.Controllers
{
    [ApiController]
    [Route("controller")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerSQL _CustomerSQL;
        public CustomerController()
        {
            this._CustomerSQL = new CustomerSQL();
        }

        private static List<Customer> _Customers = new List<Customer>();

        /// <summary>
        /// 查詢會員
        /// </summary>
        /// <param name="cardNo">會員卡號</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{cardNo}")]
        [Produces("application/json")]
        public Customer Get([FromRoute] string cardNo)
        {
            var result = this._CustomerSQL.GetCustomer(cardNo);
            if (result is null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return result;
        }

        /// <summary>
        /// 新增會員
        /// </summary>
        /// <param name="CustomerItem">會員參數</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert([FromBody] Customer CustomerItem)
        {
            var result = this._CustomerSQL.Create(CustomerItem);
            if (result == 0)
            {
                Response.StatusCode = 404;
                return null;
            }
            return Ok();
        }

        /// <summary>
        /// 更新會員
        /// </summary>
        /// <param name="cardNo">會員編號</param>
        /// <param name="CustomerItem">會員參數</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{cardNo}")]
        public IActionResult Update(
            [FromRoute] string cardNo,
            [FromBody] Customer CustomerItem)
        {
            var result = this._CustomerSQL.Update(cardNo, CustomerItem);
            if (result == false)
            {
                Response.StatusCode = 404;
                return null;
            }
            return Ok();
        }


    }

}