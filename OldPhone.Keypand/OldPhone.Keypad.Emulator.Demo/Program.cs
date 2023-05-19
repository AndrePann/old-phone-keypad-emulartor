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

        /// <summary>
        /// Interactive sample input 
        /// </summary>
        static void SampleInput()
        {
            string title = "Sample input for selection";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Title = "Old Phone Emulator Demo";
            Console.WriteLine("\n  Welcome to the 'Old Phone Emulator' demo.");
            Console.ResetColor();

            Console.WriteLine($"\n  {title} \n");

            Console.WriteLine("  Option 1. Example input <33#>");
            Console.WriteLine("  Option 2. Example input <227*#>");
            Console.WriteLine("  Option 3. Example input <4433555 555666#>");
            Console.WriteLine("  Option 4. Example input <8 88777444666*664#>");
            Console.WriteLine("  Option 5. Main menu");
            Console.WriteLine("  Option 6. For exit...");

            string? mySelection;
            mySelection = Console.ReadLine();

            switch (mySelection)
            {
                case "1":
                    Console.Clear();
                    Execute(title, "33#", 0);

                    break;
                case "2":
                    Console.Clear();
                    Execute(title, "227*#", 0);

                    break;
                case "3":
                    Console.Clear();
                    Execute(title, "4433555 555666#", 0);

                    break;
                case "4":
                    Console.Clear();
                    Execute(title, "8 88777444666*664#", 0);

                    break;
                case "5":
                    Main();
                    break;
                case "6":
                    Exit();
                    break;
            }
        }

        /// <summary>
        /// interactive user input
        /// </summary>
        static void UserInput()
        {
            string title = "User input for test";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Title = "Old Phone Emulator Demo";
            Console.WriteLine("\n  Welcome to the 'Old Phone Emulator' demo.");
            Console.ResetColor();

            Console.WriteLine($"\n  {title}");

            Console.WriteLine("  Option 1. New input");
            Console.WriteLine("  Option 2. Main menu");
            Console.WriteLine("  Option 3. For exit...");

            string? mySelection;
            mySelection = Console.ReadLine();

            switch (mySelection)
            {
                case "1":
                    Console.Clear();
                    Execute(title, string.Empty, 1);

                    break;
                case "2":
                    Main();
                    break;
                case "3":
                    Exit();
                    break;
            }
        }

        /// <summary>
        /// Interactive execution
        /// </summary>
        /// <param name="title">interactive section</param>
        /// <param name="sampleInput">input data</param>
        /// <param name="caller">where do we come from?</param>
        static void Execute(string title, string sampleInput, int caller)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n  {title}");
            Console.ResetColor();

            string sampleOutput;
            string? input;
            Console.ForegroundColor = ConsoleColor.Green;
            if (!string.IsNullOrEmpty(sampleInput))
            {
                input = sampleInput;
                Console.WriteLine($"\n  Input:  {input}");
            }
            else
            {
                Console.Write($"\n  Input:  ");
                input = Console.ReadLine();
            }

            if (!string.IsNullOrEmpty(input))
            {
                sampleOutput = OldPhone.OldPhonePad(input);
                if (sampleOutput.StartsWith("Error"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"  Output: {sampleOutput}");
                Console.ResetColor();
                Console.WriteLine("\n  Press any key to continue...");
            }

            Console.ReadLine();
            if (caller == 0)
            {
                SampleInput();
            }
            else
            {
                UserInput();
            }
        }

        /// <summary>
        /// Exit function
        /// </summary>
        static void Exit()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Title = "Old Phone Emulator Demo";
            Console.WriteLine("\n  Welcome to the 'Old Phone Emulator' demo.");
            Console.ResetColor();

            Console.WriteLine("\n  Thank you for using, please press any key for exit.");

            Console.Read();
        }
    }
}