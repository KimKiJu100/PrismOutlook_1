using App.Core.Files.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Files
{
    public class FileManager
    {
        public FileManager()
        {
        }

        public void Serialize<T>(string typeName, string path, T tData)
        {
            var handle = FileHandlerFactory<T>.CreateFileHandler(typeName);
            handle.Write(tData, path);
        }

        public T Deserialize<T>(string typeName, string path)
        {
            var handle = FileHandlerFactory<T>.CreateFileHandler(typeName);
            var result = handle.Read(path);
            return result;
        }
    }
}
