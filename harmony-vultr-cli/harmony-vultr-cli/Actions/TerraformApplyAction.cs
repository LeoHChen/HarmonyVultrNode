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
    public class TerraformApplyAction : IConfigAction
    {
        public void Start()
        {
            Console.Clear();
            ConsoleWriter.PrintTitle();
            ConsoleWriter.PrintMenuHeader("Apply changes to Vultr");
            Console.WriteLine(string.Empty);

            var myProcess = new Process
            {
                StartInfo =
                {
                    FileName = "/harmony/terraform-apply.sh",
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
