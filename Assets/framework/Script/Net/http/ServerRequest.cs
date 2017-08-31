/// <summary>
/// 服务数据请求
/// </summary>
public abstract class ServerRequest : NetRequest
{
    protected override EContianer contianerKey
    {
        get
        {
            return EContianer.ServerReq;
        }
    }
}