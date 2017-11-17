using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineUI;

namespace Edge.Web.Tools
{
    public class ExtAspNetPropertyTool
    {
        private List<FineUI.ControlBase> controlList = new List<FineUI.ControlBase>();
        public void AddControl(FineUI.ControlBase control)
        {
            controlList.Add(control);
        }
        public void Clear()
        {
            controlList.Clear();
        }
        public void SetState(PropertyName properName,bool enabled)
        {            
            switch (properName)
            {
                case PropertyName.Enalbed:
                    foreach (var item in controlList)
                    {
                        item.Enabled = enabled;
                    }
                    break;
                case PropertyName.Visible:
                    foreach (var item in controlList)
                    {
                        item.Visible = enabled;
                    }
                    break;
                case PropertyName.Hidden:
                    foreach (var item in controlList)
                    {
                        item.Hidden = enabled;
                    }
                    break;
                default:
                    break;
            }
        }
        public enum PropertyName
        {
            Enalbed,
            Visible,
            Hidden
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="defaultText"></param>
        /// <param name="ifEmpty">是否需要判断为empty才赋默认值</param>
        public void SetDefaultValue(TextPropertyName propertyName,string defaultText,bool ifEmpty)
        {
            if (ifEmpty)
            {
                switch (propertyName)
                {
                    case TextPropertyName.Text:
                        foreach (var item in controlList)
                        {
                            RealTextField rtf = item as RealTextField;
                            if (rtf != null)
                            {
                                if (rtf.Text.Trim().Length==0)
                                {
                                    rtf.Text = defaultText;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (propertyName)
                {
                    case TextPropertyName.Text:
                        foreach (var item in controlList)
                        {
                            RealTextField rtf = item as RealTextField;
                            if (rtf!=null)
                            {
                                rtf.Text = defaultText;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            
        }
        public enum TextPropertyName
        {
            Text
        }
    }
}