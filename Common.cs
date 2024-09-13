using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace View
{
    public static class Common
    {
        public static void ValidateControls(Control Parent)
        {
            if (Parent == null)
                return;

            var ControlList = Parent.GetControls();

            foreach (ISp ISP in ControlList.OfType<ISp>())
            {
                ISP.Validate();
            }
        }

        public static List<Control> GetControls(this Control Base)
        {
            List<Control> DataList = new();
            foreach (Control CTL in Base.Controls)
            {
                DataList.Add(CTL);
                if (CTL.Controls.Count > 0)
                    DataList.AddRange(CTL.GetControls());
            }
            return DataList;
        }
    }
}
