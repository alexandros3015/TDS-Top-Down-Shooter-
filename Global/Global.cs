using Godot;

namespace tdstopdownshooter.Global;

public partial class Global : Node
{
    public static Global Instance { get; set; }
    public static int Difficulty = 0;
    public static long Money = 0;
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
        var saveFile = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Write);

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
        
        var saveFile = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Read);

        if (saveFile == null)
            return;

        Difficulty = (int)saveFile.GetVar();
        Money = (long)saveFile.GetVar();
        Cooldown = (float)saveFile.GetVar();
        Damage = (int)saveFile.GetVar();
        Radius = (float)saveFile.GetVar();
    }
}
