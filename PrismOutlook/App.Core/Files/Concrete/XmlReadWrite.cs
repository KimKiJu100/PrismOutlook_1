using App.Core.Files.Abstract;
using System.Xml.Serialization;

namespace App.Core.Files.Concrete
{
    public class XmlReadWrite<T> : IReadWrite<T>
    {
        private XmlSerializer serializer = new XmlSerializer(typeof(T));

        public T Read(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var result = (T)serializer.Deserialize(reader);
                return result;
            }
        }

        public void Write(T parameter, string filePath)
        {
            using (StreamWriter writer = new StreamWriter("person.xml"))
            {
                serializer.Serialize(writer, parameter);
            }
        }
    }
}
