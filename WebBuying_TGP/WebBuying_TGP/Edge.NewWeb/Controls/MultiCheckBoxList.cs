using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Edge.Web.Controls
{
    public class MultiCheckBoxList : CheckBoxList
    {
        /// <summary>
        /// 取得清單控制項中選取項目的值，或選取清單控制項中包含特定數值的項目。
        /// </summary>
        /// <value></value>
        /// <returns>
        /// 清單控制項中選取項目的值。預設值為空字串 ("")。
        /// </returns>
        /// <remarks>
        /// 假如item有1,2,3,a。
        /// 當SelectedValue="1,a,b"，則1與a的項目會被勾選，不會出現exception。
        /// 假如勾選2與3與a，則SelectedValue="2,3,a"
        /// </remarks>
        public override string SelectedValue
        {
            get
            {
                string _ReturnValue = "";
                this.EnsureChildControls();
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].Selected == true)
                    {
                        _ReturnValue += this.Items[i].Value + ",";
                    }

                }
                if (!string.IsNullOrEmpty(_ReturnValue))
                {
                    _ReturnValue = _ReturnValue.TrimEnd(',');

                }
                else
                {
                    return string.Empty;
                }
                return _ReturnValue;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                string _ReturnValue = "";

                this.EnsureChildControls();
                _ReturnValue = value;

                for (int i = 0; i < this.Items.Count; i++)
                {
                    this.Items[i].Selected = false;

                }

                if (_ReturnValue.ToString().Trim().Length != 0)
                {

                    string[] ReturnValue1 = _ReturnValue.Split(',');

                    // 1,2,3
                    for (int intItem = 0; intItem <= ReturnValue1.Length - 1; intItem++)
                    {
                        for (int i = 0; i < this.Items.Count; i++)
                        {
                            if (ReturnValue1[intItem] == this.Items[i].Value)
                            {
                                this.Items[i].Selected = true;
                                break;
                            }

                        }

                    }

                }

            }

        }

    }
}
