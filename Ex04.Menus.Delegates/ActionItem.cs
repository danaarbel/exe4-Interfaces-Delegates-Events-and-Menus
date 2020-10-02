using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class ActionItem : MenuItem
    {
        public event ActionItemSelectedEventHandler Selected;

        public ActionItem(string i_Title) : base(i_Title)
        {
        }

        protected internal override void ActionWhenSelected()
        {
            Console.Clear();
            OnSelected();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            (ParentMenu as Menu).Show();
        }

        protected virtual void OnSelected()
        {
            if(Selected != null)
            {
                Selected.Invoke();
            }
        }
    }
}