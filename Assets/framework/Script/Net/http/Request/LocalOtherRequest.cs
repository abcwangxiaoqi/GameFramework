public class LocalOtherRequest : LocalRequest
{
    string url = "";
    public LocalOtherRequest(string _url)
    {
        url = _url;
    }
    protected override LoaderTask IniTask(LoaderContianer contianer)
    {
        LoaderTask task = new LoaderTask(contianer, LoadType.LocalOther, url);
        return task;
    }
}