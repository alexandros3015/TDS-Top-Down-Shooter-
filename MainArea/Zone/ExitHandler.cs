using Godot;

namespace tdstopdownshooter.MainArea.Zone;
public partial class ExitHandler : Node
{
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed("Exit"))
        {
            Global.Save();
            Input.MouseMode = Input.MouseModeEnum.Visible;
            GetTree().ChangeSceneToFile("res://MainMenu/MainMenu.tscn");
        }
        
        else if (Input.IsActionJustPressed("Shop"))
        {
            Global.Save();
            Input.MouseMode = Input.MouseModeEnum.Visible;
            GetTree().ChangeSceneToFile("res://Shop/Shop.tscn");
        }
    }
}
