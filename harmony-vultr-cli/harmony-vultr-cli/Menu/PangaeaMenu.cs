using System.Collections.Generic;
using HarmonyVultrCli.Actions;
using HarmonyVultrCli.Actions.Foundation;
using HarmonyVultrCli.Actions.Pangean;
using HarmonyVultrCli.Menu.Main;
using HarmonyVultrCli.Terraform;

namespace HarmonyVultrCli.Menu
{
    public  class PangaeaMenu
    {

        private static readonly IMenuOption Setup = new MenuOption
        {
            Weight = 1000,
            Code = "setup-pangaea",
            Description = "Setup Pangaea Node",
            Action = new SetupPangaeanNode()
        };

        private static readonly IMenuOption Login = new MenuOption
        {
            Weight = 1,
            Code = "login-pangaea",
            Description = "Login to your Pangaean Node",
            Action = new LoginPangaeaAction()
        };

        private PangaeaMenu()
        {

        }
        static readonly PangaeaMenu Instance = new PangaeaMenu();
        public static PangaeaMenu GetInstance()
        {
            return Instance;
        }


        public List<IMenuOption> GetMainMenu()
        {
            var currentIp = TerraformOutput.GetPangaea();
            if (string.IsNullOrEmpty(currentIp))
            {
                return new List<IMenuOption> { Setup };
            }

            Login.Description = $"Login to your Pangaea Node [{currentIp}]";
            return new List<IMenuOption> { Login };

        }
    }
}
