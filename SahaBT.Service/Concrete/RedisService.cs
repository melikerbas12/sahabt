using SahaBT.Service.Abstract;
using SahaBT.Shared.Concrete;
using ServiceStack.Redis;
using System.Collections.Generic;

namespace SahaBT.Service.Concrete
{
    public class RedisService : IRedisService
    {
        public List<Personal> GetAll(string cachekey)
        {
            using (IRedisClient client = new RedisClient())
            {
                List<Personal> dataList = new List<Personal>();
                List<string> allKeys = client.SearchKeys(cachekey);
                foreach (string key in allKeys)
                {
                    dataList.Add(client.Get<Personal>(key));
                }
                return dataList;
            }
        }

        public Personal GetById(int personId, string cachekey)
        {
            using (IRedisClient client = new RedisClient())
            {
                var redisdata = client.Get<Personal>(cachekey);

                return redisdata;
            }
        }
    }
}
