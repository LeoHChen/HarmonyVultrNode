using System;
using System.Diagnostics;
using HarmonyVultrCli.Menu.Main;
using HarmonyVultrCli.Terraform;
using HarmonyVultrCli.Util;

namespace HarmonyVultrCli.Actions.Pangean
{
    public class LoginPangaeaAction : IConfigAction
    {
        public void Start()
        {
            Console.Clear();
            ConsoleWriter.PrintTitle();
            var currentIp = TerraformOutput.GetMainnet();

            ConsoleWriter.PrintMenuHeader($"Login to {currentIp} ");
            Console.WriteLine("This tool mostly automate step 1 and 2 described here");
            Console.WriteLine("https://nodes.harmony.one/foundational-node-playbook/setting-up-your-node/vultr-setup");
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
