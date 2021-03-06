﻿/**  版本信息模板在安装目录下，可自行修改。
* CustomerAddress.cs
*
* 功 能： N/A
* 类 名： CustomerAddress
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/5/2 15:11:20   N/A    初版
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
	/// 数据访问类:CustomerAddress
	/// </summary>
	public partial class CustomerAddress:ICustomerAddress
	{
		public CustomerAddress()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "tb_CustomerAddress"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_CustomerAddress");
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
		public int Add(Leadin.Model.CustomerAddress model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_CustomerAddress(");
			strSql.Append("CustimerId,NameInfo,Phone,Tel,Email,Addressinfo,StateInfo,Remark,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@CustimerId,@NameInfo,@Phone,@Tel,@Email,@Addressinfo,@StateInfo,@Remark,@AddTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CustimerId", SqlDbType.Int,4),
					new SqlParameter("@NameInfo", SqlDbType.NVarChar,100),
					new SqlParameter("@Phone", SqlDbType.NVarChar,100),
					new SqlParameter("@Tel", SqlDbType.NVarChar,100),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@Addressinfo", SqlDbType.NVarChar,500),
					new SqlParameter("@StateInfo", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.CustimerId;
			parameters[1].Value = model.NameInfo;
			parameters[2].Value = model.Phone;
			parameters[3].Value = model.Tel;
			parameters[4].Value = model.Email;
			parameters[5].Value = model.Addressinfo;
			parameters[6].Value = model.StateInfo;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.AddTime;

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
		public bool Update(Leadin.Model.CustomerAddress model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_CustomerAddress set ");
			strSql.Append("CustimerId=@CustimerId,");
			strSql.Append("NameInfo=@NameInfo,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Tel=@Tel,");
			strSql.Append("Email=@Email,");
			strSql.Append("Addressinfo=@Addressinfo,");
			strSql.Append("StateInfo=@StateInfo,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@CustimerId", SqlDbType.Int,4),
					new SqlParameter("@NameInfo", SqlDbType.NVarChar,100),
					new SqlParameter("@Phone", SqlDbType.NVarChar,100),
					new SqlParameter("@Tel", SqlDbType.NVarChar,100),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@Addressinfo", SqlDbType.NVarChar,500),
					new SqlParameter("@StateInfo", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.CustimerId;
			parameters[1].Value = model.NameInfo;
			parameters[2].Value = model.Phone;
			parameters[3].Value = model.Tel;
			parameters[4].Value = model.Email;
			parameters[5].Value = model.Addressinfo;
			parameters[6].Value = model.StateInfo;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.AddTime;
			parameters[9].Value = model.Id;

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
			strSql.Append("delete from tb_CustomerAddress ");
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
			strSql.Append("delete from tb_CustomerAddress ");
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
		public Leadin.Model.CustomerAddress GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,CustimerId,NameInfo,Phone,Tel,Email,Addressinfo,StateInfo,Remark,AddTime from tb_CustomerAddress ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Leadin.Model.CustomerAddress model=new Leadin.Model.CustomerAddress();
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
		public Leadin.Model.CustomerAddress DataRowToModel(DataRow row)
		{
			Leadin.Model.CustomerAddress model=new Leadin.Model.CustomerAddress();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["CustimerId"]!=null && row["CustimerId"].ToString()!="")
				{
					model.CustimerId=int.Parse(row["CustimerId"].ToString());
				}
				if(row["NameInfo"]!=null)
				{
					model.NameInfo=row["NameInfo"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Tel"]!=null)
				{
					model.Tel=row["Tel"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Addressinfo"]!=null)
				{
					model.Addressinfo=row["Addressinfo"].ToString();
				}
				if(row["StateInfo"]!=null && row["StateInfo"].ToString()!="")
				{
					model.StateInfo=int.Parse(row["StateInfo"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select Id,CustimerId,NameInfo,Phone,Tel,Email,Addressinfo,StateInfo,Remark,AddTime ");
			strSql.Append(" FROM tb_CustomerAddress ");
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
			strSql.Append(" Id,CustimerId,NameInfo,Phone,Tel,Email,Addressinfo,StateInfo,Remark,AddTime ");
			strSql.Append(" FROM tb_CustomerAddress ");
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
			strSql.Append("select count(1) FROM tb_CustomerAddress ");
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
			strSql.Append(")AS Row, T.*  from tb_CustomerAddress T ");
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
			parameters[0].Value = "tb_CustomerAddress";
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

