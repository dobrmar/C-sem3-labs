using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    [DataContract]
    public class Composition :IEquatable<Composition>
    {
        [DataMember]
        public string AuthorName { get; internal set; }
        [DataMember]
        public string Name { get; internal set; }

        private Composition() { AuthorName = "1"; Name = "1"; }

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

        private string GetFullName()
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
