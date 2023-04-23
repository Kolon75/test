using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;


namespace Test2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/gumba/OneDrive/Рабочий стол/text.txt";//Здесь укажите путь к файлу


            using (StreamReader reader = new StreamReader(path))
            {
                string text = reader.ReadToEnd();
                string[] words = text.Split(' ', '.', ',', '!', '?','"','\r',';','\n','-','(',')');
                int[] count = new int[words.Length];           
                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = words[i].ToLower();
                    
                }
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] != null && words[i] != "")
                    {

                        for (int j = i + 1; j < words.Length; j++)
                        {
                            if (words[i] == words[j])
                            {
                                count[i]++;
                                words[j] = null;
                            }
                        }
                    }

                }
                for (int i = 0; i < words.Length; i++)
                {
                    for (int j = 0; j < words.Length-1; j++)
                    {
                        if (count[j] < count[j + 1])
                        {
                            int t = count[j + 1];
                            count[j + 1] = count[j];
                            count[j] = t;
                            string bb = words[j + 1];
                            words[j + 1] = words[j];
                            words[j] = bb;
                        }
                    }
                }
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] != null && words[i] != "")
                    {
                        Console.WriteLine(words[i] + " " + count[i]);
                    }
                }
            }   
            Console.ReadKey();
        }
    }
}
