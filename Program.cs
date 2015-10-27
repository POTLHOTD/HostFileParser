using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HostFileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileToProcess = Console.ReadLine();

         
            var reg = new System.Text.RegularExpressions.Regex(@"\s+");
            var hostEntries = new List<HostEntry>();

            using (var reader = new HostFileReader(fileToProcess))
            {
               for(string line = reader.ReadLine(); !reader.EndOfStream; line = reader.ReadLine())
               {
                   if (reader.IgnoreLine) { continue; }

                   var parts = reg.Split(line.Trim());

                   var ip = parts[0].Trim();

                   //walk through each one
                   foreach(var d in parts.Skip(1).Where(x => !x.StartsWith("#") && x.Trim().Length > 0).Select(x => x.Trim()))
                   {
                       var entry = new HostEntry()
                       {
                           IP = ip,
                           Domain = d
                       };

                       //if (string.IsNullOrWhiteSpace(entry.Domain))
                       //{
                       //    Console.WriteLine("^%^ " + line);
                       //}

                       hostEntries.Add(entry);
                   }
               }
            }

            string directory = Path.GetDirectoryName(fileToProcess);
            string filePath = Path.Combine(directory, Path.GetRandomFileName());
            
            var stringBuilder = new StringBuilder();

            foreach(var hostEntry in hostEntries.OrderBy(x => x.IP).ThenBy(x => x.Domain))
            {
                stringBuilder.AppendFormat("{0}\t{1}", hostEntry.IP, hostEntry.Domain);
                stringBuilder.AppendLine();
            }

            File.WriteAllText(filePath, stringBuilder.ToString());

            //string directory2 = string.Concat(Path.GetDirectoryName(workbook.FullName), "\\", workbookName);
            System.Diagnostics.Process.Start("explorer.exe", directory);     

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
