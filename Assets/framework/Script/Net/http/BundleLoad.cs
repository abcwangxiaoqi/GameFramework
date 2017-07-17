using UnityEngine;
using System.Collections;

public class BundleLoad
{
    string url = "";
    public BundleLoad(string _url)
    {
        url = _url;
    }

    public AssetBundle Load()
    {
        Debug.Log("BundleLoad:" + url);
        AssetBundle ab= AssetBundle.LoadFromFile(url);
        return ab;
    }
}

public class BundleLoadAsync:LoadBase
{
    public BundleLoadAsync(string _url):base(false)
    {
        url = _url;        
    }
    public override SimpleTask Load()
    {
        task = new SimpleTask(load());
        return task;
    }

    IEnumerator load()
    {
        AssetBundleCreateRequest abcr = AssetBundle.LoadFromFileAsync(url);
        yield return abcr;
        Debug.Log("BundleLoadAsync:" + url);
        ab = abcr.assetBundle;
        if(ab==null)
        {
            success = false;
            error = "assetbundle is null";
        }
    }
}

