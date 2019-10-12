using Godot;
using System;

public class Enemy : Node2D
{
    [Signal]
    private delegate void Died();

    [Export]
    private int health = 25;
    private Label label;
    private AnimationPlayer animationPlayer;

    public override void _Ready()
    {
        label = GetNode<Label>("HPLabel");
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            label.Text = health.ToString() + " HP";

            if(health <= 0)
            {
                EmitSignal(nameof(Died));
                QueueFree();
            }
            else
            {
                animationPlayer.Play("Shake");
            }
        }
    }


}
