using System;
using System.Collections.Generic;

using System.Text;

namespace thesis.model
{
    class CommonInterface
    {
    }
    

    public interface ICacheManager<T>
    {
        /// <summary>
        /// 初始化缓存(全部加载)
        /// </summary>
        void InitialCache();
        /// <summary>
        /// 缓存检查,缓存为空则重新初始化
        /// </summary>
        void CheckCache();
        /// <summary>
        /// 根据对象主键从数据库取对象
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        T GetModel(int ID);
        /// <summary>
        /// 根据对象主键从缓存取对象
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        T GetModelByCache(int ID);
        /// <summary>
        /// 更新缓存对象，不存在则添加到缓存
        /// </summary>
        /// <param name="model"></param>
        void UpadteCacheObject(T model);
        /// <summary>
        /// 从缓存中删除对象
        /// </summary>
        /// <param name="ID"></param>
        void RemoveCacheObject(int ID);
    }
}
