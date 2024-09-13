using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace Browsers
{
    public static class OFD
    {
        public static void Get(object sender)
        {
            var btn = (SpButton)sender;

            if (btn == null || btn.Destination == null)
                return;

            var ofd = CreateOFD($"Select {btn.FileName} File", $"Supported File ({btn.Format.ToUpper()})|*.{btn.Format}");

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                btn.Destination.Text = ofd.FileName;
            }
        }

        private static OpenFileDialog CreateOFD(string Title, string Filter = "", bool RestoreDirectory = true, bool Multiselect = false, bool CheckFileExists = true, bool CheckPathExists = true, bool SupportMultiDottedExtensions = true, bool ValidateNames = true)
        {
            using OpenFileDialog OFD = new ()
            {
                Title = Title,
                Multiselect = Multiselect,
                CheckFileExists = CheckFileExists,
                CheckPathExists = CheckPathExists,
                Filter = Filter,
                RestoreDirectory = RestoreDirectory,
                SupportMultiDottedExtensions = SupportMultiDottedExtensions,
                ValidateNames = ValidateNames,
            };

            return OFD;
        }
    }

    public static class SFD
    {
        public static void Get(object sender)
        {
            var btn = (SpButton)sender;

            if (btn == null || btn.Destination == null)
                return;

            var sfd = CreateSFD("Select Save Path", btn.FileName, $"Supported File ({btn.Format.ToUpper()})|*.{btn.Format}");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                btn.Destination.Text = sfd.FileName;
            }
        }


        private static SaveFileDialog CreateSFD(string Title, string FileName = "", string Filter = "", bool RestoreDirectory = true, bool Multiselect = false, bool CheckFileExists = false, bool CheckPathExists = true, bool SupportMultiDottedExtensions = true, bool ValidateNames = true)
        {
            using SaveFileDialog SFD = new ()
            {
                Title = Title,
                FileName = FileName,
                CheckFileExists = CheckFileExists,
                CheckPathExists = CheckPathExists,
                Filter = Filter,
                RestoreDirectory = RestoreDirectory,
                SupportMultiDottedExtensions = SupportMultiDottedExtensions,
                ValidateNames = ValidateNames,
            };

            return SFD;
        }
    }
}
