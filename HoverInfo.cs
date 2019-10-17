using Godot;
using System;

public class HoverInfo : Control
{
    [Export]
    private String description;

    private void _on_HoverInfo_mouse_entered()
    {
        Node currentScene = GetTree().CurrentScene;
        RichTextLabel textBox = currentScene.FindNode("TextBox") as RichTextLabel;
        if(textBox != null)
        {
            textBox.Text = description;
        }

    }
    private void _on_HoverInfo_mouse_exited()
    {
        Node currentScene = GetTree().CurrentScene;
        RichTextLabel textBox = currentScene.FindNode("TextBox") as RichTextLabel;
        if(textBox != null)
        {
            textBox.Text = "";
        }
    }
}
