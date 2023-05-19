using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private static void InitKeyPadDictionary()
        {

        }

        private static bool ValidationInput(string input, string regExRule, out string validationResult)
        {
            bool isValid = false;

            validationResult = "";

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
