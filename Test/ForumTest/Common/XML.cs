using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using ForumTest.ProjectComponent;

namespace ForumTest.Common
{
    public class XML    
    {   
        public static T DeserializeObject<T>(string xmlPath)
        {
            if (xmlPath == null)
                throw new ArgumentNullException("xmlPath");

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(xmlPath, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            T obj = (T)serializer.Deserialize(reader);
            reader.Close();
            fs.Close();
            return obj;
        }

        public static void SerializeObject<T>(T obj, string xmlPath)
        {
            if (xmlPath == null)
                throw new ArgumentNullException(xmlPath);

            if (obj == null)
                throw new ArgumentNullException("obj");

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            FileStream fileStream = new FileStream(xmlPath, FileMode.Create);
            serializer.Serialize(fileStream, obj);
            fileStream.Close();
        }
    }
}
