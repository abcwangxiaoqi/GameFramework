using System.Collections.Generic;

public sealed class LoaderContianerConst
{
    static Dictionary<EContianer, int> Dic = new Dictionary<EContianer, int>()
    {
        {EContianer.LocalReq,2 },
        {EContianer.ServerReq,2 },
        {EContianer.ResGeoReq,2 },
        {EContianer.ResCharacterReq,3 },
        {EContianer.ResOtherReq,2 },
        {EContianer.ResBlockReq,2 },
         {EContianer.ResMuti,1 }
    };

    public static int getNum(EContianer key)
    {
        if (Dic.ContainsKey(key))
        {
            return Dic[key];
        }
        return 1;
    }
}

public enum EContianer
{
    LocalReq,
    ServerReq,
    ResGeoReq,
    ResCharacterReq,
    ResOtherReq,
    ResBlockReq,
    ResMuti
}
