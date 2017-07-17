using UnityEngine;

/// <summary>
/// 资源请求
/// </summary>
using System.Collections.Generic;
public abstract class ResRequest : NetRequest
{
    static string rooturi = "api/v1/resource/object";

    public static Dictionary<string, string> GetHeader()
    {
        return null;
    }

    public static string GetOutUri(string name)
    {
        return null;
    }

    protected Dictionary<string, string> header
    {
        get
        {
            return null;
        }
    }

    protected string OutUri(string name)
    {
        return GetOutUri(name);
    }
}