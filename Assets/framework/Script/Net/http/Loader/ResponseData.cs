using UnityEngine;

public class ResponseData
{
    public ResponseData(LoadBase load)
    {
        isWWW = load.isWWW;
        bytes = load.bytes;
        ab = load.ab;
        url = load.url;
        text = load.text;
        texture = load.texture;
        success = load.success;
        error = load.error;
    }

    /// <summary>
    /// 本地加载AB使用
    /// </summary>
    public ResponseData(string url, AssetBundle ab)
    {
        this.url = url;
        this.ab = ab;
        if (this.ab != null)
        {
            this.success = true;
            this.error = null;
        }
        else
        {
            this.success = false;
            this.error = "Assetbundle is null";
        }
        this.isWWW = false;
    }

    /// <summary>
    /// WWW加载使用，包括本地WWW加载其他使用、本地WWW加载AB使用、HTTP上WWW加载使用
    /// </summary>
    public ResponseData(string url, WWW www, bool isHttp)
    {
        this.url = url;
        this.isWWW = isHttp;
        if (www.error == null)
        {
            this.bytes = www.bytes;
            this.text = www.text;
            this.texture = www.texture;
            this.ab = www.assetBundle;

            this.success = true;
            this.error = null;
        }
        else
        {
            this.success = false;
            this.error = www.error;
        }
    }

    public bool isWWW { get; private set; }
    public byte[] bytes { get; private set; }
    public string url { get; private set; }
    public string text { get; private set; }
    public Texture texture { get; private set; }
    public AssetBundle ab { get; private set; }
    public bool success { get; private set; }
    public string error { get; private set; }

    private bool unloaded = false;
    private NativeTimer timer = null;

    public void UnLoad()
    {
        if (unloaded) { return; }
        if (timer != null) { return; }

        timer = new NativeTimer(OnUnload, 0.1f, false);
        timer.Start();
    }

    void OnUnload()
    {
        if (ab != null)
        {
            ab.Unload(false);
            ab = null;
        }
        error = null;
        bytes = null;
        url = null;
        text = null;
        texture = null;

        unloaded = true;
        timer.Stop();
        timer = null;
    }

    /// <summary>
    /// 该方法中不卸载AB包，只设置Null
    /// </summary>
    public void Clear()
    {
        ab = null;
        error = null;
        bytes = null;
        url = null;
        text = null;
        texture = null;
        unloaded = true;
        if (timer != null)
        {
            timer.Stop();
            timer = null;
        }
    }

}