using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProgram.Model
{
    public class Customer
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 會員卡號
        /// </summary>
        public string cardNo { get; set; }

        /// <summary>
        /// 會員名稱
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 行動電話
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 會員生日
        /// </summary>
        public string birthdate { get; set; }

    }
}
