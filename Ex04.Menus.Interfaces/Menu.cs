using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class Menu : MenuItem
    {
        private readonly List<MenuItem> r_MenuItemList;
        protected string m_ReturnFromMenu = string.Empty;

        public Menu(string i_Title) : base(i_Title)
        {
            r_MenuItemList = new List<MenuItem>();
        }

        protected virtual string UpdateReturnFromMenu()
        {
            m_ReturnFromMenu = "Back";

            return m_ReturnFromMenu;
        }

        protected internal override void ActionWhenSelected()
        {
            Show();
        }

        public void Show()
        {
            Console.WriteLine(Title);
            Console.WriteLine("=====================");
            printMenu();
            int choiceOfUser = receiveCorrectInput();
            Console.Clear();
            if (choiceOfUser != 0)
            {
                r_MenuItemList[choiceOfUser - 1].ParentMenu = this;
                r_MenuItemList[choiceOfUser - 1].ActionWhenSelected();
            }
            else
            {
                if (!(this is MainMenu))
                {
                    ParentMenu.ActionWhenSelected();
                }
            }
        }

        private void printMenu()
        {
            int numberOfMenuOption = 1;
            foreach (MenuItem menuItem in r_MenuItemList)
            {
                Console.WriteLine(string.Format("{0}. {1}", numberOfMenuOption, menuItem.ToString()));
                numberOfMenuOption++;
            }

            string exitOrBack = UpdateReturnFromMenu();
            Console.WriteLine(string.Format("0. {0}", exitOrBack));
            Console.WriteLine(string.Format("Please enter one of the menu options: 1 - {0} or 0 for {1}", numberOfMenuOption - 1, exitOrBack));
        }

        private int receiveCorrectInput()
        {
            bool correctUserInput = false;
            int choiceOfUser = 0;
            while (!correctUserInput)
            {
                string userInput = Console.ReadLine();
                choiceOfUser = validationOfMenuOption(userInput);
                if (choiceOfUser != -1)
                {
                    correctUserInput = true;
                }
                else
                {
                    Console.WriteLine("Please try again!");
                }
            }

            return choiceOfUser;
        }

        private int validationOfMenuOption(string i_UserInput)
        {
            int validInput = -1;
            bool parseSucceed = int.TryParse(i_UserInput, out int userInputInteger);
            if(parseSucceed)
            {
                if(userInputInteger > r_MenuItemList.Count || userInputInteger < 0)
                {
                    Console.WriteLine("The input isn't in the range of the menu options!");
                }
                else
                {
                    validInput = userInputInteger;
                }
            }
            else
            {
                Console.WriteLine("The input isn't integer");
            }

            return validInput;
        }

        public void AddItemToListMenu(MenuItem i_MenuItemToAdd)
        {
            r_MenuItemList.Add(i_MenuItemToAdd);
        }
    }
}