using Godot;

namespace tdstopdownshooter.Player;

public partial class MovementHandler : Node
{
    private Node2D _parent;
    public override void _Ready()
    {
        _parent = GetParent<Node2D>();
        if (_parent == null)
        {
            GD.PushError("Parent node not found.");
        }

        Input.MouseMode = Input.MouseModeEnum.Hidden;

    }
   
    public override void _Process(double delta)
    {
        if (_parent == null)
            return;
        
        
        var mouse = GetViewport().GetMousePosition();
        _parent.Position = mouse;
    }
    
}
