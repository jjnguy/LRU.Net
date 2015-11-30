using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRU.Net
{
    public class LruCache<TKey, TValue> where TValue : class
    {
        private readonly int _maxObjects;
        private OrderedDictionary _data;

        public LruCache(int maxObjects = 1000)
        {
            _maxObjects = maxObjects;
            _data = new OrderedDictionary();
        }

        public void Add(TKey key, TValue value)
        {
            if (_data.Count >= _maxObjects)
            {
                _data.RemoveAt(_data.Count - 1);
            }
            _data.Add(key, value);
        }

        public TValue Get(TKey key)
        {
            if (!_data.Contains(key)) return null;
            var result = _data[key];
            _data.Add(key, result);
            return (TValue)result;
        }
    }
}
