using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Folder
{
    public Folder(string name, File[] files = null, Folder[] childFolders = null)
    {
        this.Name = name;
        this.Files = new List<File>();
        this.ChildFolders = new List<Folder>();
    }

    public string Name { get; set; }
    public IList<Folder> ChildFolders { get; set; }
    public IList<File> Files { get; set; }

    public long CalculateFilesSize()
    {
        long sizeInBytes = 0;

        foreach (var file in this.Files)
        {
            sizeInBytes += file.Size;
        }

        return sizeInBytes;
    }
}