using App.Core.Files.Abstract;
using System.Text.Json;

namespace App.Core.Files.Concrete
{
    public class JsonReadWrite<T> : IReadWrite<T>
    {
        // JSON 파일 읽기
        public T Read(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                throw new FileNotFoundException("The file does not exist.", filePath);
            }

            string jsonString = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        // JSON 파일 쓰기
        public void Write(T parameter, string filePath)
        {
            string jsonString = JsonSerializer.Serialize(parameter);
            System.IO.File.WriteAllText(filePath, jsonString);
        }
    }
}
