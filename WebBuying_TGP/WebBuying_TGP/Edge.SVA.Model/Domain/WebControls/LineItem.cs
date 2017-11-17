using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebControls
{
    public class LineItem
    {
        private string text = string.Empty;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        private string _value = string.Empty;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private bool selected = false;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        private bool enableSelected = true;

        public bool EnableSelected
        {
            get { return enableSelected; }
            set { enableSelected = value; }
        }
        private bool visiable = true;

        public bool Visiable
        {
            get { return visiable; }
            set { visiable = value; }
        }
    }
}
