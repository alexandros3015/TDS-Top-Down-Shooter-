using System;
using Godot;

namespace tdstopdownshooter.Enemy.EnemyBasic;

[GlobalClass]
public partial class HealthHandler : Node
{
    [Export] public int MaximumHealth = 100;
    [Export] public int CurrentHealth = 100;

    private ProgressBar _progressBar;
    
    public override void _Ready()
    {
        _progressBar = GetNode<ProgressBar>("../ProgressBar");
        _progressBar.MaxValue = MaximumHealth;
        _progressBar.Value = CurrentHealth;
    }
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        _progressBar.Value = CurrentHealth;
        
        GD.Print($"{damage} Damage Taken.");
        
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        Global.Global.Money += (int)Math.Round(50.0 * Math.Pow(5.0, 0.2 * Global.Global.Difficulty), MidpointRounding.AwayFromZero);
        Global.Global.Difficulty++;
        
        GD.Print("Enemy Died.");
        Global.Global.Save();
        
        GetParent<Node2D>().QueueFree();
    }
}