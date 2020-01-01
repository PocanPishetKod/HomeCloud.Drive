using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeCloud.Drive.Services.Models
{
    public class FileWithDataModel
    {
        private string _fileName;
        private Stream _stream;
        private string _contentType;
        private int? _directoryDescryptorId;

        public FileWithDataModel(string fileName, int? directoryDescryptorId, Stream stream, string contentType)
        {
            FileName = fileName;
            DirectoryDescryptorId = directoryDescryptorId;
            Stream = stream;
            ContentType = contentType;
        }

        public string FileName {
            get
            {
                return _fileName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }

                if (string.IsNullOrWhiteSpace(Path.GetExtension(value)))
                {
                    throw new ArgumentException();
                }

                _fileName = value;
            }
        }

        public int? DirectoryDescryptorId
        {
            get
            {
                return _directoryDescryptorId;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                _directoryDescryptorId = value;
            }
        }

        public Stream Stream
        {
            get
            {
                return _stream;
            }
            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentNullException();
                }

                _stream = value;
            }
        }

        public string ContentType
        {
            get
            {
                return _contentType;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }

                _contentType = value;
            }
        }
    }
}
