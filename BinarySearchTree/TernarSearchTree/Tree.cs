using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    public class Tree
    {
		public int Num { get; set; }
        public Node Uroo { get; set; }

        public void Add(string pr)
        {

            if (Uroo == null) { Uroo = new Node(pr[0]); Uroo.Add(pr); }
            else { Uroo.Add(pr); }
            Num++;
        }
    }
}
