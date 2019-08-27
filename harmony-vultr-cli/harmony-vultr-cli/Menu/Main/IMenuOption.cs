namespace HarmonyVultrCli.Menu.Main
{
    public interface IConfigAction
    {
        void Start();
    }


    public interface IMenuOption
    {
        int RowSpace { get; set; }
        int Weight { get; set; }
        string Code { get; set; }
        string Description { get; set; }
        IConfigAction Action { get; set; }
    }

    public class MenuOption : IMenuOption
    {
        public int Weight { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public IConfigAction Action { get; set; }
        public int RowSpace { get; set; }
    }
}