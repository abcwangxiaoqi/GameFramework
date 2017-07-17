
using System;
public class CacheItem
{
    float survival = 10f;//非永驻 存货时间10s
    NativeTimer deleteTimer;//
    CallBack Delete = null;// unload acton
    bool forver = false;// is forver
    int refrence = 0;// refrence num

    public CacheItem(CallBack delete, bool _forver, float _survival)
    {
        Delete = delete;
        forver = _forver;

        if (_survival > 0)
        {
            survival = _survival;
        }

        if (!forver)
        {
            deleteTimer = new NativeTimer(Delete, survival, false);
            deleteTimer.Start();
        }
    }

    public void ResetTimer()
    {
        if (forver)
            return;
        deleteTimer.Start();
    }
    public void AddRefrence()
    {
        if (forver)
            return;
        refrence++;
        deleteTimer.Stop();
    }
    public void DeleteRefrence()
    {
        if (forver)
        {
            Delete();
        }
        else
        {
            if (refrence <= 0)
                return;

            refrence--;
            if (refrence == 0)
            {
                deleteTimer.Start();
            }
        }
    }
}
