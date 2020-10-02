using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class ActionItem : MenuItem
    {
        private readonly List<IActionItemSelectedObserver> r_ActionItemSelectedObservers;

        public ActionItem(string i_Title) : base(i_Title)
        {
            r_ActionItemSelectedObservers = new List<IActionItemSelectedObserver>();
        }

        public void AddActionItemSelectedObserver(IActionItemSelectedObserver i_Observer)
        {
            r_ActionItemSelectedObservers.Add(i_Observer);
        }

        public void RemoveActionItemSelectedObserver(IActionItemSelectedObserver i_Observer)
        {
            r_ActionItemSelectedObservers.Remove(i_Observer);
        }

        protected internal override void ActionWhenSelected()
        {
            Console.Clear();
            notifyActionItemSelectedObservers();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            (ParentMenu as Menu).Show();
        }

        private void notifyActionItemSelectedObservers()
        {
            foreach(IActionItemSelectedObserver Observer in r_ActionItemSelectedObservers)
            {
                Observer.NotifySelected();
            }
        }
    }
}