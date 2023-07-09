using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TestCode
{
    public class Member
    {

        public string StreeAddress, City,Name;
        public string Position, CompanyName;

        public override string ToString()
        {
            return $"{nameof(StreeAddress)}:{StreeAddress},{nameof(City)}:{City},{nameof(Name)}:{Name},{nameof(Position)}:{Position},{nameof(CompanyName)}:{CompanyName}";

        }

    }

    // 大 Builder 幫助我們實踐 fluent Faceted Builder
    public class MemberBuilder
    {

        // 善用 reference同一物件的特性
        protected Member Person = new Member();

        // faceted builder
        public PersonJobBuilder Works => new PersonJobBuilder(Person);
        public PersonAddressBuilder Info => new PersonAddressBuilder(Person);

        public static implicit operator Member(MemberBuilder bu)
        {
            return bu.Person;
        }
    }

    public class PersonJobBuilder:MemberBuilder
    {

        public PersonJobBuilder(Member person)
        {
            this.Person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            this.Person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            this.Person.Position = position;
            return this;
        }


    }

    public class PersonAddressBuilder : MemberBuilder
    {
        public PersonAddressBuilder(Member person)
        {
            this.Person = person;
        }


        public PersonAddressBuilder Call(string name)
        {
            this.Person.Name = name;
            return this;
        }

        public PersonAddressBuilder Live(string address)
        {
            this.Person.StreeAddress= address;
            return this;
        }
        public PersonAddressBuilder In(string city)
        {
            this.Person.City = city;
            return this;
        }



    }


}
