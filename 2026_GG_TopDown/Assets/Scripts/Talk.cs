using UnityEngine;
using UnityEngine.Events;
public class Talk : MonoBehaviour
{
    public DialogueLine[] lines;
    public string choice1;
    public string choice2;
    public UnityEvent onChoice1;
    public UnityEvent onChoice2;
    // [추가] 모든 대사가 끝났을 때 실행할 이벤트
    public UnityEvent onDialogueEnd = new UnityEvent();
    public GameObject prompt;
    public DialogueBox dialogueBox;
    // [추가] 대화 잠금 기능
    public bool canTalk = true;
    public Talk lockedTalk;

    public void Say()
    {
        // [추가] 대화가 잠겨 있다면 안내 대사를 실행
        if (!canTalk && lockedTalk != null)
        {
            dialogueBox.Open(lockedTalk);
            return;
        }
        dialogueBox.Open(this);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(true);
            dialogueBox.nearTalk = this;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(false);
            dialogueBox.nearTalk = null;
        }
    }
    // [추가] 다른 이벤트에서 대화 잠금 해제
    public void Unlock()
    {
        canTalk = true;

    }
}