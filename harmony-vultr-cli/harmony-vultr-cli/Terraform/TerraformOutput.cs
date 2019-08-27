using System;
using System.Diagnostics;

namespace HarmonyVultrCli.Terraform
{
    public static class TerraformOutput
    {
        public static string GetMainnet()
        {
            return Get(("mainnet-ips"));
        }
        public static string GetPangaea()
        {
            return Get(("pangaea-ips"));
        }
        private static string Get(string key)
        {
            try
            {

                var myProcess = new Process
                {
                    StartInfo =
                    {
                        FileName = "terraform",
                        UseShellExecute = false,
                        Arguments = $"output -state=data/state/harmony.tfstate -json {key}",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    }
                };
                myProcess.Start();

                var ip = myProcess.StandardOutput.ReadToEnd();
                myProcess.WaitForExit();
                return ip.Replace("[", string.Empty).Replace("]", string.Empty).Replace("\"", string.Empty).Trim();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                return string.Empty;
            }
        }
    }
}
