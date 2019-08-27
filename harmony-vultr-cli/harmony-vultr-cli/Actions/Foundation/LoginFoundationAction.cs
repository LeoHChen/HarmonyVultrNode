using System;
using System.Diagnostics;
using HarmonyVultrCli.Menu.Main;
using HarmonyVultrCli.Terraform;
using HarmonyVultrCli.Util;

namespace HarmonyVultrCli.Actions.Foundation
{
    public class LoginFoundationAction : IConfigAction
    {
        public void Start()
        {
            Console.Clear();
            ConsoleWriter.PrintTitle();
            var currentIp = TerraformOutput.GetMainnet();

            ConsoleWriter.PrintMenuHeader($"Login to {currentIp} ");
            Console.WriteLine(string.Empty);
            var myProcess = new Process
            {
                StartInfo =
                {
                    FileName = "/harmony/login.sh",
                    Arguments = currentIp,
                    UseShellExecute = false,
                }
            };
            myProcess.Start();
            myProcess.WaitForExit();
        }
    }
}
