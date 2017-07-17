#if UNITY_EDITOR
public interface IObjectBase : IAssetData, IImport
{
    string Name { get; }
    string Type { get; }
}
#endif