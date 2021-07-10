using System;
using System.Collections.Generic;

namespace Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hashing");
            string sample = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            string[] splited = sample.ToLower().Split(' ');
            HashSet<string> set = new HashSet<string>();
            MyMapNode<string, int> myMapNode = new MyMapNode<string, int>(5);
            for (int i = 0; i < splited.Length; i++)
            {
                int count = myMapNode.CheckFreq(splited[i]);
                if (count > 1)
                {
                    myMapNode.Add(splited[i], count);
                    set.Add(splited[i]);
                }
                else
                {
                    myMapNode.Add(splited[i], 1);
                    set.Add(splited[i]);
                }

            }

            foreach(var member in set)
            {
                Console.WriteLine("The frequency of {0} in sentence is {1}",member,myMapNode.Get(member));
            }

        }
    }
}
