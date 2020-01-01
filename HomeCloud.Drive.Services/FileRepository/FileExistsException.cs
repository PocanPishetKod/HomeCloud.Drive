using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCloud.Drive.Services.FileRepository
{
    public class FileExistsException : Exception
    {
        private const string _errorMessage = "Файл уже существует";

        public FileExistsException() : base(_errorMessage) { }

        public FileExistsException(string path) : base($"{_errorMessage}. Путь: {path}") { }
    }
}
