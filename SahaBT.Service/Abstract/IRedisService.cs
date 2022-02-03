using SahaBT.Shared.Concrete;
using System.Collections.Generic;

namespace SahaBT.Service.Abstract
{
    public interface IRedisService
    {
        List<Personal> GetAll(string cachekey);
        Personal GetById(int personId, string cachekey);
    }
}
