namespace tdstopdownshooter.Enemy.EnemySpeedy;
public partial class EnemySpeedy : EnemyBasic.EnemyBasic
{
    public override void _Ready()
    {
        
        Speed = 120f;
        BaseHealth = 50;
        base._Ready();
    }
    
}
