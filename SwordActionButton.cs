using Godot;
using System;

public class SwordActionButton : ActionButton
{
    private PackedScene slashEffectScene;
    public override void _Ready()
    {
        slashEffectScene = GD.Load<PackedScene>("res://SlashEffect.tscn");
    }

    protected override void _on_pressed()
    {
        Node currentScene = GetTree().CurrentScene;
        Enemy enemy = (Enemy)currentScene.FindNode("Enemy");
        PlayerStats playerStats = (PlayerStats)currentScene.FindNode("PlayerStats");
        if(enemy != null && playerStats != null)
        {
            CreateSlashEffect(enemy.Position);
            enemy.TakeDamage(4);
            playerStats.CurrentMagicPoints += 2;
            playerStats.CurrentActionPoints -= 1;
        }
    }

    private void CreateSlashEffect(Vector2 position)
    {
        Node2D slashEffect = slashEffectScene.Instance() as Node2D;
        GetTree().CurrentScene.AddChild(slashEffect);
        slashEffect.Position = position;
    }
}
