using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCloud.Drive.Services.FileRepository
{
    public class DirectoryExistsException : Exception
    {
        private const string _errorMessage = "Такая директория уже сущестивует";

        public DirectoryExistsException() : base(_errorMessage) { }

        public DirectoryExistsException(string path) : base($"{_errorMessage}. Путь: {path}") { }
    }
}
