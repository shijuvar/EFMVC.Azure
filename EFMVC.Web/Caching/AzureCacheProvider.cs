using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationServer.Caching;

namespace EFMVC.Web.Caching
{
    public class  AzureCacheProvider : ICacheProvider
    {
        private DataCache dataCache=null;
        public AzureCacheProvider()
        {
            //Creating a cache object by using DataCacheFactory
            DataCacheFactory cacheFactory = new DataCacheFactory();
             dataCache = cacheFactory.GetDefaultCache();
        }
        //Get cached item
        public object Get(string key)
        {
           return dataCache.Get(key);
        }
        public void Add(string key, object data)
        {
            Add(key, data, null);
        }       
        public void Add(string key, object data, TimeSpan? timeout)
        {
           //Add item to Cache
            if (timeout.HasValue)
            {
                dataCache.Add(key, data, timeout.Value);
            }
            else
            {
                dataCache.Add(key, data);
            }
        }
        public void Put(string key, object data)
        {
            Put(key, data, null);
        }
        public void Put(string key, object data, TimeSpan? timeout)
        {
            //Put item to Cache
            if (timeout.HasValue)
            {
                dataCache.Put(key, data, timeout.Value);
            }
            else
            {
                dataCache.Put(key, data);
            }
        }
        //Returns true if Cache item is exist
        public bool IsSet(string key)
        {            
            return (dataCache.Get(key) != null);
        }
        public void Remove(string key)
        {
            dataCache.Remove(key);
        }
    }
}