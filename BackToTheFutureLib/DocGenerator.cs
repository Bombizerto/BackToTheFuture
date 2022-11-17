using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BackToTheFutureLib
{
    public class DocGenerator
    {

        public static Random random = new Random();
        public static void GenerateDoc(string path, string name, string text)
        {
            string folder = "Folder" + random.Next(4).ToString() + "\\";
            string randomPath = path + "\\" + folder;
            if (!Directory.Exists(randomPath))
            {
                Directory.CreateDirectory(randomPath);
            }
            File.WriteAllText(randomPath + name + random.Next(5000).ToString() + ".txt", text + random.Next(5000).ToString());
            folder = "Folder" + random.Next(4).ToString() + "\\";
            randomPath = path + "\\" + folder;
            if (!Directory.Exists(randomPath))
            {
                Directory.CreateDirectory(randomPath);
            }
            File.WriteAllBytes(randomPath + name + random.Next(5000).ToString() + ".bin", Encoding.ASCII.GetBytes(text + random.Next(5000).ToString()));
        }
        
        public static bool CompareDoc(string path, string name)
        {
            return File.ReadAllText(path + name + ".txt") == Encoding.ASCII.GetString(File.ReadAllBytes(path + name + ".bin"));
        }
        
        public static void GenerateRandomDocs(string path)
        {
            int number = random.Next(5000);
            for (int i = 0; i < number; i++)
            {
                string text = random.Next(10000).ToString();
                GenerateDoc(path, "Data", "Hello World");
            }
        }
    }
}
