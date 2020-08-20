using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glashandel
{
    public class CheckBoxFormElement : FormElement
    {
        private CheckBox checkBox;
       
        public CheckBoxFormElement(Form form, string text) : base(form)
        {
            checkBox = new CheckBox();
            checkBox.Text = text;
            form.Controls.Add(checkBox);
        }
        public bool GetValue()
        {
            return checkBox.Checked;
        }
        protected override void AlterPosition(int widthOfset, int heightOfset)
        {
            checkBox.Location = new System.Drawing.Point(widthOfset, heightOfset);
        }

        internal void SetWidth(int width)
        {
            checkBox.Width = width;
        }
    }
}
