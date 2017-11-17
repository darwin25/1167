using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebControls
{
    public class LineItemList
    {
        private List<LineItem> items = new List<LineItem>();

        public List<LineItem> Items
        {
            get { return items; }
        }
        private string selectedText = string.Empty;

        public string SelectedText
        {
            get
            {
                foreach (var item in items)
                {
                    if (item.Visiable && item.EnableSelected && item.Selected)
                    {
                        return item.Text;
                    }
                }
                return selectedText;
            }
            set
            {
                bool notext = true;
                foreach (var item in items)
                {
                    if (item.Visiable && item.EnableSelected)
                    {
                        if (item.Text == value)
                        {
                            item.Selected = true;
                            notext = false;
                            break;
                        }
                        else
                        {
                            item.Selected = false;
                        }
                    }
                }
                selectedText = value;
                if (notext)
                {
                    selectedText = string.Empty;
                    foreach (var item in items)
                    {
                        if (item.Visiable && item.EnableSelected)
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                }
            }
        }
        private string selectedValue = string.Empty;

        public string SelectedValue
        {
            get
            {
                foreach (var item in items)
                {
                    if (item.Visiable && item.EnableSelected && item.Selected)
                    {
                        return item.Value;
                    }
                }
                return selectedValue;
            }
            set
            {
                bool noValue = true;
                foreach (var item in items)
                {
                    if (item.Visiable && item.EnableSelected)
                    {
                        if (item.Value == value)
                        {
                            item.Selected = true;
                            noValue = false;
                            break;
                        }
                        else
                        {
                            item.Selected = false;
                        }
                    }
                }
                selectedValue = value;
                if (noValue)
                {
                    selectedValue = string.Empty;
                    foreach (var item in items)
                    {
                        if (item.Visiable && item.EnableSelected)
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                }
            }
        }
    }
}
