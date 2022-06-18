using System.Xml.Serialization;
using System.IO;

namespace SimBT_Deneme
{
    class SaveXML
    {
        public static void SaveData(Employee obj, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, obj);
            writer.Close();
        }
    }
}
