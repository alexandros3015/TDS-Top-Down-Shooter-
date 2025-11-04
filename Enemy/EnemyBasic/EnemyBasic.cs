using Godot;

namespace tdstopdownshooter.Enemy.EnemyBasic;
public partial class EnemyBasic : Node2D
{
    [Export] public int BaseHealth = 100;
    [Export] public float Speed = 50f;
    
    // ReSharper disable MemberCanBePrivate.Global
    protected HealthHandler Health;
    protected MovementHandler Movement;
    protected HurtBox HurtBox;
    // ReSharper restore MemberCanBePrivate.Global

    public override void _Ready()
    {
        Health = GetNodeOrNull<HealthHandler>("HealthHandler");
        Movement = GetNodeOrNull<MovementHandler>("MovementHandler");
        HurtBox = GetNodeOrNull<HurtBox>("HurtBox");

        if (Health == null || Movement == null || HurtBox == null)
        {
            GD.PushError($"Missing One Or More Components In {GetPath()}");
            return;
        }

        Health.MaximumHealth = BaseHealth;
        Health.CurrentHealth = BaseHealth;
        Movement.Speed = Speed;
        Health.UpdateProgressBar();
    }

    public virtual void OnDeath()
    {
        GD.Print($"{Name} Died.");
        Health?.Die();
    }

    public virtual void TakeDamage(int amount)
    {
        Health?.TakeDamage(amount);
    }
}
