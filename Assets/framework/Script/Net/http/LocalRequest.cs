/// <summary>
/// 本地请求
/// </summary>
public abstract class LocalRequest : Request
{

    protected override EContianer contianerKey
    {
        get
        {
            return EContianer.LocalReq;
        }
    }
}