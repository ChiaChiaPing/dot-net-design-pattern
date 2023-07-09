using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace TestCode
{
    

    public class Person
    {
        public string name;
        //public DateTime DateofBirthday;
    }

    public enum Relationship
    {
        Parent,Child,Sibling
    }

    // 
    public interface IRelationship
    {
        IEnumerable<Person> FindChildFromName(string name);
    }
    

    public class Relationships : IRelationship
    {

        public List<(Person,Relationship,Person)> relation = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person p1, Person p2)
        {
            relation.Add((p1, Relationship.Parent, p2));
            relation.Add((p2, Relationship.Child, p1));
        }

        //  使得 name 所附屬的方法抽象畫起來（可以用抽象類別或是介面實作，讓大家可以根據自己需求去實踐，提升程式開發上的彈性）
        public IEnumerable<Person> FindChildFromName(string name)
        {
            // LIKE PYTHON's Filters
            foreach(var x in relation.Where(x=> x.Item1.name==name && x.Item2 == Relationship.Parent))
            {
                yield return x.Item3;  
            }
        }

    }






}
