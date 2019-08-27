using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using HarmonyVultrCli.Menu.Main;
using HarmonyVultrCli.Terraform;
using HarmonyVultrCli.Util;
using McMaster.Extensions.CommandLineUtils;

namespace HarmonyVultrCli.Actions.Foundation
{
    public class SetupFoundationNode : IConfigAction
    {
        public void Start()
        {
            Console.Clear();
            ConsoleWriter.PrintTitle();
            ConsoleWriter.PrintMenuHeader("Setup Foundation Node - Keys ready?");
            Console.WriteLine(string.Empty);
            Console.WriteLine("This tool mostly automate steps described here");
            Console.WriteLine("https://nodes.harmony.one/foundational-node-playbook/setting-up-your-node/vultr-setup");
            Console.WriteLine(string.Empty);
            Console.WriteLine("It's possible you already got the Harmony valid available and don't need to generate them, for example when you are migrating the Node. Then please copy them from your current node or backup.");
            Console.WriteLine(string.Empty);
            ConsoleWriter.PrintRow();
            if (Prompt.GetYesNo("Did you already generate the Harmony keys for the Node?", false))
            {
                Console.Clear();
                MigratingKey();
            }
            else
            {
                Console.Clear();
                ConsoleWriter.PrintTitle();
                ConsoleWriter.PrintMenuHeader("Setup Foundation Node - Generating keys");
                Console.WriteLine(string.Empty);
                Console.WriteLine("Since you already don't got the key we will need to generate new keys.");
                Console.WriteLine("This step will generate your new Harmony keys in the data/harmony-keys/ directory");
                Console.WriteLine(string.Empty);
                Prompt.GetString("Press any key to start the generation of the Harmony Foundation Node keys");
                GenerateHarmonyKeys();
                Console.WriteLine(string.Empty);
                Console.WriteLine("Backup the keys found in /data/harmony-keys and follow the guide here");
                Console.WriteLine("https://nodes.harmony.one/foundational-node-playbook/setting-up-your-node/vultr-setup");
                Console.WriteLine("...starting from the sentence \"Create a BLS key pair with...\" so you know what they are and what to do with them");
                Console.WriteLine(string.Empty);
                ConsoleWriter.PrintRow();
                Prompt.GetYesNo("Before proceed, confirm that you back upped your new keys and read about the email to genesis@harmony.one?", false);
            }
            //enable the foundation node
            TerraformConfigFile.SetValue("harmony_mainnet_count", "1");
            Console.Clear();
            ConsoleWriter.PrintTitle();
            ConsoleWriter.PrintMenuHeader("Setup Foundation Node - Done");
            Console.WriteLine(string.Empty);
            Console.WriteLine($"The configuration is ready, next step is to choose \"{MenuBuilder.Apply.Description}\" in the Main Menu to generate the Node." );
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
            ConsoleWriter.PrintMenuHeader("Setup Foundation Node - Migrating keys");
            Console.WriteLine(string.Empty);
            Console.WriteLine("Since you already got the keys, please copy them to the data/mainnet/ folder");
            Console.WriteLine("1. Place the ECDSA account address key in the data/mainnet/ folder, its the file starting with 'UTC.'");
            Console.WriteLine(string.Empty);
            var spinner = new ConsoleSpiner();
            while (!Directory.EnumerateFiles("/harmony/data/mainnet/", "UTC*").Any())
            {
                spinner.Turn("Waiting for ECDSA account address key to be present in the data/mainnet/ folder");
                Thread.Sleep(TimeSpan.FromMilliseconds(250));
            }

            Console.WriteLine("2. Place the BLS key in the data/mainnet/ folder, its the one which ends with '.key'");
            while (!Directory.EnumerateFiles("/harmony/data/mainnet/", "*.key").Any())
            {
                spinner.Turn("Waiting for BLS key to be present in the data/mainnet/ folder");
                Thread.Sleep(TimeSpan.FromMilliseconds(250));
            }

            Console.WriteLine("Found the keys");
        }


        public static void GenerateHarmonyKeys()
        {
            var myProcess = new Process
            {
                StartInfo =
                {
                    FileName = "/harmony/wallet-create.sh",
                    UseShellExecute = false,
                }
            };
            myProcess.Start();
            myProcess.WaitForExit();
        }
    }
}
