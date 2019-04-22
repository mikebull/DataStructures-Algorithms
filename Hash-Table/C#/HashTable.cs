using System.Collections.Generic;

namespace Hash_Tables
{
    /// <summary>
    /// CLass describing a hash table using linear probing.
    /// </summary>
    public class HashTable
    {
        private readonly int _size;
        private readonly Hash[] _hash;

        /// <summary>
        /// Initialises a new instance of the <see cref="HashTable"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public HashTable(int size = 10)
        {
            _size = size;
            _hash = new Hash[size];

            for (int i = 0; i < size; i++)
            {
                _hash[i] = new Hash();
            }
        }

        /// <summary>
        /// Adds the specified key and value to the hash table.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(int key, string value)
        {
            var hashedKey = GetHashFromKey(key);

            if (!Exists(key))
            {
                _hash[GetHashFromKey(key)] = new Hash(key, value);
                return;
            }

            var pointer = hashedKey != _size ? hashedKey + 1 : 0;
            
            while (pointer != hashedKey)
            {
                var item = _hash[pointer];

                if (item == null || string.IsNullOrEmpty(item.Value))
                {
                    _hash[pointer] = new Hash(key, value);
                    return;
                }

                if (pointer == hashedKey)
                {
                    pointer = 0;
                }
                else
                {
                    pointer++;
                }
            }
        }

        /// <summary>
        /// Check if an element exists in the underlying array.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool Exists(int key)
        {
            var hashedKey = GetHashFromKey(key);
            var item = _hash[GetHashFromKey(key)];

            return !string.IsNullOrEmpty(item.Value);
        }

        /// <summary>
        /// Gets the specified value by its key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string Get(int key)
        {
            var hashedKey = GetHashFromKey(key);

            if (!Exists(key))
            {
                return null;
            }

            Hash item = _hash[hashedKey];

            if (item.Key == key && !string.IsNullOrEmpty(item.Value))
            {
                return item.Value;
            }

            var pointer = hashedKey + 1;

            if (item.Key == key && !string.IsNullOrEmpty(item.Value))
            {
                return item.Value;
            }

            if (pointer == _size)
            {
                pointer = 0;
            }

            while (pointer != hashedKey)
            {
                item = _hash[pointer];

                if (item.Key == key && !string.IsNullOrEmpty(item.Value))
                {
                    return item.Value;
                }

                if (pointer == hashedKey)
                {
                    pointer = 0;
                }
                else
                {
                    pointer++;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the specified item by its key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(int key)
        {
            if (!Exists(key))
            {
                return;
            }

            _hash[GetHashFromKey(key)] = new Hash();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            List<string> items = new List<string>();

            foreach (var item in _hash)
            {
                items.Add($"({item.Key},{item.Value})");
            }

            return string.Join(", ", items);
        }


        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        private int GetHashFromKey(int key)
        {
            return key.GetHashCode() % _size;
        }
    }
}
