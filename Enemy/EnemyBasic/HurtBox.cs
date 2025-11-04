using Godot;
using tdstopdownshooter.Player;

namespace tdstopdownshooter.Enemy.EnemyBasic;

public partial class HurtBox : Area2D
{

    private HealthHandler _healthHandler;
    public override void _Ready()
    {
        _healthHandler = GetNode<HealthHandler>("../HealthHandler");
        if (_healthHandler == null)
            GD.PushError("HealthHandler not found");
        
        AreaEntered += OnAreaEntered;
    }

    private void OnAreaEntered(Area2D area)
    {
        if (area is not HurtHandler handler) return;
        if (handler.CollisionShape.Disabled == true) return;
        _healthHandler.TakeDamage(Global.Damage);
    }
}
