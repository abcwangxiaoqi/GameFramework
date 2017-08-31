﻿using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class Request
{
    LoaderContianer contianer = null;
    public Request()
    {
        contianer = CacheManager.Get<LoaderContianer>(contianerKey.ToString());
        if (contianer == null)
        {
            int num = LoaderContianerConst.getNum(contianerKey);
            if (num <= 0)
            {
                num = 1;
            }
            contianer = new LoaderContianer(num);
            CacheManager.Insert<LoaderContianer>(contianerKey.ToString(), contianer, true);
        }
    }

    CallBackWithParams<ResponseData> callback;
    public void AddListener(CallBackWithParams<ResponseData> _callback)
    {
        if (_callback != null)
        {
            callback += _callback;
        }
    }

    public void RemoveListener(CallBackWithParams<ResponseData> _callback)
    {
        if (_callback != null)
        {
            callback -= _callback;
        }
    }

    LoaderTask task = null;
    public void Connect()
    {
        task = IniTask(contianer);
        task.AddListener(LoadComplete);
        task.Start();
    }

    protected abstract LoaderTask IniTask(LoaderContianer contianer);

    protected virtual void LoadComplete(ResponseData data)
    {
        if (callback != null)
        {
            callback.Invoke(data);
        }
    }

    public void Stop()
    {
        task.Stop();
    }

    abstract protected EContianer contianerKey { get; }
}
