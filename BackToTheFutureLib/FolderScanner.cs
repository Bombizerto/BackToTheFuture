using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToTheFutureLib
{
    public class FolderScanner
    {
        public static List<FileLog> ScanFolder(string path)
        {
            //crea una lista de ficheros
            List<FileLog> files = new List<FileLog>();
            //recorre el directorio y subdirectorios
            foreach (string file in System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.AllDirectories))
            {
                //crea un fichero y lo añade a la lista
                files.Add(new FileLog(System.IO.Path.GetFileNameWithoutExtension(file), System.IO.File.ReadAllText(file), System.IO.Path.GetDirectoryName(file), System.IO.Path.GetExtension(file)));
            }
            //devuelve la lista de ficheros
            return files;
        }
        
        public static List<FileLog> FindDuplicates(List<FileLog> files)
        {
            //recorre la lista de ficheros
            for (int i = 0; i < files.Count; i++)
            {
                //recorre la lista de ficheros
                for (int j = 0; j < files.Count; j++)
                {
                    //compara el contenido de los ficheros
                    if (files[i].Text == files[j].Text && i != j)
                    {
                        //dejamos vacio el texto del fichero duplicado
                        files[j].Text = "";
                        //añade el fichero a la lista de duplicados
                        files[i].Duplicates.Add(files[j]);
                        //elimina el fichero de la lista
                        files.RemoveAt(j);
                    }
                }
            }
            //devuelve la lista de ficheros
            return files;
        }
        
        public static void SerializeToJson(string path, List<FileLog> files)
        {
            //Borrar todos los archivos de la ruta
            foreach (string file in System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.File.Delete(file);
            }
            //Borrar todas las subcarpetas del directorio
            foreach (string folder in System.IO.Directory.GetDirectories(path, "*.*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.Directory.Delete(folder);
            }
            //serializa la lista de ficheros en un json
            System.IO.File.WriteAllText(path + "Result.json", Newtonsoft.Json.JsonConvert.SerializeObject(files));
        }
        
        
        public static void DeserializeFromJson(string path)
        {
            //deserializa el json en una lista de ficheros
            List<FileLog> files = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FileLog>>(System.IO.File.ReadAllText(path));
            //recorre la lista de ficheros
            foreach (FileLog file in files)
            {
                //genera los ficheros
                file.GenerateFiles();
            }
        }
        
        public static void CompareFolders(string path1, string path2)
        {
            //recorre el directorio y subdirectorios
            foreach (string file in System.IO.Directory.GetFiles(path1, "*.*", System.IO.SearchOption.AllDirectories))
            {
                //si el fichero no existe en la ruta 2 lo muestra por consola
                if (!System.IO.File.Exists(path2 + file.Replace(path1, "")))
                {
                    Console.WriteLine(file);
                }
            }
        }
    }
}
