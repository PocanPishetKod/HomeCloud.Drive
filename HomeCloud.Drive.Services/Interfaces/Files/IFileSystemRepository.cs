using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HomeCloud.Drive.Services.Interfaces.Files
{
    public interface IFileSystemRepository
    {
        FileStream GetFileStream(string path);
        Task CreateFile(string path, Stream stream);
        void CreateDirectory(string path);
        void DeleteFileOrDirectory(string path);
    }
}
