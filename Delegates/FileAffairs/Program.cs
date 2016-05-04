using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FileAffairs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Another important topic when it comes to dealing with input/output (I/O) is performance.
            //The new async keyword in C# can be used to easily implement asynchronous operations
            //that can improve usability and scalability of your application.
            DriveInfo[] drivesInfo = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in drivesInfo)
            {
                Console.WriteLine("Drive {0}", driveInfo.Name);
                Console.WriteLine(" File type: {0}", driveInfo.DriveType);
                if (driveInfo.IsReady == true)
                {
                    Console.WriteLine(" Volume label: {0}", driveInfo.VolumeLabel);
                    Console.WriteLine(" File system: {0}", driveInfo.DriveFormat);
                    Console.WriteLine(
                    " Available space to current user:{0, 15} bytes",
                    driveInfo.AvailableFreeSpace);
                    Console.WriteLine(
                    "Total available space: {0, 15} bytes",
                    driveInfo.TotalFreeSpace);
                    Console.WriteLine(
                    " Total size of drive: {0, 15} bytes ",
                    driveInfo.TotalSize);
                }
            }
            var directory = Directory.CreateDirectory(@"C:\Temp\ProgrammingInCSharp\Directory");
            var directoryInfo = new DirectoryInfo(@"C:\Temp\ProgrammingInCSharp\DirectoryInfo");
            directoryInfo.Create();

            if (Directory.Exists(@"C:\Temp\ProgrammingInCSharp\Directory"))
            {
                Directory.Delete(@"C:\Temp\ProgrammingInCSharp\Directory");
            }
            var directoryInfo1 = new DirectoryInfo(@"C:\Temp\ProgrammingInCSharp\DirectoryInfo");
            if (directoryInfo1.Exists)
            {
                directoryInfo1.Delete();
            }

            //Security
            DirectoryInfo directoryInfo2 = new DirectoryInfo("TestDirectory");
            directoryInfo2.Create();
            DirectorySecurity directorySecurity = directoryInfo2.GetAccessControl();
            directorySecurity.AddAccessRule(
            new FileSystemAccessRule("everyone",
            FileSystemRights.ReadAndExecute,
            AccessControlType.Allow));
            directoryInfo.SetAccessControl(directorySecurity);
        }
    }
}
