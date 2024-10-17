using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Presneters
{
    static class FileSaverReader
    {
        public static IEnumerable ReadFile<T>(string? file)
        {
            TextReader? reader = null;
            Stream? stream;
            List<T> returnList = new List<T>();
            System.Xml.Serialization.XmlSerializer _serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Models.Event>));

            if (file != null)
                reader = new StreamReader(file);
            else
            {
                stream = openReadFileByUser();
                if (stream?.Length == 0)
                    MessageBox.Show("Plik jest pusty");
                else if(stream != null)
                    reader = new StreamReader(stream);
            }

            if (reader != null)
            {
                returnList = (List<T>)_serializer.Deserialize(reader);
            }

            reader?.Close();
            return returnList;
        }

        private static Stream? openReadFileByUser()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "xml files|*.xml|All files|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.OpenFile();
                }
            }
            return null;
        }

        public static void WriteFile<T>(IEnumerable collection)
        {
            StreamWriter? writer = new StreamWriter(openWriteFileByUser());
            System.Xml.Serialization.XmlSerializer _serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));

            if (writer != null)
            {
                _serializer.Serialize(writer, collection);
            }

            writer?.Close();
        }

        public static void WriteFileToDefault<T>(IEnumerable collection)
        {
            StreamWriter? writer = new StreamWriter("default.xml");
            System.Xml.Serialization.XmlSerializer _serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));

            if (writer != null)
            {
                _serializer.Serialize(writer, collection);
            }

            writer?.Close();
        }

        private static Stream openWriteFileByUser()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "xml files|*.xml|All files|*.*";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.OpenFile();
                }
            }
            return Stream.Null;
        }
    }
}
