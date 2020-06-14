using System;
using System.ComponentModel;
using System.Data;

namespace BinarySearchTree
{
    public class Node
    {
		public Node L1 { get; set; }
        public Node R1 { get; set; }
        public Node Same { get; set; }


        public bool End;
		public char Data { get; set; }
        public Node(char data)
        {
            Data = data;
        }

        public Node(char data, Node L1, Node R1, Node Same, bool end)
        {
            Data = data;
            L1 = L1;
            R1 = R1;
            Same = Same;
            End = end;
        }

        public void Add(string pr)
        {
			int keyC;
            Node nodeC = this;
            for (int i = 0; i < pr.Length; i++)
            {
                keyC = pr[i].CompareTo(nodeC.Data);
                if (keyC == 0) {
                    if (i == pr.Length - 1) { nodeC.End = true; return; }
                    if (nodeC.Same == null) nodeC.Same = new Node(pr[i + 1]);
                    nodeC = nodeC.Same;
                }
                else
                {
                    if (keyC < 0) {
                        if (nodeC.L1 == null) nodeC.L1 = new Node(pr[i]);
                        nodeC = nodeC.L1;
                        i--;
                    }
                    else {
                        if (nodeC.R1 == null) nodeC.R1 = new Node(pr[i]);
                        nodeC = nodeC.R1;
                        i--;
                    }

                    if (i == pr.Length - 1) { nodeC.End = true; return; }
                }
            }
        }
    }
}