using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace Leadin.Common
{
    /// <summary>
    /// 缓存的类型，他们之间是否是包含关系？
    /// </summary>
    public enum CoreCacheType
    {
        Host = 1,
        Portal,
        Tab
    }

    /// <summary>
    /// 对系统缓存的操作
    /// </summary>
    public class DataCache
    {
        public DataCache()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 取得某缓存的值
        /// </summary>
        /// <param name="CacheKey">缓存的键</param>
        /// <returns>缓存的值</returns>
        public static object GetCache(string CacheKey)
        {
            // HttpRuntime.Cache：获取当前应用程序的 System.Web.Caching.Cache。
            // System.Web.Caching.Cache：实现用于 Web 应用程序的缓存。
            Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// 设置某缓存的值。
        /// </summary>
        /// <param name="CacheKey">缓存的键</param>
        /// <param name="objObject">缓存的值</param>
        public static void SetCache(string CacheKey, object objObject)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }

        /// <summary>
        /// 设置某缓存的值和跟踪缓存依赖项。
        /// </summary>
        /// <param name="CacheKey">缓存的键</param>
        /// <param name="objObject">缓存的值</param>
        /// <param name="objDependency">缓存依赖项</param>
        public static void SetCache(string CacheKey, object objObject, CacheDependency objDependency)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, objDependency);
        }

        /// <summary>
        /// 设置某缓存的值和跟踪缓存依赖项。
        /// </summary>
        /// <param name="CacheKey">缓存的键</param>
        /// <param name="objObject">缓存的值</param>
        /// <param name="objDependency">缓存依赖项</param>
        /// <param name="AbsoluteExpiration">缓存移出的时间</param>
        /// <param name="SlidingExpiration">缓存的有效期时间长度</param>
        public static void SetCache(string CacheKey, object objObject, CacheDependency objDependency, DateTime AbsoluteExpiration, TimeSpan SlidingExpiration)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, objDependency, AbsoluteExpiration, SlidingExpiration);
        }

        /// <summary>
        /// 设置某缓存的值。
        /// </summary>
        /// <param name="CacheKey">缓存的键</param>
        /// <param name="objObject">缓存的值</param>
        /// <param name="SlidingExpiration">缓存的有效期时间长度</param>
        public static void SetCache(string CacheKey, object objObject, TimeSpan SlidingExpiration)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, Cache.NoAbsoluteExpiration, SlidingExpiration);
        }

        /// <summary>
        ///  设置某缓存的值。
        /// </summary>
        /// <param name="CacheKey">缓存的键</param>
        /// <param name="objObject">缓存的值</param>
        /// <param name="AbsoluteExpiration">缓存移出的时间</param>
        public static void SetCache(string CacheKey, object objObject, DateTime AbsoluteExpiration)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, AbsoluteExpiration, Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 从缓存中移出某键的缓存值
        /// </summary>
        /// <param name="CacheKey">缓存的键</param>
        public static void RemoveCache(string CacheKey)
        {
            Cache objCache = HttpRuntime.Cache;
            if (objCache[CacheKey] != null)
            {
                objCache.Remove(CacheKey);
            }
        }

    }
}
