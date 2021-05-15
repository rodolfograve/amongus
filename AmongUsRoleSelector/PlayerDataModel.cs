namespace AmongUsRoleSelector
{
    public class PlayerDataModel
    {
        public PlayerDataModel(string name)
        {
            PlayerName = name;
        }

        public string PlayerName { get; private set; }
        public bool IsImpostor { get; private set; }
        public string Role => IsImpostor ? "Impostor!" : "Crewmate";
        public int ClickCount { get; private set; } = 0;
        public string RoleVisibility => ClickCount == 1 ? "visible" : "hidden";
        public bool CheatingDetected => ClickCount > 2;
        public string ButtonClass => CheatingDetected ? "btn-warning" : ClickCount == 2 ? "btn-success" : "btn-info";

        public void Reset()
        {
            IsImpostor = false;
            ClickCount = 0;
        }

        public void SetImpostor() => IsImpostor = true;

        public void OnClick() => ClickCount++;
    }
}
