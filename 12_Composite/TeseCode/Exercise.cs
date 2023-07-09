using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MoreLinq;

namespace TeseCode
{

    public interface IValueContainer :IEnumerable<int>          
    {
        
    }
    public class SingleValue:IValueContainer
    {
        public int Value;
        public IEnumerator<int> GetEnumerator() // 把物件視為是 list 並且 去iterate 回逐步回傳在此定義內容
        {
            yield return Value;     
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class ManyValues : List<int>,IValueContainer
    {
        
    }
    public static class ExtensionMethods
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach (IValueContainer c in containers)
            {
                foreach (var i in c)
                {
                    result += i;
                }

            }
            return result;
        }
    }

}
