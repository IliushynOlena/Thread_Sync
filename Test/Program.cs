namespace Test
{
    static class Stats
    {
        public static int NumbsCount { get; set; }
        public static int UpperLettersCount { get; set; } = 0;
        public static int LowerLettersCount { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {





            string[] files = Directory.GetFiles(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Test");

            Thread[]threads = new Thread[files.Length]; 
            for (int i = 0; i < files.Length; i++)    
            {
                string text = File.ReadAllText(files[i]);

                threads[i] = new Thread(TextAnalyse);
                //Thread thread = new Thread(TextAnalyse);

                threads[i].Start(text);
            }


            Console.WriteLine(Stats.NumbsCount);


        }

        static void TextAnalyse(object stat)
        {
            //Stats stats = new Stats();
            string text = (string)stat;
            foreach (char let in text)
            {
                if (Char.IsUpper(let))
                {
                    //Interlocked.Increment(ref Stats.UpperLettersCount);
                    lock (typeof(Stats))
                    {
                        ++Stats.UpperLettersCount;
                    }
                   
                }
                if (char.IsDigit(let))
                {
                    //++Stats.NumbsCount;
                }
                if (char.IsLower(let))
                {
                    //++Stats.LowerLettersCount;
                }
            }
        }


    }
}
