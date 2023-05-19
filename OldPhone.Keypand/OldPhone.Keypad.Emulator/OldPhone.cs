using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OldPhone.Keypad.Emulator
{
    /// <summary>
    /// OldPhone implements the logik to emulate key pad events to pars input to result output.
    /// </summary>
    public static class OldPhone
    {
        private static Dictionary<string, string> keyPadDictionary;

        public static string OldPhonePad(string input)
        {
            return input;
        }

        /// <summary>
        /// Key pad dictionary to map input key to the result output depending on a key modifier.
        /// </summary>
        private static void InitKeyPadDictionary()
        {
            keyPadDictionary = new Dictionary<string, string>();
            keyPadDictionary.Add("0", "0 ");
            keyPadDictionary.Add("1", "&'()*,-./1");
            keyPadDictionary.Add("2", "ABC2");
            keyPadDictionary.Add("3", "DEF3");
            keyPadDictionary.Add("4", "GHI4");
            keyPadDictionary.Add("5", "JKL5");
            keyPadDictionary.Add("6", "MNO6");
            keyPadDictionary.Add("7", "PQRS7");
            keyPadDictionary.Add("8", "TUV8");
            keyPadDictionary.Add("9", "WXYZ9");
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

        private static void ProcessInputKey()
        {
            
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
