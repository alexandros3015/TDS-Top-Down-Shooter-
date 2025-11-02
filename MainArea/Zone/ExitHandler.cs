using Godot;

namespace tdstopdownshooter.MainArea.Zone;
public partial class ExitHandler : Node
{
    public override void _Input(InputEvent @event)
    {
        if (!Input.IsActionJustPressed("Exit")) return;
        Global.Global.Save();
        GetTree().ChangeSceneToFile("res://MainMenu/MainMenu.tscn");
        Input.MouseMode = Input.MouseModeEnum.Visible;
    }
}
