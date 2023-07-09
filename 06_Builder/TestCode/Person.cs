using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace TestCode
{
    public class Person
    {

        public string Name, Position;

        public class Builder : PersonJobBuilder<Builder> { }
        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}:{Name}, {nameof(Position)}:{Position}";
        }
    }


    public abstract class PersonBuilder
    {
        protected Person person = new Person();
        public Person Build => person; // properties
    }

    public class PersonInfoBuilder<SELF> : PersonBuilder where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this; // 這裡的 self 會變成 PersonJobBuilder<Builder>
        }

    }

    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>> where SELF : PersonJobBuilder<SELF>
    {

        public SELF WorkAs(string position)
        {
            person.Position = position;
            return (SELF)this;
        }

    }
    // 使得每一個回傳型別都是 最後的子類別。

}
