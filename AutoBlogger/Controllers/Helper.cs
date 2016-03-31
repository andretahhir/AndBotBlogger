using AutoBlogger.Models;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AutoBlogger.Controllers
{
    public static class Helper
    {
        private static string _optionsFile = "Options.xml";

        public static string Serialize<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);
                    WriteForFile(stringWriter.ToString());
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        public static Token DeSerialize()
        {
            try
            {
                // Open the file to read from.
                using (StreamReader sr = File.OpenText(_optionsFile))
                {
                    string s = "";
                    s = sr.ReadToEnd();
                    XmlSerializer serializer = new XmlSerializer(typeof(Token));

                    Token token = null;
                    StreamReader reader = new StreamReader(_optionsFile);
                    token = (Token)serializer.Deserialize(reader);
                    reader.Close();
                    return token;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        private static void WriteForFile(string newLine)
        {
            try
            {
                if (!File.Exists(_optionsFile))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(_optionsFile))
                    {
                        sw.Write(newLine);
                    }
                }
                else
                {
                    // This text is always added, making the file longer over time
                    // if it is not deleted.
                    using (StreamWriter sw = File.CreateText(_optionsFile))
                    {
                        sw.Write(newLine);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}