using Godot;
using System;

public class Enemy : Node2D
{
    [Export]
    private int health = 25;
    private Label label;

    public override void _Ready()
    {
        label = GetNode<Label>("HPLabel");
    }

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            label.Text = health.ToString() + "HP";
        }
    }
}
