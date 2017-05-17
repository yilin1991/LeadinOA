/**  版本信息模板在安装目录下，可自行修改。
* SonOrder.cs
*
* 功 能： N/A
* 类 名： SonOrder
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/5/2 15:11:29   N/A    初版
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
	/// SonOrder:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SonOrder
	{
		public SonOrder()
		{}
		#region Model
		private int _id;
		private string _numid;
		private int? _paperid;
		private decimal _num=1M;
		private int? _publicversionid;
		private int _typeid;
		private int _stateinfo;
		private int? _workersid;
		private int? _fatherorderid;
		private DateTime _addtime= DateTime.Now;
		private decimal _differenceprice=0M;
		private string _differencereason;
		private string _explain;
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
		public string NumId
		{
			set{ _numid=value;}
			get{return _numid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PaperId
		{
			set{ _paperid=value;}
			get{return _paperid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PublicVersionId
		{
			set{ _publicversionid=value;}
			get{return _publicversionid;}
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
		public int StateInfo
		{
			set{ _stateinfo=value;}
			get{return _stateinfo;}
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
		public int? FatherOrderId
		{
			set{ _fatherorderid=value;}
			get{return _fatherorderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal DifferencePrice
		{
			set{ _differenceprice=value;}
			get{return _differenceprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DifferenceReason
		{
			set{ _differencereason=value;}
			get{return _differencereason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Explain
		{
			set{ _explain=value;}
			get{return _explain;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}

        public int CustomerID { get; set; }
        #endregion Model

    }
}

