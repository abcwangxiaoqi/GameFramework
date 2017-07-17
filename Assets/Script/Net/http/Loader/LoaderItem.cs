using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoaderItem
{
    public enum State
    {
        Idle,//空闲
        Busy,//忙碌
    }

    State state = State.Idle;

    public bool isIdle
    {
        get
        {
            return state == State.Idle;
        }
    }

    public ResponseData reponseData { get; private set; }
    SimpleTask currentTask = null;
    CallBackWithParams<LoaderItem> idleCallback = null;
    public void AddListenerIdle(CallBackWithParams<LoaderItem> callback)
    {
        if (callback != null)
        {
            idleCallback += callback;
        }
    }

    public void Dispose()
    {
        if (currentTask != null)
        {
            currentTask.Stop();
            currentTask = null;
        }

        currentLoaderTask = null;
        DisposeLoader();
        state = State.Idle;
    }
    public LoaderTask currentLoaderTask { get; private set; }
    public void InsertTask(LoaderTask task)
    {
        currentLoaderTask = task;
        reponseData = null;
        state = State.Busy;
        currentTask = new SimpleTask(request());
    }

    LoadBase targetLoad = null;

    void DisposeLoader()
    {
        if (targetLoad != null)
        {
            targetLoad.Dispose();
            targetLoad = null;
        }
    }

    IEnumerator request()
    {
        if (currentLoaderTask.type == LoadType.Get || currentLoaderTask.type == LoadType.LocalOther)
        {
            targetLoad = new HttpLoad(currentLoaderTask.url, false);
        }
        else if (currentLoaderTask.type == LoadType.LocalAB)
        {
            targetLoad = new BundleLoadAsync(currentLoaderTask.url);
        }
        else if (currentLoaderTask.type == LoadType.StreamAssets)
        {
            targetLoad = new HttpLoad(currentLoaderTask.url, "");
        }
        else if (currentLoaderTask.type == LoadType.Post)
        {
            targetLoad = new HttpLoad(currentLoaderTask.url, currentLoaderTask.wform);
        }
        else if (currentLoaderTask.type == LoadType.PostWithHeader)
        {
            targetLoad = new HttpLoad(currentLoaderTask.url, currentLoaderTask.postdata, currentLoaderTask.header);
        }
        //HgqTest.AddUrlDown(currentLoaderTask.url);
        yield return targetLoad.Load().coroutine;
        //HgqTest.EndUrlDown(currentLoaderTask.url);

        reponseData = new ResponseData(targetLoad);
        currentLoaderTask.SetResponseData(reponseData);
        idleCallback(this);
        //targetLoad.Dispose();

        state = State.Idle;
    }
}