namespace App.Core.Files.Abstract
{
    public interface IReadWrite<T>
    {
        T Read(string filePath);
        void Write(T parameter, string filePath);
    }
}
