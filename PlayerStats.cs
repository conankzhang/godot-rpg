using Godot;
using System;

public class PlayerStats : Node
{
    [Signal]
    private delegate void HealthChanged(int health);

    [Signal]
    private delegate void ActionPointsChanged(int actionPoints);

    [Signal]
    private delegate void MagicPointsChanged(int magicPoints);

    [Signal]
    private delegate void TurnEnded();

    [Export]
    private int maxHealth = 25;
    private int currentHealth;

    [Export]
    private int maxActionPoints = 3;
    private int currentActionPoints;

    [Export]
    private int maxMagicPoints = 10;
    private int currentMagicPoints;

    public int CurrentHealth
    {
        get => currentHealth;
        set
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
            EmitSignal("HealthChanged", currentHealth);
        }
    }
    public int CurrentActionPoints
    {
        get => currentActionPoints;
        set
        {
            currentActionPoints = Mathf.Clamp(value, 0, MaxActionPoints);
            EmitSignal("ActionPointsChanged", currentActionPoints);

            if(currentActionPoints == 0)
            {
                EmitSignal("TurnEnded");
            }
        }
    }
    public int CurrentMagicPoints
    {
        get => currentMagicPoints;
        set
        {
            currentMagicPoints = Mathf.Clamp(value, 0, maxMagicPoints);
            EmitSignal("MagicPointsChanged", currentMagicPoints);
        }
    }

    public int MaxActionPoints { get => maxActionPoints; }

    public override void _Ready()
    {
        CurrentHealth = maxHealth;
        CurrentActionPoints = MaxActionPoints;
    }
}
