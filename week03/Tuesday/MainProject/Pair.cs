using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    public class Pair<K,V>
    {
        private readonly K key;
        private readonly V value;

        public K Key
        {
            get { return key; }
        }

        public V Value
        {
            get { return value; }
        }

        public Pair(K key, V value)
        {
            this.key = key;
            this.value = value;
        }

        public static bool operator ==(Pair<K, V> pair, Pair<K, V> pair2)
        {
            return pair.Equals(pair2);
        }

        public static bool operator !=(Pair<K, V> pair, Pair<K, V> pair2)
        {
            return !pair.Equals(pair2);
        }

        public override bool Equals(object obj)
        {
            return key.Equals((obj as Pair<K, V>).Key) && value.Equals((obj as Pair<K, V>).Value);
        }

        public override string ToString()
        {
            return String.Format(@"[{0} : {1}]", key.ToString(), value.ToString());
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + key.GetHashCode();
                hash = hash * 23 + value.GetHashCode();
                return hash;
            }
        }
    }
}
