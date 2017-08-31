/// <summary>
/// 其他资源请求
/// </summary>
public class OtherRequest : ResRequest
{
    string name = "";
    public OtherRequest(string _name)
    {
        name = _name;
    }

    protected override LoaderTask IniTask(LoaderContianer contianer)
    {
        LoaderTask task = new LoaderTask(contianer, OutUri(name), null, header);
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