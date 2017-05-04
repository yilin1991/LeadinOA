/**  版本信息模板在安装目录下，可自行修改。
* OrdeDistribution.cs
*
* 功 能： N/A
* 类 名： OrdeDistribution
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/5/2 15:11:24   N/A    初版
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
	/// 数据访问类:OrdeDistribution
	/// </summary>
	public partial class OrdeDistribution:IOrdeDistribution
	{
		public OrdeDistribution()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "tb_OrdeDistribution"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_OrdeDistribution");
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
		public int Add(Leadin.Model.OrdeDistribution model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_OrdeDistribution(");
			strSql.Append("SonOrderId,TypeId,WorkersId,DistributionId,Price,Remark)");
			strSql.Append(" values (");
			strSql.Append("@SonOrderId,@TypeId,@WorkersId,@DistributionId,@Price,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SonOrderId", SqlDbType.Int,4),
					new SqlParameter("@TypeId", SqlDbType.Int,4),
					new SqlParameter("@WorkersId", SqlDbType.Int,4),
					new SqlParameter("@DistributionId", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Remark", SqlDbType.NText)};
			parameters[0].Value = model.SonOrderId;
			parameters[1].Value = model.TypeId;
			parameters[2].Value = model.WorkersId;
			parameters[3].Value = model.DistributionId;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.Remark;

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
		public bool Update(Leadin.Model.OrdeDistribution model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_OrdeDistribution set ");
			strSql.Append("SonOrderId=@SonOrderId,");
			strSql.Append("TypeId=@TypeId,");
			strSql.Append("WorkersId=@WorkersId,");
			strSql.Append("DistributionId=@DistributionId,");
			strSql.Append("Price=@Price,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@SonOrderId", SqlDbType.Int,4),
					new SqlParameter("@TypeId", SqlDbType.Int,4),
					new SqlParameter("@WorkersId", SqlDbType.Int,4),
					new SqlParameter("@DistributionId", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.SonOrderId;
			parameters[1].Value = model.TypeId;
			parameters[2].Value = model.WorkersId;
			parameters[3].Value = model.DistributionId;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.Id;

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
			strSql.Append("delete from tb_OrdeDistribution ");
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
			strSql.Append("delete from tb_OrdeDistribution ");
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
		public Leadin.Model.OrdeDistribution GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,SonOrderId,TypeId,WorkersId,DistributionId,Price,Remark from tb_OrdeDistribution ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Leadin.Model.OrdeDistribution model=new Leadin.Model.OrdeDistribution();
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
		public Leadin.Model.OrdeDistribution DataRowToModel(DataRow row)
		{
			Leadin.Model.OrdeDistribution model=new Leadin.Model.OrdeDistribution();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["SonOrderId"]!=null && row["SonOrderId"].ToString()!="")
				{
					model.SonOrderId=int.Parse(row["SonOrderId"].ToString());
				}
				if(row["TypeId"]!=null && row["TypeId"].ToString()!="")
				{
					model.TypeId=int.Parse(row["TypeId"].ToString());
				}
				if(row["WorkersId"]!=null && row["WorkersId"].ToString()!="")
				{
					model.WorkersId=int.Parse(row["WorkersId"].ToString());
				}
				if(row["DistributionId"]!=null && row["DistributionId"].ToString()!="")
				{
					model.DistributionId=int.Parse(row["DistributionId"].ToString());
				}
				if(row["Price"]!=null && row["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(row["Price"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select Id,SonOrderId,TypeId,WorkersId,DistributionId,Price,Remark ");
			strSql.Append(" FROM tb_OrdeDistribution ");
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
			strSql.Append(" Id,SonOrderId,TypeId,WorkersId,DistributionId,Price,Remark ");
			strSql.Append(" FROM tb_OrdeDistribution ");
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
			strSql.Append("select count(1) FROM tb_OrdeDistribution ");
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
			strSql.Append(")AS Row, T.*  from tb_OrdeDistribution T ");
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
			parameters[0].Value = "tb_OrdeDistribution";
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

