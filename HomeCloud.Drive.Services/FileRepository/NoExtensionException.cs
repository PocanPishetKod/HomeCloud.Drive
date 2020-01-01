using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCloud.Drive.Services.FileRepository
{
    public class NoExtensionException : Exception
    {
        private const string _errorMessage = "Нельзя создать файл без расширения";
        public NoExtensionException() : base(_errorMessage) { }

        public NoExtensionException(string path) : base($"{_errorMessage}. Путь: {path}") { }
    }
}
