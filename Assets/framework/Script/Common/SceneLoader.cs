
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneLoader
{
    string _sceneName = "";
    public SceneLoader(string sceneName)
    {
        _sceneName = sceneName;
    }

    public bool isCurrent()
    {
        return SceneManager.GetActiveScene().name == _sceneName;
    }

    NativeTimer timer = null;
    AsyncOperation operation = null;
    CallBack callback = null;
    public void LoadAsync(CallBack cback=null)
    {
        callback = cback;
        if (string.IsNullOrEmpty(_sceneName))
            return;

        if (isCurrent())
        {
            Debug.LogError("加载场景为当前场景!!");
            return;
        }

        Resources.UnloadUnusedAssets();
        System.GC.Collect();

        operation = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Single);
        timer = new NativeTimer(UpdateLoadingUI, 0.01f, true);
        timer.Start();
    }

    public float progress { get; private set; }

    void UpdateLoadingUI()
    {
        #region 赋值UI进度条

        progress = (int)(operation.progress * 100);

        #endregion

        if (operation.isDone)
        {
            timer.Stop();
            timer = null;

            if(callback!=null)
            {
                callback();
            }
        }
    }

    public void Load()
    {
        if (string.IsNullOrEmpty(_sceneName))
            return;

        if (isCurrent())
            return;

        SceneManager.LoadScene(_sceneName);
    }
}
