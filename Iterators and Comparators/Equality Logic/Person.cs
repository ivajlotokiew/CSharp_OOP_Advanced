using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Person))
            {
                return false;
            }

            var newObj = (Person)obj;

            var isEquals = this.Name.Equals(newObj.Name) && this.Age.Equals(newObj.Age);

            return isEquals;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age * 7;
        }

        public int CompareTo(Person other)
        {
            var isEqualName = this.Name.CompareTo(other.Name);

            if (isEqualName == 0)
            {
                var isEqualAge = this.Age.CompareTo(other.Age);

                return isEqualAge;
            }

            return isEqualName;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}