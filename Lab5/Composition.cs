using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Composition :IEquatable<Composition>
    {
        public string AuthorName { get; }
        public string Name { get; }

        public Composition(string AuthorName, string Name)
        {
            this.AuthorName = AuthorName;
            this.Name = Name;
        }

        public void Print()
        {
            Console.WriteLine(GetFullName());
        }

        public bool containsString(string str)
        {
            return GetFullName().Contains(str);
        }

        public string GetFullName()
        {
            return AuthorName + " - " + Name;
        }

        public bool Equals(Composition? other)
        {
            if (other == null) return false;
            return this.AuthorName == other.AuthorName && this.Name == other.Name;
        }
    }
}
