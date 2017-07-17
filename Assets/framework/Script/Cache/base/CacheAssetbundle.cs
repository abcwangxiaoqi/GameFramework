using UnityEngine;
using System.Collections;

public class CacheAssetbundle : CacheBase<AssetBundle>
{
    public CacheAssetbundle(string key) : base(key) { }
    protected override void unload()
    {
        _t.Unload(false);
        base.unload();
    }
}
