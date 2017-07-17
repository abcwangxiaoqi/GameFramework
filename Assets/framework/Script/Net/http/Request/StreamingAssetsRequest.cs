public class StreamingAssetsRequest : LocalRequest
{
    string url = "";
    public StreamingAssetsRequest(string _url)
    {
        url = _url;
    }
    protected override LoaderTask IniTask(LoaderContianer contianer)
    {
        LoaderTask task = new LoaderTask(contianer, LoadType.StreamAssets, url);
        return task;
    }
}