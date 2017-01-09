using System;
using System.Collections.Generic;
using System.Text;

namespace 天天管家.Entity
{
    /// <summary>
    /// 计划实体类
    /// </summary>
    public class Plan
    {
        /// <summary>
        /// 计划编号
        /// </summary>
        private int id;
        /// <summary>
        /// 计划编号
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 计划名称
        /// </summary>
        private string planName;
        /// <summary>
        /// 计划名称(长期计划可以包含计划1-5，其他的计划没有要求，因为其他计划同时期只能由一个)
        /// 2016-2-6新增题库，计划名称被用作放置题目类型
        /// </summary>
        public string PlanName
        {
            get { return planName; }
            set { planName = value; }
        }
        /// <summary>
        /// 计划类型
        /// </summary>
        private PlanType myPlanType;
        /// <summary>
        /// 计划类型(枚举)
        /// </summary>
        internal PlanType MyPlanType
        {
            get { return myPlanType; }
            set { myPlanType = value; }
        }
        /// <summary>
        /// 计划内容
        /// </summary>
        private string planContent;
        /// <summary>
        /// 计划内容
        /// </summary>
        public string PlanContent
        {
            get { return planContent; }
            set { planContent = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime createTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
        /// <summary>
        /// 创建理由
        /// </summary>
        private string planWhy;
        /// <summary>
        /// 创建理由
        /// </summary>
        public string PlanWhy
        {
            get { return planWhy; }
            set { planWhy = value; }
        }

    }
   /// <summary>
    /// 计划类型，包括 长期计划、  5年计划  、年度计划  、月度计划  、每周计划  、每日计划、日记
    /// </summary>
    public enum PlanType
    {
        /// <summary>
        /// 长期计划
        /// </summary>
        LongPlan=1,
        /// <summary>
        /// 5年计划
        /// </summary>
        FiveYearPlan=2,
        /// <summary>
        /// 年度计划
        /// </summary>
        YearPlan=3,
        /// <summary>
        /// 月度计划
        /// </summary>
        MonthPlan=4,
        /// <summary>
        /// 每周计划
        /// </summary>
        WeekPlan=5,
        /// <summary>
        /// 每日计划
        /// </summary>
        DayPlan=6,
        /// <summary>
        /// 日记
        /// </summary>
        Diary=7,
        /// <summary>
        /// 励志句子
        /// </summary>
        Sentence=8,
        /// <summary>
        /// 题库
        /// </summary>
        Question=9
    }
}
