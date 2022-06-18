using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Windows;

namespace SimBT_Deneme
{
    class SaveXML
    {
        public static void SaveData(List<Employee> objs, string filename)
        {
            if (!File.Exists(filename))
            {
                SaveToXML(objs, filename);
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                List<Employee> employees = new List<Employee>();
                              
                using(TextReader reader = new StreamReader(filename))
                {
                    List<Employee> emp = (List<Employee>)serializer.Deserialize(reader);
                    foreach (Employee e in emp)
                    {
                        employees.Add(e);
                    }
                }
                foreach (Employee e in objs)
                {
                    employees.Add(e);
                }
                SaveToXML(employees, filename);
            }
        }

        private static void SaveToXML(List<Employee> objs, string filename)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            TextWriter writer = new StreamWriter(filename, false);
            serializer.Serialize(writer, objs);
            writer.Close();
        }
    }
}
