using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.Move(@"C:\source", @"c:\destination");
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Source");
            directoryInfo.MoveTo(@"C:\destination");

            foreach (string file in Directory.GetFiles(@"C:\Windows"))
            {
                Console.WriteLine(file);
            }
            DirectoryInfo directoryInfo3 = new DirectoryInfo(@"C:\Windows");
            foreach (FileInfo fileInfo in directoryInfo3.GetFiles())
            {
                Console.WriteLine(fileInfo.FullName);
            }

            string path = @"c:\temp\test.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            FileInfo fileInfo1 = new FileInfo(path);
            if (fileInfo1.Exists)
            {
                fileInfo1.Delete();
            }

            string path1 = @"c:\temp\test.txt";
            string destPath = @"c:\temp\destTest.txt";
            File.CreateText(path).Close();
            File.Move(path1, destPath);
            FileInfo fileInfo2 = new FileInfo(path1);
            fileInfo2.MoveTo(destPath);


            string path3 = @"c:\temp\test.txt";
            string destPath2 = @"c:\temp\destTest.txt";
            File.CreateText(path3).Close();
            File.Copy(path3, destPath2);
            FileInfo fileInfo3 = new FileInfo(path3);
            fileInfo3.CopyTo(destPath2);

            Console.WriteLine(Path.GetDirectoryName(path)); // Displays C:\temp\subdir 
            Console.WriteLine(Path.GetExtension(path)); // Displays .txt
            Console.WriteLine(Path.GetFileName(path)); // Displays file.txt
            Console.WriteLine(Path.GetPathRoot(path)); // Displays C:\
        }

        private static void ListDirectories(DirectoryInfo directoryInfo,
            string searchPattern, int maxLevel, int currentLevel)
        {
            if (currentLevel >= maxLevel)
            {
                return;
            }
            string indent = new string('-', currentLevel);
            try
            {
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories(searchPattern);
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    Console.WriteLine(indent + subDirectory.Name);
                    ListDirectories(subDirectory, searchPattern, maxLevel, currentLevel + 1);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // You don’t have access to this folder.
                Console.WriteLine(indent + "’t access: " + directoryInfo.Name);
                return;
            }
            catch (DirectoryNotFoundException)
            {
                // The folder is removed while iterating
                Console.WriteLine(indent + "Can’t find: " + directoryInfo.Name);
                return;
            }
            DirectoryInfo directoryInfo1 = new DirectoryInfo(@"C:\Program Files");
            ListDirectories(directoryInfo1, "*a*", 5, 0);
        }
    }
}
