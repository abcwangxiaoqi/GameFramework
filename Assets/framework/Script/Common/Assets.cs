using UnityEngine;

public class Assets
{
    //注：所有目录的使用最后都会带“/”，使用时不需在前面添加

    static Assets()
    {
        //if (Application.platform == RuntimePlatform.Android)
        //{
        //    path = "jar:file://" + Application.dataPath + "!/assets/";
        //}
        //else if (Application.platform == RuntimePlatform.IPhonePlayer)
        //{
        //    path = Application.dataPath + "/Raw/";
        //}
        //else
        //{
        //    path = Application.dataPath + "/StreamingAssets/";
        //}

        // StreamingAssets Path
        StreamingAssetsPath = Application.streamingAssetsPath + "/";

        // StreamingAssets Url Path
        if (Application.platform == RuntimePlatform.Android)
        {
            StreamingAssetsUrlPath = StreamingAssetsPath;
        }
        else
        {
            StreamingAssetsUrlPath = "file:///" + StreamingAssetsPath;
        }

        //RuntimeAssets Path
        RuntimeAssetsPath = Application.persistentDataPath + "/";

        //AssetBundle Url Path
        RuntimeAssetsUrlPath = "file:///" + RuntimeAssetsPath;
    }


    /// <summary>
    /// 资源包目录，指StreamingAssets的路径
    /// </summary>
    public static string StreamingAssetsPath
    {
        get;
        private set;
    }

    /// <summary>
    /// 资源包目录，指StreamingAssets路径并能使用WWW加载
    /// </summary>
    public static string StreamingAssetsUrlPath
    {
        get;
        private set;
    }

    /// <summary>
    /// 运行时资源路径，资源拷贝和下载存放的路径，指Application.persistentDataPath路径
    /// </summary>
    public static string RuntimeAssetsPath
    {
        get;
        private set;
    }

    /// <summary>
    /// 运行时资源路径，资源拷贝和下载存放的路径，指Application.persistentDataPath路径，并能使用WWW加载
    /// </summary>
    /// <returns></returns>
    public static string RuntimeAssetsUrlPath
    {
        get;
        private set;
    }

}