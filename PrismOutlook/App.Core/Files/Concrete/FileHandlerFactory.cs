using App.Core.Files.Abstract;

namespace App.Core.Files.Concrete
{
    public static class FileHandlerFactory<T>
    {
        public static IReadWrite<T> CreateFileHandler(string formatstring)
        {
            IReadWrite<T> handle = null;

            switch (formatstring.ToLower())
            {
                case "json":
                    handle = new JsonReadWrite<T>();
                    break;

                case "xml":
                    handle = new XmlReadWrite<T>();
                    break;

                //case "csv":
                //    break;
                default:
                    throw new NotSupportedException("형식이 없습니다.");
            }

            return handle;
        }
    }
}
