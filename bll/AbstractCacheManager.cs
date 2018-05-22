using System;
using System.Collections.Generic;
using System.Text;
using thesis.model;
using thesis.common;
namespace thesis.bll
{
    public abstract class AbstractCacheManager<T>:ICacheManager<T> 
    {
        private string GetCacheKey(int ID)
        {
            Type t = typeof(T);
            string CacheKey = t.Name + "-" + ID;
            return CacheKey;
        }
        #region ICacheManager<T> 成员

        public abstract void InitialCache();
        /// <summary>
        /// 缓存检查,缓存为空则重新初始化
        /// </summary>
        public void CheckCache()
        {
            Type t = typeof(T);
            string pattern = t.Name + "-(.*)" ;
            int counter = DataCache.CountByPattern(pattern);
            if (counter <= 0) InitialCache();
        }

        public abstract T GetModel(int ID);

        /// <summary>
        /// 根据对象主键从缓存取对象,如果不在缓存则从数据库取，同时添加到缓存
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T GetModelByCache(int ID)
        {
            string CacheKey = GetCacheKey(ID);
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = this.GetModel(ID);
                    if (objModel != null)
                    {
                        int Timeout = ConfigHelper.GetConfigInt("CacheTimeout");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(Timeout), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (T)objModel;
        }
        /// <summary>
        /// 更新缓存对象，不存在则添加到缓存
        /// </summary>
        /// <param name="model"></param>
        public void UpadteCacheObject(T model)
        {
            if (model == null) return;
            object key = ReflectUtil.GetProperty(model, "ID");
            if (key == null) throw new Exception("对象不存在ID属性,或者ID属性为null"); ;
            int IntKey = 0;
            try
            {
                Convert.ToInt32(key);
            }
            catch
            {
                throw new Exception("对象的ID属性不能转化为整型");
            }
            string CacheKey = GetCacheKey(IntKey);
            DataCache.RemoveCache(CacheKey);
            int Timeout = ConfigHelper.GetConfigInt("CacheTimeout");
            DataCache.SetCache(CacheKey, model, DateTime.Now.AddMinutes(Timeout), TimeSpan.Zero);
        }
        /// <summary>
        /// 从缓存中删除对象
        /// </summary>
        /// <param name="ID"></param>
        public void RemoveCacheObject(int ID)
        {
            string CacheKey = GetCacheKey(ID);
            DataCache.RemoveCache(CacheKey);
        }

        #endregion
  
    }
}
