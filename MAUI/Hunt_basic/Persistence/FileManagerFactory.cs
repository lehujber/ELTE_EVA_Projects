using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunt_basic.Persistence
{
    internal class FileManagerFactory
    {
        public static IFileManager? CreateForPath(string path) => Path.GetExtension(path) switch
        {
            ".hnt" => new TxtFileManager(path),
            _ => null
        };
    }
}
