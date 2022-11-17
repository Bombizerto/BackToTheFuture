using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToTheFutureLib
{
    public class FileLog
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }

        public List<FileLog> Duplicates { get; set; }

        public FileLog(string name, string text, string path, string extension)
        {
            Name = name;
            Text = text;
            Path = path;
            Extension = extension;
            Duplicates = new List<FileLog>();
        }
        
        public void GenerateFiles()
        {
            if (!System.IO.Directory.Exists(Path))
            {
                System.IO.Directory.CreateDirectory(Path);
            }
            
            System.IO.File.WriteAllText(Path + "\\" + Name + Extension, Text);
            foreach (FileLog file in Duplicates)
            {
                if (!System.IO.Directory.Exists(file.Path))
                {
                    System.IO.Directory.CreateDirectory(file.Path);
                }
                if (file.Extension == ".bin")
                {
                    System.IO.File.WriteAllBytes(file.Path + "\\" + file.Name + file.Extension, Encoding.ASCII.GetBytes(Text));
                }
                else
                {
                    System.IO.File.WriteAllText(file.Path + "\\" + file.Name + file.Extension, Text);
                }

            }
        }


    }
}
