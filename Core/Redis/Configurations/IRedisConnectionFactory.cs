using StackExchange.Redis;

namespace Core.Redis.Configurations;

public interface IRedisConnectionFactory
{
    ConnectionMultiplexer Connection();
}