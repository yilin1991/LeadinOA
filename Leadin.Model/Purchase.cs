/**  版本信息模板在安装目录下，可自行修改。
* Purchase.cs
*
* 功 能： N/A
* 类 名： Purchase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/5/2 15:11:28   N/A    初版
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
	/// Purchase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Purchase
	{
		public Purchase()
		{}
		#region Model
		private int _id;
		private string _numid;
		private int _paperid;
		private int? _supplierid;
		private int _num=1;
		private decimal _purchaseprice=0M;
		private decimal _sellingprice=0M;
		private decimal _freight=0M;
		private int? _workersid;
		private string _explain;
		private int _stateinfo=0;
		private int? _remark;
		private DateTime _addtime= DateTime.Now;
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
		public int PaperId
		{
			set{ _paperid=value;}
			get{return _paperid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SupplierId
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal PurchasePrice
		{
			set{ _purchaseprice=value;}
			get{return _purchaseprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal SellingPrice
		{
			set{ _sellingprice=value;}
			get{return _sellingprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Freight
		{
			set{ _freight=value;}
			get{return _freight;}
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
		public string Explain
		{
			set{ _explain=value;}
			get{return _explain;}
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
		public int? Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

