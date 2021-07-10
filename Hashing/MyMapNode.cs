using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    //structure
    public struct KeyValue<K, V>
    {
        public K Key { set; get; }
        public V Value { set; get; }
    }
    class MyMapNode<K,V>
    {
        int size;
        LinkedList<KeyValue<K, V>>[] items;
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];

        }
        public int GetBucketValue(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        public LinkedList<KeyValue<K,V>> GetLinkedListPosition(int position)
        {
            LinkedList<KeyValue<K, V>> linkedlist = items[position];
            if(linkedlist == null)
            {
                linkedlist = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedlist;
            }
            return linkedlist;
        }
        public int CheckFreq(K key)
        {
            int position = GetBucketValue(key);
            LinkedList<KeyValue<K, V>> list = GetLinkedListPosition(position);
            int count = 1;
            bool alreadyfound = false;
            KeyValue<K, V> alreadyfoundKey = default(KeyValue<K,V>);
            foreach (KeyValue<K, V> keyValue in list)
            {
                if (keyValue.Key.Equals(key))
                {
                    count = Convert.ToInt32(keyValue.Value) + 1;
                    alreadyfound = true;
                    alreadyfoundKey = keyValue;
                }
            }
            if (alreadyfound)
            {
                list.Remove(alreadyfoundKey);
                return count;
            }
            else
            {
                return 1;
            }

        

    }
        public void Add(K key, V value)
        {
            int position = GetBucketValue(key);
            LinkedList<KeyValue<K, V>> list = GetLinkedListPosition(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key,Value=value};
            list.AddLast(item);

        }
        public V Get(K key)
        {
            int position = GetBucketValue(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedListPosition(position);
            foreach(KeyValue<K,V> keyValue in linkedlist)
            {
                if(keyValue.Key.Equals(key))
                {

                    return keyValue.Value;
                }
            }
            return default(V);
        }


    }

    
}
