using System;
using System.Collections.Generic;

namespace ObjectPool
{
    public class SimplePool<T>
    {
        private readonly Func<T> _preloadFunc;
        private readonly Stack<T> _pool;
        private int _balance;

        public SimplePool(Func<T> loadFunc, int capacity = 0)
        {
            _preloadFunc = loadFunc;

            if (capacity <= 0)
            {
                _pool = new Stack<T>();
                return;
            }

            _pool = new Stack<T>(capacity);
            while (capacity-- > 0)
            {
                _pool.Push(_preloadFunc());
            }
        }

        public int Balance => _balance;

        public T Get()
        {
            _balance--;
            return _pool.Count > 0 ? _pool.Pop() : _preloadFunc();
        }

        public void Return(T obj)
        {
            _balance++;
            _pool.Push(obj);
        }
    }
}