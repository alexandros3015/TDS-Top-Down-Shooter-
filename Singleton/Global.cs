using Godot;

public partial class Global : Node
{
    private static Global Instance { get; set; }
    public static int Difficulty;
    public static long Money;
    public static float Cooldown = 1.0f;
    public static int Damage = 10;
    public static float Radius = 50.0f;

    public override void _Ready()
    {
        if (Instance == null)
            Instance = this;
        else
            GD.PushError("Global instance already exists.");
    }

    public static void Save()
    {
        using var saveFile = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Write);

        saveFile.StoreVar(Difficulty);
        saveFile.StoreVar(Money);
        saveFile.StoreVar(Cooldown);
        saveFile.StoreVar(Damage);
        saveFile.StoreVar(Radius);
        saveFile.Close();
    }

    public static void Load()
    {
        if (!FileAccess.FileExists("user://savegame.save"))
            return;
        
        using var saveFile = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Read);

        if (saveFile == null)
            return;

        Difficulty = (int)saveFile.GetVar();
        Money = (long)saveFile.GetVar();
        Cooldown = (float)saveFile.GetVar();
        Damage = (int)saveFile.GetVar();
        Radius = (float)saveFile.GetVar();
    }
}
