using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using HarmonyVultrCli.Menu;
using HarmonyVultrCli.Menu.Main;

namespace HarmonyVultrCli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Installation.Init();
            // Successful so clear 
            Console.Clear();

            MenuBuilder.RunMainMenu();

        }
    }
}
