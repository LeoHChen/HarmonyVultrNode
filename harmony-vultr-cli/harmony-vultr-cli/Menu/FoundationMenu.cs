using System;
using System.Collections.Generic;
using System.Diagnostics;
using HarmonyVultrCli.Actions;
using HarmonyVultrCli.Actions.Foundation;
using HarmonyVultrCli.Menu.Main;
using HarmonyVultrCli.Terraform;

namespace HarmonyVultrCli.Menu
{
    public class FoundationMenu
    {
        static readonly FoundationMenu Instance = new FoundationMenu();

        private static readonly IMenuOption Setup = new MenuOption
        {
            Weight = 1,
            Code = "foundation-setup",
            Description = "Setup Foundation Node",
            Action = new SetupFoundationNode()
        };

        private static readonly IMenuOption Login = new MenuOption
        {
            Weight = 1,
            Code = "login-foundation",
            Description = "Login to your Foundation Node",
            Action = new LoginFoundationAction()
        };
        private FoundationMenu()
        {
        }


        public static FoundationMenu GetInstance()
        {
            return Instance;
        }

        public List<IMenuOption> GetMainMenu()
        {
            var currentIp = TerraformOutput.GetMainnet();
            if (string.IsNullOrEmpty(currentIp))
            {
                return new List<IMenuOption> { Setup };
            }

            Login.Description = $"Login to your Foundation Node [{currentIp}]";
            return new List<IMenuOption> { Login };

        }
    }
}
