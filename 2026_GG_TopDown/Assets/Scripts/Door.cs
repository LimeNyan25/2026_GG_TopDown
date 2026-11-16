
using UnityEngine;
using UnityEngine.Rendering.Universal;

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
        }
    }

    public void Use()
    {
        Inventory inventory = player.GetComponent<Inventory>();

        if (inventory.keys >= needKeys)
        {
            player.position = target.position;
            globalLight.intensity = targetLightIntensity;
            playerLight.intensity = targetPlayerLightIntensity;
        }
        else
        {
            lockedTalk.Say();
        }
    }
}
