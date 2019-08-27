using System.Diagnostics;
using System.IO;
using System.Text;
using Alba.CsConsoleFormat.Fluent;
using Colorful;
using HarmonyVultrCli.Terraform;
using HarmonyVultrCli.Util;
using McMaster.Extensions.CommandLineUtils;

namespace HarmonyVultrCli
{
    public class Installation
    {
        public static void Init()
        {
            ConsoleWriter.PrintMenuHeader("Checking installation");
            EnsureDirectories();
            EnsureConfigFile();
            EnsureSshKeys();
            EnsureVultApiSetting();

            ConsoleWriter.PrintRow();
        }

        public static void EnsureVultApiSetting()
        {
            Colors.WriteLine($"[vultr_api_key] Checking Vultr Api key".Yellow());
            var value =TerraformConfigFile.GetValue("vultr_api_key");
            if (value.Length <10)
            {
                Colors.WriteLine($"[vultr_api_key] Missing Vultr Api key".Red());
                Console.WriteLine(string.Empty);
                Console.WriteLine("To be able to create the required infrastructure you need to supply an access token.");
                Console.WriteLine("Your personal token can be found here: https://my.vultr.com/settings/#settingsapi");
                Console.WriteLine("1. Click on the 'Enable the Vultr API' button ");
                Console.WriteLine("2. Locate the 'Access Control Area' to whitelist your IP or click 'Allow All IPv4?'");
                Console.WriteLine("3. Copy your Personal Access Token");

                value = Prompt.GetString("Please enter your Vultr Personal Access Token:");
                while (value.Length < 10)
                {
                    Console.WriteLine($"{value} is not valid, if unsure the key can be generated here https://my.vultr.com/settings/#settingsapi");
                    value = Prompt.GetString("Please enter your Vultr Personal Access Token:");
                }

                TerraformConfigFile.SetValue("vultr_api_key", value);
            }
            Colors.WriteLine($"[vultr_api_key] Vultr Api Key found".Green());
        }

        private static void EnsureConfigFile()
        {
            Colors.WriteLine($"[data/terraform.tfvars] Config file check".Yellow());
            if (!File.Exists("/harmony/data/terraform.tfvars"))
            {
                Colors.WriteLine($"[data/terraform.tfvars] Config file missing, creating".Red());
                File.Copy("/harmony/terraform.tfvars", "/harmony/data/terraform.tfvars");
                Colors.WriteLine($"[data/terraform.tfvars] Config file copied ".Green());
            }
            else
            {
                Colors.WriteLine($"[data/terraform.tfvars] Config file found".Green());

            }
        }

        private static void EnsureDirectories()
        {
            string[] directories = { "ssh-key", "harmony-keys", "mainnet", "pangaea", "state" };
            foreach (var dir in directories)
            {
                Colors.WriteLine($"[{dir}] Directory check".Yellow());

                if (!Directory.Exists($"/harmony/data/{dir}"))
                {
                    Colors.WriteLine($"[{dir}] Directory missing, start creating".Red());
                    var directoryInfo = Directory.CreateDirectory($"/harmony/data/{dir}");
                    if (directoryInfo.Exists)
                    {
                        Colors.WriteLine($"[{dir}] Directory created".Green());
                    }
                }
                else
                {
                    Colors.WriteLine($"[{dir}] Directory found".Green());
                }

            }
        }

        public static void EnsureSshKeys()
        {
            Colors.WriteLine($"[ssh-key] Check existence".Yellow());
            if (!File.Exists("/harmony/data/ssh-key/harmony"))
            {
                Colors.WriteLine($"[ssh-key] missing, creating".Red());
                var myProcess = new Process
                {
                    StartInfo =
                    {
                        FileName = "ssh-keygen",
                        UseShellExecute = false,
                        Arguments = "-N '' -f /harmony/data/ssh-key/harmony"
                    }
                };


                myProcess.Start();
                myProcess.WaitForExit();
                Colors.WriteLine($"[ssh-key] created".Green());
            }
            else
            {
                Colors.WriteLine($"[ssh-key] found".Green());

            }
        }

    }
}
