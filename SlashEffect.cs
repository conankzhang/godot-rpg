using Godot;
using System;

public class SlashEffect : Node2D
{
    private void _on_AnimationPlayer_animation_finished(String animName)
    {
        QueueFree();
    }
}
