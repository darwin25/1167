using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebControls
{
    public class DropdownList
    {
        private List<LineItem> items = new List<LineItem>();

        public List<LineItem> Items
        {
            get { return items; }
            set { items = value; }
        }

    }    
}
