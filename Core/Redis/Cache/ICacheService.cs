namespace Core.Redis.Cache;

public interface ICacheService
{
    Task<T> Get<T>(string key);
    Task<bool> AddOrUpdate(string key,object data);
    Task<bool> Remove(string key);
    void Clear();
    bool Any(string key);
}