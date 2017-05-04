using System;
using System.Reflection;
using System.Configuration;
using Leadin.IDAL;
using Leadin.Common;

namespace Leadin.DALFactory
{
    /// <summary>
    /// 抽象工厂模式创建DAL。
    /// web.config 需要加入配置：(利用工厂模式+反射机制+缓存机制,实现动态创建不同的数据层对象接口) 
    /// DataCache类在导出代码的文件夹里
    /// <appSettings> 
    /// <add key="DAL" value="leadin.SQLServerDAL" /> (这里的命名空间根据实际情况更改为自己项目的命名空间)
    /// </appSettings> 
    /// </summary>
    public sealed class DataAccess//<t>
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string AssemblyPath, string ClassNamespace)
        {
            object objType = DataCache.GetCache(ClassNamespace);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//反射创建
                    DataCache.SetCache(ClassNamespace, objType);// 写入缓存
                }
                catch
                { }
            }
            return objType;
        }

        /// <summary>
        /// 创建Category数据层接口。
        /// </summary>
        public static Leadin.IDAL.ICategory CreateCategory()
        {

            string ClassNamespace = AssemblyPath + ".Category";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Leadin.IDAL.ICategory)objType;
        }


        /// <summary>
        /// 创建Customer数据层接口。
        /// </summary>
        public static Leadin.IDAL.ICustomer CreateCustomer()
        {

            string ClassNamespace = AssemblyPath + ".Customer";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Leadin.IDAL.ICustomer)objType;
        }


        /// <summary>
        /// 创建CustomerAddress数据层接口。
        /// </summary>
        public static Leadin.IDAL.ICustomerAddress CreateCustomerAddress()
        {

            string ClassNamespace = AssemblyPath + ".CustomerAddress";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Leadin.IDAL.ICustomerAddress)objType;
        }


        /// <summary>
        /// 创建Distribution数据层接口。
        /// </summary>
        public static Leadin.IDAL.IDistribution CreateDistribution()
        {

            string ClassNamespace = AssemblyPath + ".Distribution";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Leadin.IDAL.IDistribution)objType;
        }


        /// <summary>
        /// 创建FatherOrder数据层接口。
        /// </summary>
        public static Leadin.IDAL.IFatherOrder CreateFatherOrder()
        {

            string ClassNamespace = AssemblyPath + ".FatherOrder";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Leadin.IDAL.IFatherOrder)objType;
        }


        /// <summary>
        /// 创建OrdeChange数据层接口。
        /// </summary>
        public static Leadin.IDAL.IOrdeChange CreateOrdeChange()
        {

            string ClassNamespace = AssemblyPath + ".OrdeChange";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Leadin.IDAL.IOrdeChange)objType;
        }


        /// <summary>
        /// 创建OrdeDistribution数据层接口。
        /// </summary>
        public static Leadin.IDAL.IOrdeDistribution CreateOrdeDistribution()
        {

            string ClassNamespace = AssemblyPath + ".OrdeDistribution";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Leadin.IDAL.IOrdeDistribution)objType;
        }


        /// <summary>
        /// 创建OrdeTechnology数据层接口。
        /// </summary>
        public static Leadin.IDAL.IOrdeTechnology CreateOrdeTechnology()
        {

            string ClassNamespace = AssemblyPath + ".OrdeTechnology";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Leadin.IDAL.IOrdeTechnology)objType;
        }


        /// <summary>
        /// 创建Paper数据层接口。
        /// </summary>
        public static Leadin.IDAL.IPaper CreatePaper()
        {

            string ClassNamespace = AssemblyPath + ".Paper";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Leadin.IDAL.IPaper)objType;
        }


        /// <summary>
        /// 创建PublicVersion数据层接口。
        /// </summary>
        public static Leadin.IDAL.IPublicVersion CreatePublicVersion()
        {

            string ClassNamespace = AssemblyPath + ".PublicVersion";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Leadin.IDAL.IPublicVersion)objType;
        }


        /// <summary>
        /// 创建Purchase数据层接口。
        /// </summary>
        public static Leadin.IDAL.IPurchase CreatePurchase()
        {

            string ClassNamespace = AssemblyPath + ".Purchase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Leadin.IDAL.IPurchase)objType;
        }


        /// <summary>
        /// 创建SonOrder数据层接口。
        /// </summary>
        public static Leadin.IDAL.ISonOrder CreateSonOrder()
        {

            string ClassNamespace = AssemblyPath + ".SonOrder";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Leadin.IDAL.ISonOrder)objType;
        }


        /// <summary>
        /// 创建Supplier数据层接口。
        /// </summary>
        public static Leadin.IDAL.ISupplier CreateSupplier()
        {

            string ClassNamespace = AssemblyPath + ".Supplier";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Leadin.IDAL.ISupplier)objType;
        }


        /// <summary>
        /// 创建Technology数据层接口。
        /// </summary>
        public static Leadin.IDAL.ITechnology CreateTechnology()
        {

            string ClassNamespace = AssemblyPath + ".Technology";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Leadin.IDAL.ITechnology)objType;
        }


        /// <summary>
        /// 创建Workers数据层接口。
        /// </summary>
        public static Leadin.IDAL.IWorkers CreateWorkers()
        {

            string ClassNamespace = AssemblyPath + ".Workers";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Leadin.IDAL.IWorkers)objType;
        }

    }
}