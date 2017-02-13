using System;
using System.Runtime.Caching;

/// <summary>
/// http://stackoverflow.com/questions/343899/how-to-cache-data-in-a-mvc-application
/// </summary>
namespace WebShop.Infrastructure.Cache
{
    /// <summary>
    /// cacheProvider.GetOrSet("cache key", (delegate method if cache is empty));
    /// var products=cacheService.GetOrSet("catalog.products", ()=>productRepository.GetAll())
    /// </summary>
    public class InMemoryCache : ICacheService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <returns></returns>
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = getItemCallback();
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(10));
            }
            return item;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback , int minutes) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = getItemCallback();
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(minutes));
            }
            return item;
        }


    }

    public interface ICacheService
    {
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class;
    }
}
