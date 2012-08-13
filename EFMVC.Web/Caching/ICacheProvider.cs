using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFMVC.Web.Caching
{
    public interface ICacheProvider
    {
        object Get(string key);
        void Add(string key, object data);
        void Put(string key, object data);
        void Add(string key, object data, TimeSpan? timeout);
        void Put(string key, object data, TimeSpan? timeout);
        bool IsSet(string key);
        void Remove(string key);
    }
}