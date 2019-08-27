using System;
using System.Collections.Generic;
using System.Linq;
using Alba.CsConsoleFormat.Fluent;
using HarmonyVultrCli.Actions;
using HarmonyVultrCli.Util;
using McMaster.Extensions.CommandLineUtils;

namespace HarmonyVultrCli.Menu.Main
{



    public static class MenuBuilder
    {
        public static readonly IMenuOption Apply = new MenuOption
        {
            Weight = 20000,
            Code = "vultr-apply",
            Description = "Apply changes to Vultr",
            Action = new TerraformApplyAction()
        };

        private static readonly IMenuOption Destroy = new MenuOption
        {
            Weight = 20010,
            Code = "vultr-destroy",
            Description = "Destroy all nodes",
            Action = new TerraformDestroyAction()
        };

        private static readonly IMenuOption Exit = new MenuOption
        {
            Weight = int.MaxValue,
            Code = "exit",
            Description = "Exit",
            Action = null
        };

        private static readonly IMenuOption ApiKey = new MenuOption
        {
            RowSpace = 1,
            Weight = 20020,
            Code = "vultr-api",
            Description = "Change Vultr Api Key",
            Action = new ChangeVultrApiAction()
        };

        public static void RunMainMenu(string errorMessage = "")
        {
           
            var mainMenu = PangaeaMenu.GetInstance().GetMainMenu();
            mainMenu.Add(Apply);
            mainMenu.Add(Destroy);
            mainMenu.Add(Exit);
            mainMenu.Add(ApiKey);
            mainMenu.AddRange(FoundationMenu.GetInstance().GetMainMenu());

            var chosen = Build("Harmony Vultr Main-menu", mainMenu, errorMessage);
            if (chosen == null)
            {
                Console.Clear();
                RunMainMenu("Invalid option selected, please select an valid option");
            }

            if (chosen?.Action != null)
            {
                chosen.Action.Start();
                RunMainMenu("");
            }
        }
        public static IMenuOption Build(string header, List<IMenuOption> options, string errorMessage = "")
        {
            Console.Clear();
            ConsoleWriter.PrintTitle();
            ConsoleWriter.PrintMenuHeader(header);
            Console.WriteLine();
            var dicMenu = options.OrderBy(m => m.Weight).Select((val, index) => new { Index = index + 1, Value = val })
                .ToDictionary(i => i.Index, i => i.Value);
            foreach (var option in dicMenu)
            {
                for (var i = 0; i < option.Value.RowSpace; i++)
                {
                    Console.WriteLine(string.Empty);

                }
                ConsoleWriter.PrintMiddleText($"{option.Key}. {option.Value.Description}");
            }
            ConsoleWriter.PrintRow();
            if (!string.Empty.Equals(errorMessage))
            {
                Console.WriteLine(errorMessage.Red());
            }
            ConsoleWriter.PrintRow();
            dicMenu.TryGetValue(Prompt.GetInt("Choose your option:"), out var menu);
            return menu;
        }



    }
}
