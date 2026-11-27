using UnityEngine;
[System.Serializable]
public class DialogueLine
{
    public string speaker;
    [TextArea] public string text;
    // [추가] 해당 대사에서 보여줄 초상화
    public Sprite playerPortrait;
    public Sprite portrait;   // 추가(수업시간)
}
