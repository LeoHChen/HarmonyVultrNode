using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using HarmonyVultrCli.Menu.Main;
using HarmonyVultrCli.Terraform;
using HarmonyVultrCli.Util;
using McMaster.Extensions.CommandLineUtils;

namespace HarmonyVultrCli.Actions.Pangean
{
    public class SetupPangaeanNode : IConfigAction
    {
        public void Start()
        {
            Console.Clear();
            ConsoleWriter.PrintTitle();
            ConsoleWriter.PrintMenuHeader("Setup Pangaea Node - Keys ready?");
            Console.WriteLine(string.Empty);
            Console.WriteLine("Its mostly automate step 1 in the tutorial described here");
            Console.WriteLine("https://docs.harmony.one/pangaea/setup-your-node-and-connect-to-pangaea/node-setup/advanced-users/vultr");
            Console.WriteLine(string.Empty);
            Console.WriteLine("You should have received an email with information about your Pangaea key.");
            Console.WriteLine(string.Empty);
            ConsoleWriter.PrintRow();
            var ignore = Prompt.GetString("Press any key to continue?");
            Console.Clear();
            MigratingKey();
            //enable the foundation node
            TerraformConfigFile.SetValue("harmony_pangaea_count", "1");
            Console.Clear();
            ConsoleWriter.PrintTitle();
            ConsoleWriter.PrintMenuHeader("Setup Pangaea Node - Done");
            Console.WriteLine(string.Empty);
            Console.WriteLine($"The configuration is ready, next step is to choose \"{MenuBuilder.Apply.Description}\" in the Main Menu to generate the Node.");
            Console.WriteLine(string.Empty);
            ConsoleWriter.PrintRow();
            Prompt.GetString("Press any key to return the the Main menu");

        }

        /// <summary>
        /// 
        /// </summary>
        private void MigratingKey()
        {
            ConsoleWriter.PrintTitle();
            ConsoleWriter.PrintMenuHeader("Setup Pangaea Node - Placing keys");
            Console.WriteLine(string.Empty);
            Console.WriteLine("You should receive a key, please unzip them and copy them to the data/pangaea/ folder");
            Console.WriteLine("1. Place the ECDSA account address key in the data/pangaea/ folder, its the file starting with 'UTC.'");
            Console.WriteLine(string.Empty);
            var spinner = new ConsoleSpiner();
            while (!Directory.EnumerateFiles("/harmony/data/pangaea/", "UTC*").Any())
            {
                spinner.Turn("Waiting for ECDSA account address key to be present in the data/pangaea/ folder");
                Thread.Sleep(TimeSpan.FromMilliseconds(250));
            }

            Console.WriteLine("2. Place the BLS key in the data/pangaea/ folder, its the one which ends with '.key'");
            while (!Directory.EnumerateFiles("/harmony/data/pangaea/", "*.key").Any())
            {
                spinner.Turn("Waiting for BLS key to be present in the data/pangaea/ folder");
                Thread.Sleep(TimeSpan.FromMilliseconds(250));
            }

            Console.WriteLine("Hurray, found the pangaea keys");
        }


    }
}
