using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem
    {
        private string m_Title;
        private MenuItem m_ParentMenu;

        protected MenuItem(string i_Title)
        {
            m_Title = i_Title;
            m_ParentMenu = null;
        }

        protected string Title
        {
            get { return m_Title; }
        }

        protected internal MenuItem ParentMenu
        {
            get { return m_ParentMenu; }
            set { m_ParentMenu = value; }
        }

        protected internal abstract void ActionWhenSelected();

        public override string ToString()
        {
            return m_Title;
        }
    }
}