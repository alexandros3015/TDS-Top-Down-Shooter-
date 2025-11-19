using Godot;

namespace  tdstopdownshooter.Shop;
public partial class Leave : Button
{
    public override void _Ready()
    {
        Pressed += OnPressed;
    }
    
    private void OnPressed()
    {
        Global.Save();
        GetTree().ChangeSceneToFile("res://MainArea/Zone/Zone.tscn");
    }

    public override void _Input(InputEvent @event)
    {
        if (!Input.IsActionJustPressed("Shop")) return;
        OnPressed();
    }
}
