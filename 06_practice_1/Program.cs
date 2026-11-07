using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace _06_practice_1
{
    class Stat
    {
        public static int Letters { get; set; }
        public static int Digits { get; set; }
        //...
     
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stat statistic = new Stat();

     

    
            string[] files = Directory.GetFiles(@$"{
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Test");

            foreach (var file in files)
            {
                Console.WriteLine(file);
                //Console.WriteLine(Path.GetFileName(file));
                //FileStream fs = new FileStream(file, FileMode.Open);
                //fs.Read
               

                //StreamReader sr = new StreamReader(file);
                //Console.WriteLine(sr.ReadToEnd()); ;

                string text = File.ReadAllText(file);
                Console.WriteLine(text);
               
                //Thread thread = new Thread(TextAnalyse);
                //thread.Start(text);
                //Console.WriteLine(text);
                //Task.Run(() => TextAnalyse(text));
            }        

            // show total statistic
        }

        static void TextAnalyse(object text)
        {
            string words = "dlgnkdsghdkfghkdsjfgkjdfghkjdf";
            foreach (char word in words) 
            {
              
                //if(Char.IsLetter(word))
            }
            Stat.Digits++;
            // text analyse how many letters, digits etc.

        }
    }
}
