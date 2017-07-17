using UnityEngine;
using System.Collections;
using System.IO;

public class CameraScreetShot
{
    string rootFold = "screenshot";
    SimpleTask task = null;
    CallBack callback = null;
    public void Shot(string filename,CallBack call=null)
    {
        callback = call;
        string fold = string.Format("{0}/{1}", Application.persistentDataPath, rootFold);

        if(!Directory.Exists(fold))
        {
            Directory.CreateDirectory(fold);
        }

        string shotPath = string.Format("{0}/{1}/{2}", Application.persistentDataPath, rootFold, filename);

        if (File.Exists(shotPath))
        {
            File.Delete(shotPath);
        }

        string pngPath = shotPath;
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            shotPath = string.Format("{0}/{1}", rootFold, filename);
        }
        Application.CaptureScreenshot(shotPath);
        task = new SimpleTask(ShotComplete(pngPath));
    }

    IEnumerator ShotComplete(string path)
    {
        while(!File.Exists(path))
        {
            yield return 1;
        }
        task = null;
        if(callback!=null)
        {
            callback();
        }
    }
}
