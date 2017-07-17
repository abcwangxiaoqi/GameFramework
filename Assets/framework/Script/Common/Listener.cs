
public abstract class Listener<T>
{
    protected CallBackWithParams<T> mCallback = null;

    /// <summary>
    /// 回调返回的数据都需要进行null判断
    /// </summary>
    public void AddListener(CallBackWithParams<T> _callback)
    {
        if (_callback != null)
        {
            mCallback += _callback;
        }
    }

    public void RemoveListener(CallBackWithParams<T> _callback)
    {
        if (_callback != null)
        {
            mCallback -= _callback;
        }
    }

    public void Callback(T t)
    {
        if (mCallback != null)
        {
            mCallback.Invoke(t);
        }
    }
}

public abstract class Listener<T, U>
{
    protected CallBackWithParams<T, U> mCallback = null;

    /// <summary>
    /// 回调返回的数据都需要进行null判断
    /// </summary>
    public void AddListener(CallBackWithParams<T, U> _callback)
    {
        if (_callback != null)
        {
            mCallback += _callback;
        }
    }

    public void RemoveListener(CallBackWithParams<T, U> _callback)
    {
        if (_callback != null)
        {
            mCallback -= _callback;
        }
    }

    public void Callback(T t, U u)
    {
        if (mCallback != null)
        {
            mCallback.Invoke(t, u);
        }
    }
}