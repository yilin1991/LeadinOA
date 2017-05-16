/**  版本信息模板在安装目录下，可自行修改。
* OrdeDistribution.cs
*
* 功 能： N/A
* 类 名： OrdeDistribution
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/5/16 11:39:03   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Leadin.Model
{
	/// <summary>
	/// OrdeDistribution:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrdeDistribution
	{
		public OrdeDistribution()
		{}
		#region Model
		private int _id;
		private int _sonorderid;
		private int _typeid;
		private int _pricetype=0;
		private string _distributionnum;
		private int? _workersid;
		private int? _distributionid;
		private decimal _price=0M;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OrderId
        {
			set{ _sonorderid=value;}
			get{return _sonorderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TypeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PriceType
		{
			set{ _pricetype=value;}
			get{return _pricetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DistributionNum
		{
			set{ _distributionnum=value;}
			get{return _distributionnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? WorkersId
		{
			set{ _workersid=value;}
			get{return _workersid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DistributionId
		{
			set{ _distributionid=value;}
			get{return _distributionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

