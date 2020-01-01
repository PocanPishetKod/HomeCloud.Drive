using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCloud.Drive.Core.Entities
{
    /// <summary>
    /// Описывает файл, хранящийся в файловом репозитории
    /// </summary>
    public class FileDescriptor : BaseEntity
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Путь, по которому лежит файл в файловом репозитории
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Расширение файла
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Тип описываемого файла
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Идентификатор дескриптора дериктории, в которой находится этот файл
        /// </summary>
        public int? DirectoryDescriptorId { get; set; }

        /// <summary>
        /// Дескриптора дериктории, в которой находится этот файл
        /// </summary>
        public virtual DirectoryDescriptor DirectoryDescriptor { get; set; }
    }
}
