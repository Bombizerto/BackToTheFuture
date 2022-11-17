using BackToTheFutureLib;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BackToTheFuture.Classes
{
    public class Menu
    {
        public static string path="";
        public static void displayMenu()
        {
            String option = "";
            do
            {
                Console.WriteLine("1. Generate Random Files");
                Console.WriteLine("2. Compress Json");
                Console.WriteLine("3. Generate Folders From Json");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Select An Octions:");
                option = Console.ReadLine();
                Console.WriteLine(getSelectedOption(option));
            } while (option != "4");
            
        }
        public static string getSelectedOption(String option)
        {
            String resultMessage = "";
            
            while (Menu.path == "")
            {
                Console.WriteLine("Insert a Valid path:");
                String pathAux = Console.ReadLine();
                if (Directory.Exists(pathAux))
                {
                    path = pathAux.TrimEnd(Path.DirectorySeparatorChar);
                }
            }
            try
            {
                int numericOption = Convert.ToInt32(option);
                if(numericOption<0 || numericOption > 4)
                {
                    return "Enter a Number Between 1 and 4";
                }
                switch (numericOption)
                {
                    case 1:
                        DocGenerator.GenerateRandomDocs(path+Path.DirectorySeparatorChar);
                        resultMessage= "Random folder system generated";
                        break;
                    case 2:
                        List<FileLog> files = FolderScanner.ScanFolder(path);
                        FolderScanner.SerializeToJson(path + Path.DirectorySeparatorChar, FolderScanner.FindDuplicates(files));
                        resultMessage= "Log File system clustered in a Json";
                        break;
                    case 3:
                        if(File.Exists(path + Path.DirectorySeparatorChar + "Result.json"))
                        {
                            FolderScanner.DeserializeFromJson(path + Path.DirectorySeparatorChar + "Result.json");
                            resultMessage = "Log folder system regenerated";
                        }
                        else
                        {
                            resultMessage = "Result.json doesn't exist, generate one and rerun the process";
                        }
                        break;
                    case 4:
                        resultMessage= "Finish";
                        break;
                }
                return resultMessage;
            }
            catch (Exception ex)
            {
                return "Enter a Number Between 1 and 4";
            }
        }
    }
}
