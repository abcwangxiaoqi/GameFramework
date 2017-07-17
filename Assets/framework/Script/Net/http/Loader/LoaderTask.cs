using System;
using System.Collections.Generic;
using UnityEngine;
public class LoaderTask
{
    LoaderContianer contianer = null;
    public string ID { get; private set; }
    public LoadType type { get; private set; }
    public string url { get; private set; }
    public WWWForm wform { get; private set; }
    public byte[] postdata { get; private set; }
    public Dictionary<string, string> header { get; private set; }

    public LoaderTask(LoaderContianer _contianer, LoadType _type, string _url)
    {
        contianer = _contianer;
        ID = Guid.NewGuid().ToString();
        type = _type;
        url = _url;
    }

    public LoaderTask(LoaderContianer _contianer, string _url, WWWForm _wform)
    {
        contianer = _contianer;
        ID = Guid.NewGuid().ToString();
        type = LoadType.Post;
        url = _url;
        wform = _wform;
    }

    public LoaderTask(LoaderContianer _contianer, string _url, byte[] _postdata, Dictionary<string, string> _header)
    {
        contianer = _contianer;
        ID = Guid.NewGuid().ToString();
        type = LoadType.PostWithHeader;
        url = _url;
        postdata = _postdata;
        header = _header;
    }

    public void Start()
    {
        contianer.InsertTask(this);
    }

    public void Stop()
    {
        contianer.DeleteTask(this);
    }

    CallBackWithParams<ResponseData> Callback = null;
    public void AddListener(CallBackWithParams<ResponseData> call)
    {
        Callback += call;
    }

    public void SetResponseData(ResponseData data)
    {
        if (Callback != null)
        {
            Callback(data);
        }
    }
}
public enum LoadType
{
    Get,
    Post,
    PostWithHeader,
    LocalAB,
    LocalOther,
    StreamAssets,
}
