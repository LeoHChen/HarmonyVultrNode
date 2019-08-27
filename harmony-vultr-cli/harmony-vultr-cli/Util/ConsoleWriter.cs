using System;

namespace HarmonyVultrCli.Util
{
    public static class ConsoleWriter
    {
        public static void PrintRow()
        {
            Console.WriteLine(string.Empty.PadRight(Console.WindowWidth,'='));
        }

        public static void PrintMenuHeader(string input)
        {
            PrintRow();
            PrintMiddleText(input);
            PrintRow();
        }

        public static void PrintMiddleText(string input)
        {
            var c = ' ';
            var maxLength = Console.WindowWidth;
            var userText = " " + input.Substring(0, Math.Min(maxLength - 4, input.Length)) + " ";
            var displayText = userText.PadLeft((maxLength / 2) + (userText.Length / 2) + (userText.Length % 2), c);
            Console.WriteLine(displayText.PadRight(maxLength, c));
        }

        public static void PrintTitle()
        {
            var title = @" _    _                                         __      __    _ _           _____ _ _            _   
| |  | |                                        \ \    / /   | | |         / ____| (_)          | |  
| |__| | __ _ _ __ _ __ ___   ___  _ __  _   _   \ \  / /   _| | |_ _ __  | |    | |_  ___ _ __ | |_ 
|  __  |/ _` | '__| '_ ` _ \ / _ \| '_ \| | | |   \ \/ / | | | | __| '__| | |    | | |/ _ \ '_ \| __|
| |  | | (_| | |  | | | | | | (_) | | | | |_| |    \  /| |_| | | |_| |    | |____| | |  __/ | | | |_ 
|_|  |_|\__,_|_|  |_| |_| |_|\___/|_| |_|\__, |     \/  \__,_|_|\__|_|     \_____|_|_|\___|_| |_|\__| 0.1
                                          __/ |                                                      
                                         |___/                                                       
";

            Console.WriteLine(title);
        }
    }
}
