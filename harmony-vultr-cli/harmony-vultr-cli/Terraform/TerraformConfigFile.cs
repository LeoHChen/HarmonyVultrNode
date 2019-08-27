using System.Text;

namespace HarmonyVultrCli.Terraform
{
    public static class TerraformConfigFile
    {
        private const string FileName = "/harmony/data/terraform.tfvars";

        public static string GetValue(string key)
        {
            string line;
            using var reader = new System.IO.StreamReader(FileName);
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(key))
                {
                    return line.Split('=')[1].Trim();
                }
            }

            return string.Empty;
        }

        public static bool SetValue(string key, string value)
        {
            StringBuilder sbText = new StringBuilder();
            string line;
            using var reader = new System.IO.StreamReader(FileName);
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(key))
                {
                    //possibly better to do this in a loop
                    sbText.AppendLine($"{key} = \"{value}\"");
                }
                else
                {
                    sbText.AppendLine(line);
                }
            }
            reader.Close();
            using (var writer = new System.IO.StreamWriter(FileName))
            {
                writer.Write(sbText.ToString());
            }

            return true;
        }


    }
}
