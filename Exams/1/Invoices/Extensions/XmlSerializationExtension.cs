﻿namespace Invoices.Extensions
{
    using System.Text;
    using System.Xml.Serialization;

    public static class XmlSerializationExtension
    {
        public static string SerializeToXml<T>(this T obj, string rootElement)
        {
            XmlSerializerNamespaces namespaces = new();
            namespaces.Add("", "");

            using MemoryStream stream = new();

            XmlSerializer serializer = new(typeof(T), new XmlRootAttribute(rootElement));
            serializer.Serialize(stream, obj, namespaces);

            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public static T DeserializeToXml<T>(this string xmlString, string rootElement)
        {
            XmlSerializer serializer = new(typeof(T), new XmlRootAttribute(rootElement));

            using MemoryStream stream = new(Encoding.UTF8.GetBytes(xmlString));

            return (T)serializer.Deserialize(stream);
        }
    }
}
