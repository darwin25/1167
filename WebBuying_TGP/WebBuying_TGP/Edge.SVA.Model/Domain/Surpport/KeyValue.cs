using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.Surpport
{
    public class KeyValue : Edge.SVA.Model.Domain.IKeyValue
    {
        public KeyValue() { }
        public KeyValue(string key,string _value)
        {
            this.key = key;
            this._value = _value;
        }
        private string key = string.Empty;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string _value = string.Empty;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
