using System;
using System.Web;
using System.Collections;
using System.Text.RegularExpressions;

namespace thesis.common
{
    public class DataCache
    {
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }
        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }
        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        /// <param name="seconds"></param>
        public static void SetCache(string CacheKey, object objObject, int seconds)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, DateTime.Now.AddSeconds((double)(seconds)), TimeSpan.Zero);
        }

        /// <summary>
        /// 删除Cache项
        /// </summary>
        /// <param name="CacheKey"></param>
        public static void RemoveCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Remove(CacheKey);
        }
        /// <summary>
        /// 清空Cache
        /// </summary>
        public static void ClearCache()
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            IDictionaryEnumerator enumerator = objCache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                objCache.Remove(enumerator.Key.ToString());
            }
        }
        /// <summary>
        /// 按照正则表达式匹配计数
        /// </summary>
        /// <param name="pattern"></param>
        public static int CountByPattern(string pattern)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            IDictionaryEnumerator enumerator = objCache.GetEnumerator();
            Regex regex1 = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            int counter = 0;
            while (enumerator.MoveNext())
            {
                if (regex1.IsMatch(enumerator.Key.ToString()))
                {
                    counter++;
                }
            }
            return counter;
        }
        /// <summary>
        /// 按照正则表达式匹配删除
        /// </summary>
        /// <param name="pattern"></param>
        public static void RemoveByPattern(string pattern)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            IDictionaryEnumerator enumerator = objCache.GetEnumerator();
            Regex regex1 = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            while (enumerator.MoveNext())
            {
                if (regex1.IsMatch(enumerator.Key.ToString()))
                {
                    objCache.Remove(enumerator.Key.ToString());
                }
            }
        }

    }
}
