
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Transform target;
    public GameObject prompt;
    public DialogueBox dialogueBox;
    public int needKeys = 0;
    public Talk lockedTalk;
    public Light2D playerLight;
    public float targetPlayerLightIntensity = 1f;
    public Light2D globalLight;
    public float targetLightIntensity = 0f;
    // [추가] 이동할 다음 씬 이름
    public string nextSceneName;

    private Transform player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            prompt.SetActive(true);
            dialogueBox.nearDoor = this;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(false);
            dialogueBox.nearDoor = null;
            player = null; // [추가] 플레이어 참조 초기화
        }
    }

    public void Use()
    {
        Inventory inventory = player.GetComponent<Inventory>();

        if (inventory.keys >= needKeys)
        {
            // [추가] 다음 씬 이름이 입력되어 있다면 씬 이동
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
                return;
            }

            player.position = target.position;
            globalLight.intensity = targetLightIntensity;
            playerLight.intensity = targetPlayerLightIntensity;
        }
        else
        {
            lockedTalk.Say();
        }
    }
    // [추가] 대화 완료 후 문 잠금 해제
    public void UnlockDoor()
    {
        needKeys = 0;
    }
}
