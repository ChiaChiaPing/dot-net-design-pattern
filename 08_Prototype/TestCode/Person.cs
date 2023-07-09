using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace TestCode
{

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                return (T)s.Deserialize(ms);
            }

        
        }
    }

    [Serializable]
    public class Person
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names ?? throw new ArgumentNullException(nameof(Names));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public override string ToString()
        {
            return $"{nameof(Names)}:{string.Join(" ", Names)}, {nameof(Address)}:{Address}";
        }

        public object Clone()
        {
            return new Person(Names, (Address)Address.Clone()); // 用現有的object資訊重新再建立一個，並且去改值
        }


        public Person(Person other)
        {
            Names = other.Names;
            Address = other.Address;

        }

        public Person()
        {

        }

      


    }

    [Serializable]
    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}:{StreetName}, {nameof(HouseNumber)}:{HouseNumber}";
        }

        // for implement ICclonable
        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }

        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public Address()
        {

        }


       
    }
}
