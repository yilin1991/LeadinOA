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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Leadin.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace Leadin.DAL
{
	/// <summary>
	/// 数据访问类:Purchase
	/// </summary>
	public partial class Purchase:IPurchase
	{
		public Purchase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "tb_Purchase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Purchase");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Leadin.Model.Purchase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Purchase(");
			strSql.Append("NumId,PaperId,SupplierId,Num,PurchasePrice,SellingPrice,Freight,WorkersId,Explain,StateInfo,Remark,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@NumId,@PaperId,@SupplierId,@Num,@PurchasePrice,@SellingPrice,@Freight,@WorkersId,@Explain,@StateInfo,@Remark,@AddTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NumId", SqlDbType.NVarChar,100),
					new SqlParameter("@PaperId", SqlDbType.Int,4),
					new SqlParameter("@SupplierId", SqlDbType.Int,4),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@PurchasePrice", SqlDbType.Decimal,9),
					new SqlParameter("@SellingPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Freight", SqlDbType.Decimal,9),
					new SqlParameter("@WorkersId", SqlDbType.Int,4),
					new SqlParameter("@Explain", SqlDbType.NText),
					new SqlParameter("@StateInfo", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.NumId;
			parameters[1].Value = model.PaperId;
			parameters[2].Value = model.SupplierId;
			parameters[3].Value = model.Num;
			parameters[4].Value = model.PurchasePrice;
			parameters[5].Value = model.SellingPrice;
			parameters[6].Value = model.Freight;
			parameters[7].Value = model.WorkersId;
			parameters[8].Value = model.Explain;
			parameters[9].Value = model.StateInfo;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.AddTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Leadin.Model.Purchase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Purchase set ");
			strSql.Append("NumId=@NumId,");
			strSql.Append("PaperId=@PaperId,");
			strSql.Append("SupplierId=@SupplierId,");
			strSql.Append("Num=@Num,");
			strSql.Append("PurchasePrice=@PurchasePrice,");
			strSql.Append("SellingPrice=@SellingPrice,");
			strSql.Append("Freight=@Freight,");
			strSql.Append("WorkersId=@WorkersId,");
			strSql.Append("Explain=@Explain,");
			strSql.Append("StateInfo=@StateInfo,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@NumId", SqlDbType.NVarChar,100),
					new SqlParameter("@PaperId", SqlDbType.Int,4),
					new SqlParameter("@SupplierId", SqlDbType.Int,4),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@PurchasePrice", SqlDbType.Decimal,9),
					new SqlParameter("@SellingPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Freight", SqlDbType.Decimal,9),
					new SqlParameter("@WorkersId", SqlDbType.Int,4),
					new SqlParameter("@Explain", SqlDbType.NText),
					new SqlParameter("@StateInfo", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.NumId;
			parameters[1].Value = model.PaperId;
			parameters[2].Value = model.SupplierId;
			parameters[3].Value = model.Num;
			parameters[4].Value = model.PurchasePrice;
			parameters[5].Value = model.SellingPrice;
			parameters[6].Value = model.Freight;
			parameters[7].Value = model.WorkersId;
			parameters[8].Value = model.Explain;
			parameters[9].Value = model.StateInfo;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.AddTime;
			parameters[12].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Purchase ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Purchase ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Leadin.Model.Purchase GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,NumId,PaperId,SupplierId,Num,PurchasePrice,SellingPrice,Freight,WorkersId,Explain,StateInfo,Remark,AddTime from tb_Purchase ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Leadin.Model.Purchase model=new Leadin.Model.Purchase();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Leadin.Model.Purchase DataRowToModel(DataRow row)
		{
			Leadin.Model.Purchase model=new Leadin.Model.Purchase();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["NumId"]!=null)
				{
					model.NumId=row["NumId"].ToString();
				}
				if(row["PaperId"]!=null && row["PaperId"].ToString()!="")
				{
					model.PaperId=int.Parse(row["PaperId"].ToString());
				}
				if(row["SupplierId"]!=null && row["SupplierId"].ToString()!="")
				{
					model.SupplierId=int.Parse(row["SupplierId"].ToString());
				}
				if(row["Num"]!=null && row["Num"].ToString()!="")
				{
					model.Num=int.Parse(row["Num"].ToString());
				}
				if(row["PurchasePrice"]!=null && row["PurchasePrice"].ToString()!="")
				{
					model.PurchasePrice=decimal.Parse(row["PurchasePrice"].ToString());
				}
				if(row["SellingPrice"]!=null && row["SellingPrice"].ToString()!="")
				{
					model.SellingPrice=decimal.Parse(row["SellingPrice"].ToString());
				}
				if(row["Freight"]!=null && row["Freight"].ToString()!="")
				{
					model.Freight=decimal.Parse(row["Freight"].ToString());
				}
				if(row["WorkersId"]!=null && row["WorkersId"].ToString()!="")
				{
					model.WorkersId=int.Parse(row["WorkersId"].ToString());
				}
				if(row["Explain"]!=null)
				{
					model.Explain=row["Explain"].ToString();
				}
				if(row["StateInfo"]!=null && row["StateInfo"].ToString()!="")
				{
					model.StateInfo=int.Parse(row["StateInfo"].ToString());
				}
				if(row["Remark"]!=null && row["Remark"].ToString()!="")
				{
					model.Remark=int.Parse(row["Remark"].ToString());
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,NumId,PaperId,SupplierId,Num,PurchasePrice,SellingPrice,Freight,WorkersId,Explain,StateInfo,Remark,AddTime ");
			strSql.Append(" FROM tb_Purchase ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,NumId,PaperId,SupplierId,Num,PurchasePrice,SellingPrice,Freight,WorkersId,Explain,StateInfo,Remark,AddTime ");
			strSql.Append(" FROM tb_Purchase ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_Purchase ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Purchase T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_Purchase";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

