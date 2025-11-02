using Godot;

namespace tdstopdownshooter.MainMenu;

public partial class JoinGame : Button
{
    public override void _Ready()
    {
        Pressed += JoinGameOnPressed;
    }

    private void JoinGameOnPressed()
    {
        Global.Global.Load();
        
        GetTree().ChangeSceneToFile("res://MainArea/Zone/Zone.tscn");
    }
}
