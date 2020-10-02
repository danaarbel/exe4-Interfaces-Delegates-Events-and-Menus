using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class TestMenuByDelegate
    {
        private MainMenu m_MainMenu;

        public void StartTestMenu()
        {
            m_MainMenu = new MainMenu("Delegate Test Menu");
            createMainMenu();
            m_MainMenu.Show();
        }

        private void createMainMenu()
        {
            Menu versionAndCapitals = new Menu("Version and Capitals");
            ActionItem countCaptials = new ActionItem("Count Captials");
            countCaptials.Selected += countCaptials_Selected;
            ActionItem showVersion = new ActionItem("Show Version");
            showVersion.Selected += showVersion_Selected;   
            Menu showDateOrTime = new Menu("Show Date/Time");
            ActionItem showTime = new ActionItem("Show Time");
            showTime.Selected += showTime_Selected;
            ActionItem showDate = new ActionItem("Show Date");
            showDate.Selected += showDate_Selected;
            m_MainMenu.AddItemToListMenu(versionAndCapitals);
            m_MainMenu.AddItemToListMenu(showDateOrTime);
            versionAndCapitals.AddItemToListMenu(countCaptials);
            versionAndCapitals.AddItemToListMenu(showVersion);
            showDateOrTime.AddItemToListMenu(showTime);
            showDateOrTime.AddItemToListMenu(showDate);
        }

        private void countCaptials_Selected()
        {
            MenuActions.CountCaptials();
        }

        private void showVersion_Selected()
        {
            MenuActions.ShowVersion();
        }

        private void showTime_Selected()
        {
            MenuActions.ShowTime();
        }

        private void showDate_Selected()
        {
            MenuActions.ShowDate();
        }
    }
}