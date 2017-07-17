using System.Collections.Generic;
using UnityEngine;
public abstract class LoadBase
{
    protected SimpleTask task = null;
    public LoadBase(bool _isWWW)
    {
        success = true;
        isWWW = _isWWW;
    }

    public bool isWWW { get; private set; }
    public bool success { get; protected set; }
    public string error { get; protected set; }
    public AssetBundle ab { get; protected set; }
    public Texture texture { get; protected set; }
    public string text { get; protected set; }
    public byte[] bytes { get; protected set; }
    public string url { get; protected set; }


    abstract public SimpleTask Load();

    public virtual void Dispose()
    {
        if(task!=null)
        {
            task.Stop();
        }
    }
}