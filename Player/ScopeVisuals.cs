using Godot;
using System;
using tdstopdownshooter.Player;

public partial class ScopeVisuals : Node
{
    [Export] public HurtHandler HurtHandler;
    [Export] public Node2D Scope;

    private Color _targetColor;

    public override void _Process(double delta)
    {
        if (HurtHandler.CanShoot)
        {
            _targetColor = Colors.White;
        }
        else
        {
            _targetColor = new Color(1, 1, 1, 0.5f);
        }

        Scope.Modulate = Scope.Modulate.Lerp(_targetColor, (float)(delta * 15));
    }
}
