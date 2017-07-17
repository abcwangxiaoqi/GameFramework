/// <summary>
/// 服务数据请求
/// </summary>
public abstract class ServerRequest : NetRequest
{
    protected override string contianerKey
    {
        get
        {
            return ELoaderContianerKey.SERVERREQ;
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