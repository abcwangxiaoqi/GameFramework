#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System;

public interface IPrefabItem:IObjectBase
{
    void CreatPrefab(UnityEngine.Object obj, CallBackWithParams<UnityEngine.GameObject, Dictionary<string, object>> callback = null, Dictionary<string, object> parameters = null);
}
#endif
