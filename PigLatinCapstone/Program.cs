using System;

namespace PigLatinCapstone
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepasking = true;
            Console.WriteLine("Welcome to the Pig Latin Translator");
            while (keepasking)
            {
                Console.Write("Please enter a line: ");
                string input = Console.ReadLine().ToLower().Trim();
                string[] words = input.Split();
                foreach (string word in words)
                {
                    PigLatin(word);
                }
                Console.WriteLine();
                keepasking = KeepRunning();
            }
        }

        public static bool KeepRunning()
        {
            Console.WriteLine("Do you wish to translate another word? yes/no");
            string answer = Console.ReadLine().ToLower().Trim();
            if (answer == "y" || answer == "yes")
            {
                return true;
            }
            else if (answer == "n" || answer == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Please enter yes or no");
                return KeepRunning();
            }
        }


        public static bool Vowels(char vowel)
        {
            return vowel == 'a' || vowel == 'e' || vowel == 'i' || vowel == 'o' || vowel == 'u';
        }

        public static void PigLatin(string message)
        {
            int index = -1;
            int pindex = 0;
            int j = message.Length - 1;
            for (int i = 0; i < message.Length; i++)
            {


                if (Punctuation(message[j]))
                {
                    pindex = j;
                    if (Vowels(message[i]))
                    {
                        index = i;
                        if (index == 0)
                        {
                            Console.Write(message.Substring(0, pindex) + "way" + message.Substring(pindex) + " ");
                            break;
                        }

                        else
                        {
                            Console.Write(message.Substring(index, pindex - 1) + message.Substring(0, index) + "ay" + message.Substring(pindex) + " ");
                            break;
                        }
                    }
                }


                if (!Punctuation(message[j]))
                {
                    if (Vowels(message[i]))
                    {
                        index = i;
                        if (index == 0)
                        {
                            Console.Write(message + "way ");
                            break;
                        }
                        else
                        {
                            Console.Write(message.Substring(index) + message.Substring(0, index) + "ay ");
                            break;
                        }
                    }
                }
            }
            if (index == -1)
            {

                Console.Write(message + " ");

            }
        }

        public static bool Punctuation(char punc)
        {
            return punc == '.' || punc == '!' || punc == '?' || punc == ',';
        }

       // public static bool IsLetters(char[] word)
       // {

       // }
    }

}
