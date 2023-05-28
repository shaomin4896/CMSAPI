using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagementAPI.Models;

namespace CaseManagementApp.Models.ControlItems
{

    public class TestRecord
    {
        public DateTime TestDate { get; set; }
        public CmsCase CmsCase { get; set; }
        public string? DoctorName { get => CmsCase.DoctorName; }
        public decimal? Height { get => CmsCase.Height; }
        public decimal? Weight { get => CmsCase.Weight; }
        
        /// <summary>
        /// 收縮壓
        /// </summary>
        /// <value></value>
        public double? Systolic { get; set; }
        /// <summary>
        /// 舒張壓
        /// </summary>
        /// <value></value>
        public double? Diastolic { get; set; }

        /// <summary>
        /// 糖化血色素
        /// </summary>
        /// <value></value>
        public double? HBAIC { get; set; }
        /// <summary>
        /// 餐前血糖
        /// </summary>
        /// <value></value>
        public double? BloodSugarBeforeMeal { get; set; }

        /// <summary>
        /// 三酸甘油脂
        /// </summary>
        /// <value></value>
        public double? TG { get; set; }

        /// <summary>
        /// 肌酸酐
        /// </summary>
        /// <value></value>
        public double? Creatinine { get; set; }

        /// <summary>
        /// 常規檢查
        /// </summary>
        /// <value></value>
        public bool DidRoutine { get; set; }

        /// <summary>
        /// 低密度脂蛋白
        /// </summary>
        /// <value></value>
        public double? LDL { get; set; }

        /// <summary>
        /// 尿液微量蛋白
        /// </summary>
        /// <value></value>
        public double? Microprotein { get; set; }

        /// <summary>
        /// 足部左腳
        /// </summary>
        /// <value></value>
        public bool? IsLeftNormal { get; set; }

        /// <summary>
        /// 足部右腳
        /// </summary>
        /// <value></value>
        public bool? IsRightNormal { get; set; }

        /// <summary>
        /// 眼睛
        /// </summary>
        /// <value></value>
        public bool? IsNormal { get; set; }

        /// <summary>
        /// 衛教紀錄
        /// 需要顯示 0101011
        /// </summary>
        /// <value></value>
        public HealthHistory? HealthHistory { get; set; }
    }
}