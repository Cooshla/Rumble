using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameApp
{
    class Program
    {
        private static string NameToReplace { get; set; }
        private static string NameToUse { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("App name to replace?");
            NameToReplace = Console.ReadLine();

            Console.WriteLine("App name to use?");
            NameToUse = Console.ReadLine();
            Sanatize(System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName);

        }
        private static void Sanatize(string _folder)
        {
            // Process files in the directory
            string[] files = Directory.GetFiles(_folder);
            foreach (string fileName in files)
            {
                Rename(fileName);
            }
            string[] folders = Directory.GetDirectories(_folder);
            foreach (string folderName in folders)
            {
                Sanatize(folderName);
            }
        }

        private static void Rename(string fileName)
        {
            string text = File.ReadAllText(fileName);
            text = text.Replace(NameToReplace, NameToUse);
            File.WriteAllText(fileName, text);
        }
    }
}
