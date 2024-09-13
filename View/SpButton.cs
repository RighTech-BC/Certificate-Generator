using System;
using System.Windows.Forms;

namespace View
{
    public class SpButton : Button
    {
        private SpTextBox _Destination;
        public SpTextBox Destination
        {
            get => _Destination;
            set
            {
                if (value != null && value is not SpTextBox)
                    throw new InvalidOperationException("Only SpTextBox can be set");

                _Destination = value;
            }
        }

        private string _FileName = string.Empty;
        public string FileName
        {
            get => _FileName;
            set
            {
                _FileName = value;
            }
        }

        private string _Format = string.Empty;
        public string Format
        {
            get => _Format;
            set
            {
                _Format = value;
            }
        }
    }
}
