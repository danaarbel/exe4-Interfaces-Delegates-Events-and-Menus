using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class TestMenuByInterface
    {
        private MainMenu m_MainMenu;

        public void StartTestMenu()
        {
            m_MainMenu = new MainMenu("Interface Test Menu");
            createMainMenu();
            m_MainMenu.Show();
        }

        private void createMainMenu()
        {
            Menu versionAndCapitals = new Menu("Version and Capitals");
            ActionItem countCaptials = new ActionItem("Count Captials");
            countCaptials.AddActionItemSelectedObserver(new MenuActions.CountCaptialsSelected());
            ActionItem showVersion = new ActionItem("Show Version");
            showVersion.AddActionItemSelectedObserver(new MenuActions.ShowVersionSelected());
            Menu showDateOrTime = new Menu("Show Date/Time");
            ActionItem showTime = new ActionItem("Show Time");
            showTime.AddActionItemSelectedObserver(new MenuActions.ShowTimeSelected());
            ActionItem showDate = new ActionItem("Show Date");
            showDate.AddActionItemSelectedObserver(new MenuActions.ShowDateSelected());
            m_MainMenu.AddItemToListMenu(versionAndCapitals);
            m_MainMenu.AddItemToListMenu(showDateOrTime);
            versionAndCapitals.AddItemToListMenu(countCaptials);
            versionAndCapitals.AddItemToListMenu(showVersion);
            showDateOrTime.AddItemToListMenu(showTime);
            showDateOrTime.AddItemToListMenu(showDate);
        }
    }
}