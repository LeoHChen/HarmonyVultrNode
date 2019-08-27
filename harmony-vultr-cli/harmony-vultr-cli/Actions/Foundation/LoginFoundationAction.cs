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
            Console.WriteLine("If this is the first time you login then follow this link:");
            Console.WriteLine("https://nodes.harmony.one/foundational-node-playbook/setting-up-your-node/vultr-setup#step-3-launching-your-node");
            Console.WriteLine(string.Empty);

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
