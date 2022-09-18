using Core.Redis.Configurations;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Core.Redis.Cache;

public class CacheService : ICacheService
{
    private readonly IRedisConnectionFactory _connection;
    private readonly IDatabase _database;
    private readonly IConfiguration _configuration;
    public CacheService(IRedisConnectionFactory connection,IConfiguration configuration)
    {
        _configuration = configuration;
        _connection = connection;
        _database = _connection.Connection().GetDatabase(Convert.ToInt32(_configuration.GetSection("RedisDb").Value));
    }
    public async Task<T> Get<T>(string key)
    {
        if (Any(key))
            return JsonConvert.DeserializeObject<T>(Convert.ToString(await _database.StringGetAsync(key)));
        return default;
    }

    public async Task<bool> AddOrUpdate(string key, object data)
    {
        return await _database.StringSetAsync(key,Convert.ToString(JsonConvert.SerializeObject(data)));
    }

    public async Task<bool> Remove(string key)
    {
        if (Any(key))
           return await _database.KeyDeleteAsync(key);
        return false;
    }

    public void  Clear()
    { 
        _database.Multiplexer.GetServer(_configuration.GetSection("RedisCacheUrl").Value).FlushDatabase();
    }

    public bool Any(string key)
    {
        return _database.KeyExists(key);
    }
}