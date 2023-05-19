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

            Console.WriteLine("");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            string? myChose;
            myChose = Console.ReadLine();

            switch (myChose)
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