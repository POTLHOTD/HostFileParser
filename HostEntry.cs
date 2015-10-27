using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostFileParser
{
    public class HostEntry
    {
        public HostEntry()
        {
            Domains = new HashSet<string>();
        }

        public string IP { get; set; }

        public string Domain { get; set; }

        public HashSet<string> Domains { get; set; }
    }
}
