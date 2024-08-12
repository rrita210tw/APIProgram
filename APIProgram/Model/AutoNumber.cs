using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProgram.Model
{
    public class AutoNumber
    {
        /// <summary>
        /// 自動編號代碼
        /// </summary>
        public string AutoNumberCode { get; set; }

        /// <summary>
        /// 自動編號名稱
        /// </summary>
        public string AutoNumberName { get; set; }

        /// <summary>
        /// 前導字串
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// 編碼長度
        /// </summary>
        public int CodingLength { get; set; }

        /// <summary>
        /// 起始編號
        /// </summary>
        public int FirstNumber { get; set; }

        /// <summary>
        /// 可用編號
        /// </summary>
        public int AvailableNumber { get; set; }

        /// <summary>
        /// 說明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 使月中前導字串
        /// </summary>
        public string WorkingHeading { get; set; }

        public string CardNo { get; set; }


    }
}
