
using System;
using System.Collections.Generic;
using UnityEngine;
public static class CacheManager
{
    static Dictionary<Type, Type> MapTable = new Dictionary<Type, Type>() 
    {
             {typeof(AssetBundle),typeof(CacheAssetbundle)},
    };

    static CacheBase<T> GetType<T>(string key)
    {
        Type t = typeof(T);
        if(MapTable.ContainsKey(t))
        {
            Type c = MapTable[t];
            CacheBase<T> cb = Activator.CreateInstance(c, key ) as CacheBase<T>;
            return cb;
        }
        else
        {
            CacheBase<T> cb = new CacheBase<T>(key);
            return cb;
        }                
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="v"></param>
    /// <param name="forever">true内存永驻 只能Delete释放 false可根据规则自动释放</param>
    public static void Insert<T>(string key, T v, bool forever = false, float survival = 10f)
    {
        CacheBase<T> cache = GetType<T>(key);
        if(cache!=null)
        {
            cache.Add(v, forever, survival);
        }
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    public static void Destory<T>(string key)
    {
        CacheBase<T> cache = GetType<T>(key);
        if (cache != null)
        {
            cache.Destroy();
        }
    }

    /// <summary>
    /// 获取
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public static T Get<T>(string key)
    {
        T t = default(T);
        CacheBase<T> cache = GetType<T>(key);
        if (cache != null)
        {
            t=cache.Get();
        }
        return t;
    }
}