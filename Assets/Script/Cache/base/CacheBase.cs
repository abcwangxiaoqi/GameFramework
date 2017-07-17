
/*
 * 策略：
 * 内存永驻标示 引用标记为0 时 不做任何处理
 * 非永驻 引用标记为0 时 如果10秒内没有使用 则Remove原始数据
 */
using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
public class CacheBase<T>
{
    static Dictionary<Type, Dictionary<string, T>> cache = new Dictionary<Type, Dictionary<string, T>>();//缓存容器
    static Dictionary<Type, Dictionary<string, CacheItem>> cacheData = new Dictionary<Type, Dictionary<string, CacheItem>>();

    protected Type type = null;
    protected Dictionary<string, T> tempCache = null;
    protected Dictionary<string, CacheItem> tempCacheData = null;
    protected CacheItem item = null;
    protected T _t = default(T);
    protected string Key = "";

    public CacheBase(string key)
    {
        Key = key;
        type = typeof(T);

        #region cache
        if (cache.ContainsKey(type))
        {
            tempCache = cache[type];
        }
        else
        {
            tempCache = new Dictionary<string, T>();
            cache[type] = tempCache;
        }
        #endregion

        #region cacheData

        if (cacheData.ContainsKey(type))
        {
            tempCacheData = cacheData[type];
        }
        else
        {
            tempCacheData = new Dictionary<string, CacheItem>();
            cacheData[type] = tempCacheData;
        }

        #endregion

        if (tempCacheData.ContainsKey(key))
        {
            item = tempCacheData[key];
            _t = tempCache[key];
        }
    }

    public void Add(T t, bool forever, float survival)
    {
        if (item != null)
        {
            item.ResetTimer();//restart timer
           // Debug.Log("type=" + type.Name + ";Key=" + Key + ",exist key");
            return;
        }

        item = new CacheItem(Delete, forever, survival);
        _t = t;

        tempCache[Key] = _t;
        tempCacheData[Key] = item;
    }

    public void Destroy()
    {
        if (item == null)
            return;

        item.DeleteRefrence();
    }

    /// <summary>
    /// real delete data from cache
    /// </summary>
    void Delete()
    {
        item = null;
        unload();
        tempCacheData.Remove(Key);
        tempCache.Remove(Key);
    }

    /// <summary>
    /// free momery
    /// </summary>
    /// <param name="t"></param>
    protected virtual void unload()
    {
        _t = default(T);
    }

    public T Get()
    {
        if (item != null)
        {
            item.AddRefrence();
        }
        return _t;
    }
}