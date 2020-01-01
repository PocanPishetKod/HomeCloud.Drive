using HomeCloud.Drive.Services.Interfaces.Files;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HomeCloud.Drive.Services.FileRepository
{
    internal class FileSystemService : IFileSystemRepository
    {
        private const string _baseDirectory = @"C:\Games\Test\";

        /// <summary>
        /// Метод, определяющий файл по пути
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool IsFile(string path)
        {
            var extension = Path.GetExtension(path);
            return !string.IsNullOrWhiteSpace(extension);
        }

        /// <summary>
        /// Возвращает путь файла или директории в файловой системе
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetFullPath(string path)
        {
            return Path.Combine(_baseDirectory, path);
        }

        public async Task CreateFile(string path, Stream stream)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (stream == null || stream.Length == 0)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var fullPath = GetFullPath(path);

            if (!IsFile(path))
            {
                throw new NoExtensionException(path);
            }

            try
            {
                using (var fileStream = new FileStream(fullPath, FileMode.CreateNew))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw;
            }
            catch (IOException)
            {
                throw new FileExistsException(path);
            }
        }

        public void CreateDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var fullPath = GetFullPath(path);

            var directoryInfo = new DirectoryInfo(fullPath);
            if (directoryInfo.Exists)
            {
                throw new DirectoryExistsException(path);
            }

            directoryInfo.Create();
        }

        public void DeleteFileOrDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var fullPath = GetFullPath(path);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            else if (Directory.Exists(fullPath))
            {
                Directory.Delete(fullPath, true);
            }
            else
            {
                throw new IOException();
            }
        }

        public FileStream GetFileStream(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var fullPath = GetFullPath(path);
            return new FileStream(fullPath, FileMode.Open);
        }
    }
}
