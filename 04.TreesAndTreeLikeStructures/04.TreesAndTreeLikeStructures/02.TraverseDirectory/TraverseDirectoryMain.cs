using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TraverseDirectoryMain
{
    static void Main()
    {
        string startFolder = @"D:\Games";

        Folder rootFolder = new Folder(startFolder);

        TraverseFolder(rootFolder);

        Console.WriteLine(rootFolder.CalculateFilesSize());
       
    }

    static void TraverseFolder(Folder folder)
    {
        DirectoryInfo dirInfo = new DirectoryInfo(folder.Name);

        foreach (FileInfo fileInfo in dirInfo.GetFiles())
        {
            var file = new File(fileInfo.Name, fileInfo.Length);
            folder.Files.Add(file);
        }

        foreach (DirectoryInfo directoryInfo in dirInfo.GetDirectories())
        {
            var dir = new Folder(directoryInfo.FullName);

            folder.ChildFolders.Add(dir);

            TraverseFolder(dir);
        }
    }
}