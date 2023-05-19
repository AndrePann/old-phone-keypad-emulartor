using System.Text.RegularExpressions;

namespace OldPhone.Keypad.Emulator
{
    /// <summary>
    /// OldPhone implements the logik to emulate key pad events to pars input to result output.
    /// </summary>
    public static class OldPhone
    {
        private static Dictionary<string, string> _keyPadDictionary;

        /// <summary>
        /// Input processing
        /// </summary>
        /// <param name="input">input data</param>
        /// <returns>parsed input to result output or a user info if the input is invalid or an exception occured</returns>
        public static string OldPhonePad(string input)
        {
            string output;

            try
            {
                InitKeyPadDictionary();

                var regExRule = @"(^([0-9 \* \#  ]+[\#(1,1)])$)";

                var isValid = ValidationInput(input, regExRule, out output);

                if (isValid)
                {
                    var inputData = new InputData
                    {
                        LastKey = "-1",
                        CurrentKey = "",
                        KeyModifier = 1,
                        OriginInput = "",
                        ParsedInput = ""
                    };

                    foreach (char inputKey in input)
                    {
                        inputData.CurrentKey = inputKey.ToString();

                        inputData = ProcessInputKey(inputData);
                    }

                    output = inputData.ParsedInput;
                }
            }
            catch (Exception exp)
            {
                output = $"Error: Unexpected exception - {exp.Message}";
            }

            return output;
        }

        /// <summary>
        /// Key pad dictionary to map input key to the result output depending on a key modifier.
        /// </summary>
        private static void InitKeyPadDictionary()
        {
            _keyPadDictionary = new Dictionary<string, string>();
            _keyPadDictionary.Add("0", "0 ");
            _keyPadDictionary.Add("1", "&'()*,-./1");
            _keyPadDictionary.Add("2", "ABC2");
            _keyPadDictionary.Add("3", "DEF3");
            _keyPadDictionary.Add("4", "GHI4");
            _keyPadDictionary.Add("5", "JKL5");
            _keyPadDictionary.Add("6", "MNO6");
            _keyPadDictionary.Add("7", "PQRS7");
            _keyPadDictionary.Add("8", "TUV8");
            _keyPadDictionary.Add("9", "WXYZ9");
        }

        /// <summary>
        /// Input validation for valid characters.
        /// </summary>
        /// <param name="input">input data</param>
        /// <param name="regExRule">reg expression rule for the validating</param>
        /// <param name="validationResult">the valid input or a user info if the input is invalid or an exception occured</param>
        /// <returns></returns>
        private static bool ValidationInput(string input, string regExRule, out string validationResult)
        {
            bool isValid = false;

            try
            {
                var match = Regex.Match(input, regExRule);

                if (match.Success)
                {
                    validationResult = input;
                    isValid = true;
                }
                else
                {
                    validationResult = $"Error: Please check the input <{input}> for valid characters, digits, spaces, asterisks and routes.\n  Each input must end with a rout! ";
                }
            }
            catch (Exception exp)
            {
                validationResult = $"Error: Unexpected exception - {exp.Message}";
            }                

            return isValid;
        }

        private static InputData ProcessInputKey(InputData inputData)
        {
            return inputData;
        }

        private static void ProcessSpaceKey()
        {

        }

        private static void ProcessBackspaceKey()
        {

        }

        private static void ProcessSendKey()
        {

        }

        private static void PrepareOutputData()
        {

        }
    }
}
