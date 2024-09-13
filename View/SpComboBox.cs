using System;
using System.Windows.Forms;

namespace View
{
    public class SpComboBox : ComboBox, ISp
    {
        public void Validate()
        {
            switch (_VM)
            {
                case ValidationMode.None:
                    break;

                case ValidationMode.SelectedIndex:
                    if (this.SelectedIndex < 0)
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
    }
}
