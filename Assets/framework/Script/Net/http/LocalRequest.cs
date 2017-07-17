/// <summary>
/// 本地请求
/// </summary>
public abstract class LocalRequest : Request
{

    protected override string contianerKey
    {
        get
        {
            return ELoaderContianerKey.LOCALREQ;
        }
    }

    protected override int contianerReqNum
    {
        get
        {
            return 1;
        }
    }
}