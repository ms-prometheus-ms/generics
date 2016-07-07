using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrometheusIntro
{
    class Program2
    {
        static void Main2(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var dic = new UaDictionary<string, long>();

            dic.MyAdd("колискова", 2);
            dic.MyAdd("кобзар", 1);

            foreach (var keyValue in dic)
            {
                Console.WriteLine(keyValue.Key + " -> " + keyValue.Value.ToString());
            }
        }
    }

    class UaDictionary<TKey, TValue, T> : Dictionary<TKey, TValue>
        where TKey : class
        where TValue : new()
        where T : IEnumerable<TKey>
    {
        //https://msdn.microsoft.com/en-us/library/twcad0zb.aspx
        //
        static public void SwapIfGreater<T>(ref T lhs, ref T rhs)
            where T : IComparable<T>
        {
            T temp;

            if (lhs.CompareTo(rhs) > 0)
            {
                temp = lhs;
                lhs = rhs;
                rhs = temp;
            }
        }

        public T _examples { get; set; }
        public UaDictionary(IList<TKey> _input)
        {
            _examples = (T)_input;
        }

        public void Greeting()
        {
            Console.WriteLine("Hey, UaDictionary!");
            foreach (var word in _examples)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
        }

        public void MyAdd(TKey word, TValue value)
        {
            if (word != null)
                this.Add(word, default(TValue));
        }



    }
}
