using StackExchange.Redis;

using (var connection = await ConnectionMultiplexer.ConnectAsync(redisConnectionString))
{
    var cache = connection.GetDatabase();
    var key = "keyName";

    var value = await cache.StringGetAsync(key);
    Console.WriteLine($"{key} BEFORE set: {value}");

    var result = await cache.StringSetAsync(key, "value");

    value = await cache.StringGetAsync(key);
    Console.WriteLine($"{key} AFTER set: {value}");
}
