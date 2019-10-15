using Godot;
using System;

public class StatsPanel : Panel
{
    private Label healthLabel;
    private Label actionPointsLabel;
    private Label magicPointsLabel;

    public override void _Ready()
    {
        healthLabel = GetNode<Label>("StatsContainer/Health");
        actionPointsLabel = GetNode<Label>("StatsContainer/ActionPoints");
        magicPointsLabel = GetNode<Label>("StatsContainer/MagicPoints");
    }

    private void _on_PlayerStats_HealthChanged(int health)
    {
        if(healthLabel != null)
        {
            healthLabel.Text = "HP\n" + health.ToString();
        }
    }

    private void _on_PlayerStats_ActionPointsChanged(int actionPoints)
    {
        if(actionPointsLabel != null)
        {
            actionPointsLabel.Text = "AP\n" + actionPoints.ToString();
        }
    }

    private void _on_PlayerStats_MagicPointsChanged(int magicPoints)
    {
        if(magicPointsLabel != null)
        {
            magicPointsLabel.Text = "MP\n" + magicPoints.ToString();
        }
    }
}
