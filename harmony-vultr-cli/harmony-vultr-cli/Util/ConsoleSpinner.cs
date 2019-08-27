using System;
using System.Collections.Generic;
using System.Text;

namespace HarmonyVultrCli.Util
{
    public class ConsoleSpiner
    {
        int counter;

        public ConsoleSpiner()
        {
            counter = 0;
        }

        public void Turn(string message)
        {
            counter++;
            switch (counter % 4)
            {
                case 0:
                    Console.Write($"[/] {message}");
                    break;
                case 1:
                    Console.Write($"[-] {message}");
                    break;
                case 2:
                    Console.Write($"[\\] {message}");
                    break;
                case 3:
                    Console.Write($"[|] {message}");
                    break;
            }

            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
}