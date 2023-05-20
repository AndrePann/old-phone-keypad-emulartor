using System.Text.RegularExpressions;

namespace OldPhone.Keypad.Emulator
{
    /// <summary>
    /// OldPhone implements the logik to emulate key pad events to pars input to result output.
    /// </summary>
    public static class OldPhone
    {
        private static Dictionary<string, string> _keyPadDictionary = new();

        /// <summary>
        /// Input processing
        /// </summary>
        /// <param name="input">input string</param>
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
        /// <param name="input">input string</param>
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

        /// <summary>
        /// Process input data depending on current key
        /// </summary>
        /// <param name="inputData">input data object</param>
        /// <returns>processed input data object</returns>
        private static InputData ProcessInputKey(InputData inputData)
        {
            InputData processedInput = inputData;

            try
            {
                switch (inputData.CurrentKey)
                {
                    case " ":
                        processedInput = ProcessSpaceKey(inputData);
                        break;
                    case "*":
                        processedInput = ProcessBackspaceKey(inputData);
                        break;
                    case "#":
                        processedInput = ProcessSendKey(inputData);
                        break;
                    default:
                        processedInput = PrepareOutputData(inputData);
                        break;
                }
            }
            catch (Exception exp)
            {
                throw new InvalidOperationException($"Unexpected exception in {nameof(ProcessInputKey)}: ", exp);
            }

            return processedInput;
        }

        /// <summary>
        /// Process last key if current key is space key
        /// </summary>
        /// <param name="inputData">input data object</param>
        /// <returns>processed input data object</returns>
        private static InputData ProcessSpaceKey(InputData inputData)
        {
            try
            {
                if(inputData.LastKey != " ")
                {
                    var keySequenceLength   = _keyPadDictionary[inputData.LastKey].Length;
                    var mod                 = inputData.KeyModifier % keySequenceLength;
                    var keySequencePosition = mod == 0 ? inputData.KeyModifier : mod;
                    var parsedKey           = _keyPadDictionary[inputData.LastKey].Substring(keySequencePosition - 1, 1);
                    inputData.ParsedInput   += parsedKey;
                    inputData.KeyModifier   = 1;
                }
                inputData.LastKey = inputData.CurrentKey;
            }
            catch (Exception exp)
            {
                throw new InvalidOperationException($"Unexpected exception in {nameof(ProcessSpaceKey)}: ", exp);
            }

            return inputData;
        }

        /// <summary>
        /// Process backspace key to remove last key
        /// </summary>
        /// <param name="inputData">input data object</param>
        /// <returns>processed input data object</returns>
        private static InputData ProcessBackspaceKey(InputData inputData)
        {
            try
            {
                var truncatedOriginInput = inputData.OriginInput.Remove(inputData.OriginInput.Length - 1, 1);
                inputData.OriginInput    = truncatedOriginInput;
                if (!string.IsNullOrEmpty(truncatedOriginInput))
                {
                    inputData.LastKey        = inputData.OriginInput[inputData.OriginInput.Length - 1].ToString();
                    inputData.KeyModifier    -= 1;
                }
                else
                {
                    inputData.LastKey = "-1";
                    inputData.KeyModifier = 1;
                }

                if(inputData.ParsedInput.Length > inputData.OriginInput.Length)
                {
                    var truncatedParsedInput = inputData.ParsedInput.Remove(inputData.ParsedInput.Length - 1, 1);
                    inputData.ParsedInput = truncatedParsedInput;
                }
            }
            catch (Exception exp)
            {
                throw new InvalidOperationException($"Unexpected exception in {nameof(ProcessBackspaceKey)}: ", exp);
            }

            return inputData;
        }

        /// <summary>
        /// Process send key
        /// </summary>
        /// <param name="inputData">input data object</param>
        /// <returns>processed input data object</returns>
        private static InputData ProcessSendKey(InputData inputData)
        {
            try
            {
                if(inputData.KeyModifier != 0)
                {
                    ProcessSpaceKey(inputData);
                }
            }
            catch (Exception exp)
            {
                throw new InvalidOperationException($"Unexpected exception in {nameof(ProcessSendKey)}: ", exp);
            }

            return inputData;
        }

        /// <summary>
        /// Prepare output data
        /// - init lastKey in first execution
        /// - memories current key in originInput
        /// - increment keyModifire if lastKey equalse current key
        /// </summary>
        /// <param name="inputData">input data object</param>
        /// <returns>processed input data object</returns>
        private static InputData PrepareOutputData(InputData inputData)
        {
            try
            {
                inputData.OriginInput += inputData.CurrentKey;

                if(inputData.LastKey.Equals(inputData.CurrentKey))
                {
                    inputData.KeyModifier += 1;
                }
                else
                {
                    if(inputData.LastKey == "-1")
                    {
                        inputData.LastKey = inputData.CurrentKey;
                    }
                    else
                    {
                        ProcessSpaceKey(inputData);
                    }
                }
            }
            catch (Exception exp)
            {
                throw new InvalidOperationException($"Unexpected exception in {nameof(PrepareOutputData)}: ", exp);
            }

            return inputData;
        }
    }
}
