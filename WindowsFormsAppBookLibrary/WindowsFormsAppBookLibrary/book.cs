using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppBookLibrary
{[Serializable]
    class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Declare { get; set; }
        public string Page { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
