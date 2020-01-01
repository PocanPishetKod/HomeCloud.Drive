using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCloud.Drive.Core.Entities
{
    /// <summary>
    /// Описывает директиву, хранящуюся в файловом репозитории
    /// </summary>
    public class DirectoryDescriptor : BaseEntity
    {
        /// <summary>
        /// Имя директории
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Путь, по которому лежит директория в файловом репозитории
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Идентификатор родительского дескриптора директории
        /// </summary>
        public int? ParentDirectoryDescryptorId { get; set; }

        /// <summary>
        /// Родительский дескриптор директории
        /// </summary>
        public virtual DirectoryDescriptor ParentDirectoryDescryptor { get; set; }

        /// <summary>
        /// Дескрипторы файлов, находящиеся в этой директории
        /// </summary>
        public virtual ICollection<FileDescriptor> FileDescriptors { get; set; }

        /// <summary>
        /// Дочернии дескрипторы директорий
        /// </summary>
        public virtual ICollection<DirectoryDescriptor> ChildDirectoryDescryptors { get; set; }
    }
}
