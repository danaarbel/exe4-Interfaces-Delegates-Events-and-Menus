using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class MenuActions
    {
        private const string k_CurrentVersion = "20.2.4.30620";

        public static void CountCaptials()
        {
            Console.WriteLine("Please write a sentence");
            string userSentence = Console.ReadLine();
            int numberOfCaptials = 0;

            for (int i = 0; i < userSentence.Length; i++)
            {
                if (char.IsUpper(userSentence[i]))
                {
                    numberOfCaptials++;
                }
            }

            Console.WriteLine(string.Format("There is {0} captials letters in the sentence", numberOfCaptials));
        }

        public class CountCaptialsSelected : IActionItemSelectedObserver
        {
            public void NotifySelected()
            {
                CountCaptials();
            }
        }

        public static void ShowVersion()
        {
            Console.WriteLine(string.Format("Version: {0}", k_CurrentVersion));
        }

        public class ShowVersionSelected : IActionItemSelectedObserver
        {
            public void NotifySelected()
            {
                ShowVersion();
            }
        }

        public static void ShowTime()
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
        }

        public class ShowTimeSelected : IActionItemSelectedObserver
        {
            public void NotifySelected()
            {
                ShowTime();
            }
        }

        public static void ShowDate()
        {
            Console.WriteLine(DateTime.Today.ToString("dd-MM-yyyy"));
        }

        public class ShowDateSelected : IActionItemSelectedObserver
        {
            public void NotifySelected()
            {
                ShowDate();
            }
        }
    }
}