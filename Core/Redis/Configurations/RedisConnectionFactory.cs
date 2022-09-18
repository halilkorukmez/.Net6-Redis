using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Core.Redis.Configurations;

public class RedisConnectionFactory : IRedisConnectionFactory
{
    private readonly Lazy<ConnectionMultiplexer> _connection;
    
    public RedisConnectionFactory(IConfiguration configuration)
    {
        _connection = new Lazy<ConnectionMultiplexer>(()=>ConnectionMultiplexer.Connect(configuration.GetSection("RedisHost").Value));
    }
    
    public ConnectionMultiplexer Connection()
    {
        return _connection.Value;
    }
}