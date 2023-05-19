// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace OldPhone.Keypad.Emulator.Demo
{
    class Programm
    {
        /// <summary>
        /// Main menu for interactive demo
        /// </summary>
        static void Main()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Title = "Old Phone Emulator Demo";
            Console.WriteLine("\n  Welcome to the 'Old Phone Emulator' demo.");
            Console.ResetColor();

            Console.WriteLine("\n  A C# library as an emulator for an old phone keypad to translate the input string of digits, \n  spaces, asterisks, or routes into a resulting output for sending over a phone.\n\n");

            Console.WriteLine("  Option 1. Sample input for selection");
            Console.WriteLine("  Option 2. User input for test");
            Console.WriteLine("  Option 3. For exit...");

            string? mySelection;
            mySelection = Console.ReadLine();

            switch (mySelection)
            {
                case "1":
                    SampleInput();
                    break;
                case "2":
                    UserInput();
                    break;
                case "3":
                    Exit();
                    break;
                default:
                    Main();
                    break;
            }
        }


        static void SampleInput()
        {

        }

        static void UserInput()
        {

        }

        static void Exit()
        {

        }
    }
}