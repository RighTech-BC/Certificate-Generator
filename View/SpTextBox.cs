using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace View
{
    public class SpTextBox : TextBox, ISp
    {
        public SpTextBox()
        {
            this.KeyPress += InputChecking;
        }

        public void Validate()
        {
            switch (_VM)
            {
                case ValidationMode.None:
                    break;

                case ValidationMode.NullOrEmpty:
                    if (string.IsNullOrEmpty(this.Text))
                        Validator.ExceptionThrow(_VMessage);
                    break;

                case ValidationMode.Exist:
                    if (!File.Exists(this.Text))
                        Validator.ExceptionThrow(_VMessage);
                    break;

                case ValidationMode.NullOrEmptyAndExist:
                    if (string.IsNullOrEmpty(this.Text) || !File.Exists(this.Text))
                        Validator.ExceptionThrow(_VMessage);
                    break;

                case ValidationMode.Digit:
                    if (!this.Text.All(char.IsDigit))
                        Validator.ExceptionThrow(_VMessage);
                    break;

                case ValidationMode.NullOrEmptyAndDigit:
                    if (string.IsNullOrEmpty(this.Text) || !this.Text.All(char.IsDigit))
                        Validator.ExceptionThrow(_VMessage);
                    break;

                default:
                    throw new InvalidOperationException("Selected validation mode is not supported for this control!");
            }
        }

        private ValidationMode _VM;
        public ValidationMode ValidationMode
        {
            get => _VM;
            set
            {
                _VM = value;
            }
        }

        private string _VMessage = string.Empty;
        public string ValidationMessage
        {
            get => _VMessage;
            set
            {
                _VMessage = value;
            }
        }

        private void InputChecking(object sender, KeyPressEventArgs e)
        {
            if (this.TextLength >= _MaxChar)
            {
                if (this.SelectionLength > 0)
                    return;

                if (e.KeyChar != (char)8)
                    e.Handled = true;

                return;
            }

            if (_IsNumeric)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private bool _IsNumeric = false;
        public bool Is_Numeric
        {
            get => _IsNumeric;
            set
            {
                _IsNumeric = value;
            }
        }

        private int _MaxChar = 1000;
        public int MaxChar
        {
            get => _MaxChar;
            set
            {
                _MaxChar = value;
            }
        }
    }
}
