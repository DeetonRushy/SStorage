using SStorage;
using System.Text;

namespace SStorage.Utils
{
    public class HelperFactory
    {
        public static IStorage SStorageWithPath(string path) => new Storage(path);

        public static IStorage SStorage() => new Storage();

        public static IStorage SStorageDbg() => new Storage(true);

        public static IStorage SStorageWithPathDbg(string path) => new Storage(path, true);

        public static IStorage SStorageWithPathAndEncoding(string path, Encoding encoder) => new Storage(path, encoder);

        public static IStorage SStorageWithPathAndEncodingDbg(string path, Encoding encoder) => new Storage(path, encoder, true);
    }
}
