using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using HarmonyVultrCli.Menu;
using HarmonyVultrCli.Menu.Main;
using HarmonyVultrCli.Util;
using McMaster.Extensions.CommandLineUtils;

namespace HarmonyVultrCli.Actions
{
    public class TerraformDestroyAction : IConfigAction
    {
        public void Start()
        {
            Console.Clear();
            ConsoleWriter.PrintTitle();
            ConsoleWriter.PrintMenuHeader("Destroy all Vultr Infrastructure");
            Console.WriteLine(string.Empty);
            if (!Prompt.GetYesNo("This will destroy all your nodes, are you sure?", false)) return;

            var myProcess = new Process
            {
                StartInfo =
                {
                    FileName = "/harmony/terraform-destroy.sh",
                    UseShellExecute = false,
                }
            };
            myProcess.Start();
            myProcess.WaitForExit();
            ConsoleWriter.PrintRow();
            Prompt.GetString("Press any key to return the the Main menu");

        }

    }
}
