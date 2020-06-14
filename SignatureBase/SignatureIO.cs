using System;
using System.Collections.Generic;
using System.Linq;
using BinarySearchTree;

namespace SignatureBase
{
    public class Signature : IComparable<Signature>
    {
	public string signature_hash; 
        public string name;
	public int offset_end; 
        public int signature_length; 
        public string signature_prefix;
        public int offset_begin; 
        private Dictionary<string, Signature> signature_dict = new Dictionary<string, Signature>(); //словарь для хранения Ключа-Префикса и Значения-Экземпляра класса
        private Tree tree = new Tree();
        readonly Work_with_data wwd = new Work_with_data();
        public Signature() { } 

        private Signature(string name, int signature_length, string signature_prefix, string signature_hash, int offset_begin, int offset_end)
        {
            this.name = name;
            this.signature_length = signature_length;
            this.signature_prefix = signature_prefix;
            this.signature_hash = signature_hash;
            this.offset_begin = offset_begin;
            this.offset_end = offset_end;

        }
        public void LineSplit(string line)
        {
            string[] tmp = line.Split(new char[] { ' ' });
            try
            {
                signature_dict.Add(tmp[2], new Signature
                {
                    name = tmp[0],
                    signature_length = Convert.ToInt16(tmp[1]),
                    signature_prefix = tmp[2],
                    signature_hash = tmp[3],
                    offset_begin = Convert.ToInt16(tmp[4]),
                    offset_end = Convert.ToInt16(tmp[5])
                });
                tree.Add(tmp[2]);
            }
            catch (Exception) { }
        }

        //загрузка всех записей из файла в список
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
                    if (current.End)
                        return find_signature;
                    i++;
                    current = current.Equal;
                }
                else
                {
                    if (region[i] < current.Data)
                        current = current.Left;
                    else
                        if (region[i] > current.Data)
                        current = current.Right;
                }
                if (current == null)
                    break;
            }
            return "";
        }

        public bool FindSignature(string tmp)
        {
            string buffer = tmp, to_hash_line = "";
            string wm_str = Find_prefix(tmp);
            while (wm_str == "" && tmp != "")
            {
                tmp = tmp.Substring(1);
                wm_str = Find_prefix(tmp);
            }
            if (wm_str != "") //добавить сверку хэша найденного фрагмента и сигнатуры
            {
                if (signature_dict.TryGetValue(wm_str, out var value))
                {
                    if (tmp.Length >= value.signature_length)
                    {
                        for (int i = 0; i < value.signature_length; i++)
                            to_hash_line += tmp[i];

                        Calculating_hash calc_hash = new Calculating_hash();
                        return calc_hash.Check_hash(to_hash_line, value.signature_hash);
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }


        public int CompareTo(Signature other)                                    
        {                                                                        
            return signature_prefix.CompareTo(other.signature_prefix);           
        }                                                                        
    }
}
