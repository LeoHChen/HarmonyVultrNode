using System;
using System.Collections.Generic;
using System.Text;
using Alba.CsConsoleFormat.Fluent;
using HarmonyVultrCli.Menu;
using HarmonyVultrCli.Menu.Main;
using HarmonyVultrCli.Terraform;
using HarmonyVultrCli.Util;
using McMaster.Extensions.CommandLineUtils;

namespace HarmonyVultrCli.Actions
{
    public class ChangeVultrApiAction : IConfigAction
    {
        public void Start()
        {
            Console.Clear();
            ConsoleWriter.PrintTitle();
            ConsoleWriter.PrintMenuHeader("Change Vultr Api Key");
            Console.WriteLine(string.Empty);
            Console.WriteLine("To be able to create the required infrastructure you need to supply an access token.");
            Console.WriteLine($"Your current Vultr Api Key = {TerraformConfigFile.GetValue("vultr_api_key")}");
            Console.WriteLine(string.Empty);
            Console.WriteLine("Your personal token can be found here: https://my.vultr.com/settings/#settingsapi");
            Console.WriteLine("1. Click on the 'Enable the Vultr API' button ");
            Console.WriteLine("2. Locate the 'Access Control Area' to whitelist your IP or click 'Allow All IPv4?'");
            Console.WriteLine("3. Copy your Personal Access Token");
            Console.WriteLine(string.Empty);


            ConsoleWriter.PrintRow();

            var value = Prompt.GetString("Please enter your Vultr Personal Access Token:");
            while (value.Length < 10)
            {
                Console.WriteLine($"{value} is not valid, if unsure the key can be generated here https://my.vultr.com/settings/#settingsapi");
                value = Prompt.GetString("Please enter your Vultr Personal Access Token:");
            }

            TerraformConfigFile.SetValue("vultr_api_key", value);
        
        }
}
}
