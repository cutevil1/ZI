using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    public class Tree
    {
        public Node Root { get; set; }
        public int Count { get; set; }

        public void Add(string prefix)
        {

            if (Root == null)
            {
                Root = new Node(prefix[0]);
                Root.Add(prefix);
            }
            else
            {
                Root.Add(prefix);
            }
            Count++;
        }
    }
}
