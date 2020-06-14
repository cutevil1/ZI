using System;
using System.Collections.Generic;
using System.Linq;
using BinarySearchTree;

namespace SignatureBase
{
    public class Signature : IComparable<Signature>
    {
	public string hashS; 
        public string name;
		public int lengthS; 
        public string prefixS;
        public int begin; 
		public int end; 
        private Dictionary<string, Signature> signature_dict = new Dictionary<string, Signature>();
        private Tree tree = new Tree();
        readonly Work_with_data wwd = new Work_with_data();
        public Signature() { } 

        private Signature(string name, int lengthS, string prefixS, string hashS, int begin, int end)
        {
            this.name = name;
            this.lengthS = lengthS;
            this.prefixS = prefixS;
            this.hashS = hashS;
            this.begin = begin;
            this.end = end;
        }
        public void LineSplit(string line)
        {
            string[] tt = line.Split(new char[] { ' ' });
            try
            {
                signature_dict.Add(tt[2], new Signature
                {
                    name = tt[0],
                    lengthS = Convert.ToInt16(tt[1]),
                    prefixS = tt[2],
                    hashS = tt[3],
                    begin = Convert.ToInt16(tt[4]),
                    end = Convert.ToInt16(tt[5])
                });
                tree.Add(tt[2]);
            }
            catch (Exception) { }
        }

        public void Load_all_line_in_base()
        {
            for (int i = 0; i < System.IO.File.ReadAllLines(wwd.path_to_db_file).Length; i++)
            {
                LineSplit(wwd.Read_from_file_one_line(i));
            }
        }


        private string Find_prefix(string region)
        {
            string find_signature = "";
            Node current = tree.Root;
            for (int i = 0; i < region.Length;)
            {
                if (current.Data.CompareTo(region[i]) == 0)
                {
                    find_signature += current.Data;
                    if (current.End) return find_signature;
                    i++;
                    current = current.Equal;
                }
                else
                {
                    if (region[i] < current.Data) current = current.Left;
                    else if (region[i] > current.Data) current = current.Right;
                }
                if (current == null) break;
            }
            return "";
        }

        public bool FindSignature(string tt)
        {
            string buffer = tt, to_hash_line = "";
            string wm_str = Find_prefix(tt);
            while (wm_str == "" && tt != "")
            {
                tt = tt.Substring(1);
                wm_str = Find_prefix(tt);
            }
            if (wm_str != "")
            {
                if (signature_dict.TryGetValue(wm_str, out var value))
                {
                    if (tt.Length >= value.lengthS)
                    {
                        for (int i = 0; i < value.lengthS; i++)
                            to_hash_line += tt[i];

                        Calculating_hash calc_hash = new Calculating_hash();
                        return calc_hash.Check_hash(to_hash_line, value.hashS);
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        public int CompareTo(Signature other)                                    
        {                                                                        
            return prefixS.CompareTo(other.prefixS);           
        }                                                                        
    }
}
