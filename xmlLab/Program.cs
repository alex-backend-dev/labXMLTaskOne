using System;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace labXMLTaskOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] content = File.ReadAllLines("Inlet.in.txt", Encoding.Default);

            XDocument xDoc = new XDocument();

            XElement root = new XElement("root");
            XElement line = new XElement("line");


            for (int i = 0; i < content.Length; i++)
            {
                string[] words = content[i].Split(' '); // массив подстрок
                Array.Sort(words);

                for (int j = 0; j < words.Length; j++)
                {
                    XText text = new XText(words[j]);

                    XElement word = new XElement("word");

                    word.Add(text);
                    line.Add(word);
                }

                root.Add(line);

                line = new XElement("line");
            }

            xDoc.Add(root);
            xDoc.Save("resultFile.xml");
        }
    }
}
