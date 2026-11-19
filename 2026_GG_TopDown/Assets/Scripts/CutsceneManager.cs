
using UnityEngine;
using UnityEngine.InputSystem;

public class CutsceneManager : MonoBehaviour
{
    public DialogueBox dialogueBox;
    public Talk cutsceneTalk;

    private bool started = false;

    void Update()
    {
        if (started)
            return;

        bool pressE = Keyboard.current != null &&
                      Keyboard.current.eKey.wasPressedThisFrame;

        bool click = Mouse.current != null &&
                     Mouse.current.leftButton.wasPressedThisFrame;

        if (pressE || click)
        {
            started = true;
            dialogueBox.Open(cutsceneTalk);
        }
    }
}
