using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCloud.Drive.Services.Models
{
    public class DirectoryModel
    {
        private string _name;
        private int? _parentDirectoryDescryptorId;

        public DirectoryModel(string name, int? parentDirectoryDescryptorId)
        {
            Name = name;
            ParentDirectoryDescryptorId = parentDirectoryDescryptorId;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }

                _name = value;
            }
        }

        public int? ParentDirectoryDescryptorId
        {
            get
            {
                return _parentDirectoryDescryptorId;
            }
            set
            {
                if (value.HasValue && value < 0)
                {
                    throw new ArgumentNullException();
                }

                _parentDirectoryDescryptorId = value;
            }
        }
    }
}
