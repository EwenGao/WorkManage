using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkManage.Models
{
    public class Works
    {
        /// <summary>
        /// 工作流水号
        /// </summary>
        public int WorkId { get; set; }
        /// <summary>
        /// 工作名称
        /// </summary>
        public string WorkName { get; set; }
        /// <summary>
        /// 工作进度 true-完成 false-没有完成
        /// </summary>
        public bool WorkProgress { get; set; }
        /// <summary>
        /// 工作描述，简介
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 工作备注
        /// </summary>
        public string WorkMark { get; set; }
        /// <summary>
        /// 工作完成的时间
        /// </summary>
        public DateTime? CompletionTime { get; set; }
        /// <summary>
        /// 工作创建的时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
    }
}