using Godot;
using System;

public class Enemy : Node2D
{
    [Signal]
    private delegate void TurnEnded();

    [Signal]
    private delegate void Died();

    [Export]
    private int health = 25;
    private Label label;
    private AnimationPlayer animationPlayer;
    private PlayerStats playerStats;

    public override void _Ready()
    {
        label = GetNode<Label>("HPLabel");
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    public void Attack(PlayerStats playerStats)
    {
        this.playerStats = playerStats;
        WaitToAttack(playerStats);
    }

    public void DealDamage(int damageAmount)
    {
        playerStats.CurrentHealth -= damageAmount;
    }

    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;
        if(IsDead())
        {
            EmitSignal(nameof(Died));
            QueueFree();
        }
        else
        {
            animationPlayer.Play("Shake");
        }
    }

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            label.Text = health.ToString() + " HP";
        }
    }

    private bool IsDead()
    {
        return Health <= 0;
    }

    private async void WaitToAttack(PlayerStats playerStats)
    {
        await ToSignal(GetTree().CreateTimer(0.4f), "timeout");

        animationPlayer.Play("Attack");
        await ToSignal(animationPlayer, "animation_finished");
        playerStats = null;
        EmitSignal("TurnEnded");
    }
}
