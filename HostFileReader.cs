using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostFileParser
{
    public class HostFileReader : StreamReader
    {
        public HostFileReader(string file)
            : base(file)
        { }

        private string _currentLine;
        public string Line
        {
            get
            {
                return _currentLine;
            }
        }

        public bool IgnoreLine
        {
            get { return this.Line.StartsWith("#") || string.IsNullOrWhiteSpace(this.Line); }
        }

        /// <summary>
        /// Reads a line of characters from the current stream and returns the data as a string.
        /// </summary>
        /// <returns>
        /// The next line from the input stream, or null if the end of the input stream is reached.
        /// </returns>
        public override string ReadLine()
        {
            _currentLine = base.ReadLine();

            return _currentLine;
        }
    }
}
