public interface IPooledObject
{
    void OnGetFromPool();
    void OnReturnToPool();
}
