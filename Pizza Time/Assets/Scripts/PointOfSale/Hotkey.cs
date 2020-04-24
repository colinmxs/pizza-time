using UnityEngine;
using UnityEngine.Events;

public class Hotkey
{
    public string InstructionText { get; private set; }
    public KeyCode KeyCode { get; private set; }
    public UnityAction Action { get; private set; }
    public Hotkey(string instructionText, KeyCode keyCode, UnityAction action)
    {
        InstructionText = instructionText;
        KeyCode = keyCode;
        Action = action;
    }
}