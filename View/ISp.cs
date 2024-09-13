using System;

namespace View
{
    public interface ISp
    {
        void Validate();
        ValidationMode ValidationMode { get; set; }
        string ValidationMessage { get; set; }
    }

    public enum ValidationMode
    {
        None,
        NullOrEmpty,
        Exist,
        NullOrEmptyAndExist,
        SelectedIndex,
        Digit,
        NullOrEmptyAndDigit
    }

    public static class Validator
    {
        public static void ExceptionThrow(string _VMessage)
        {
            if (!string.IsNullOrEmpty(_VMessage))
                throw new InvalidOperationException(_VMessage);
            else
                throw new InvalidOperationException();
        }
    }
}
