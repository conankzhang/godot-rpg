using Godot;
using System;

public abstract class ActionButton : Button
{
    protected abstract void _on_pressed();
}
