using Godot;
using System;

public class HealActionButton : ActionButton
{
    protected override void _on_pressed()
    {
        Node currentScene = GetTree().CurrentScene;
        PlayerStats playerStats = (PlayerStats)currentScene.FindNode("PlayerStats");
        if(playerStats != null)
        {
            if(playerStats.CurrentMagicPoints > 8)
            {
                playerStats.CurrentHealth += 5;
                playerStats.CurrentMagicPoints -= 8;
                playerStats.CurrentActionPoints -= 1;
            }
        }
    }
}
