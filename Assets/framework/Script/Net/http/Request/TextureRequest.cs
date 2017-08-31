/// <summary>
/// 其他资源请求
/// </summary>
public class TextureRequest : ResRequest
{
    string path = "";
    public TextureRequest(string _path)
    {
        path = _path;
    }

    protected override LoaderTask IniTask(LoaderContianer contianer)
    {
        LoaderTask task = new LoaderTask(contianer, path, null, new System.Collections.Generic.Dictionary<string, string>());
        return task;
    }

    protected override EContianer contianerKey
    {
        get 
        {
            return EContianer.ResOtherReq;
        }
    }
}