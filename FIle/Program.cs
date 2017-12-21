using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIle
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             * FileString - работает с фаайлами 
             * StreamReader/ StreamWriter - работает с текстом
             * BinaryReader/ BinaryWriter = работает с файлмаи .bin
             */

            string text = "Hello World!!";
            byte[] sourse = Encoding.UTF32.GetBytes(text);

            using (FileStream stream = new FileStream(@"C:\name_of_directory\my_file.txt", FileMode.OpenOrCreate))
            {
                stream.Write(sourse, 0, sourse.Length);
            }

            byte[] reciver = File.ReadAllBytes(@"C:\name_of_directory\my_file.txt");

            using (FileStream stream = File.OpenRead(@"C:\name_of_directory\my_file.txt"))
            {
                byte[] recieverdData = new byte[stream.Length];
                stream.Read(recieverdData, 0, recieverdData.Length);

                string recievedText = Encoding.UTF32.GetString(recieverdData);

            }

            using (StreamWriter writer = new StreamWriter(File.Open(@"C:\name_of_directory\data.txt",FileMode.Append)))
            {
                string sendText = "Привет!!";
                writer.WriteLine(sendText);
            }

            using (StreamReader reader = new StreamReader(File.Open(@"C:\name_of_directory\data.txt", FileMode.Open)))
            {
                string recievedText = "";
                recievedText = reader.ReadToEnd();
            }

            using (BinaryWriter writer = new BinaryWriter(new FileStream(@"C:\name_of_directory\data.bin", FileMode.OpenOrCreate)))
            {
                var person = new { Name = "", Age = -1, Sex = false };
                writer.Write(person.Name);
                writer.Write(person.Age);
                writer.Write(person.Sex);
            }

            using (BinaryReader reader = new BinaryReader(new FileStream(@"C:\name_of_directory\data.bin", FileMode.OpenOrCreate)))
            {
                string name = reader.ReadString();
                int age = reader.ReadInt32();
                bool sex = reader.ReadBoolean();

                var person = new { Name = name, Age = age, Sex = sex };
            }

            //var drives = DriveInfo.GetDrives();
            //Directory.CreateDirectory(@"C:\name_of_directory");
            //DirectoryInfo dir = new DirectoryInfo(@"C:\name_of_directory");
            //var dirr = Directory.GetCurrentDirectory();
            //if (Directory.Exists(@"C:\name_of_directory"))
            //{ File.Create(@"C:\name_of_directory\my_file.txt"); }
            //else
            //{ Console.WriteLine("Is not created"); }
            //FileInfo fileinfo = new FileInfo(@"C:\name_of_directory\my_file.txt");

        }
    }
}
