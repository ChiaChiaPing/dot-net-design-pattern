using System.Collections.Generic;
using System.IO;
using System;

namespace TestCode
{
    public class Jurnal
    {
        private readonly List<string> entries = new List<string>(); // readonly 代表的是不能被重新派值（指派物件位址），而不是不能新增/刪除 element
        private static int count = 0;

        public void AddEntry(string name)
        {
            entries.Add($"{++count} : {name}");
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries); // 很像是 python 的 str.join(",",arr)
        }
     


    }

    public class Persistence
    {

        // 就很像是 dependency 的關係 (Persistence and Jounal)
        public void Save(Jurnal j, string filename, bool overwrite = false)
        {
            if( overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename,j.ToString());
            }
        }
    }
}
