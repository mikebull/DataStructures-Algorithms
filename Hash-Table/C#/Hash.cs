namespace Hash_Tables
{
    /// <summary>
    /// Class describing the individual item of a hash table
    /// </summary>
    public class Hash
    {
        /// <summary>
        /// The key
        /// </summary>
        public int Key;

        /// <summary>
        /// The value
        /// </summary>
        public string Value;

        /// <summary>
        /// Initialises a new instance of the <see cref="Hash"/> class.
        /// </summary>
        public Hash()
        {
            Key = -1;
            Value = null;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="Hash"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public Hash(int key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
