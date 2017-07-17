public class LocalABRequest : LocalRequest
{
    string url = "";
    public LocalABRequest(string _url)
    {
        url = _url;
    }

    protected override LoaderTask IniTask(LoaderContianer contianer)
    {
        LoaderTask task = new LoaderTask(contianer, LoadType.LocalAB, url);
        return task;
    }
}