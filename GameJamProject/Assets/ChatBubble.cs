using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour
{
    private float timer = 0;
    private int liveTime = 4;
    public Vector2 size;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        // Sets the text in the chatBubble prefab. chatBubble -> TextMeshPro
        TextMeshProUGUI textObject = GetComponentInChildren<TextMeshProUGUI>();
        string dialogue = getDialogue();

        // Code inspired by https://www.youtube.com/watch?v=K13WnNL1OYM
        textObject.text = dialogue;
        textObject.ForceMeshUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < liveTime) {
            timer += Time.deltaTime;
        }
        else {
            Destroy(gameObject);
        }
    }

    // Get dialogue depending on the character
    string getDialogue() {
        string dialogue = "";
        string[] dialogueOptions = new string[]{};
        switch(gameObject.name) {
            case "FarmerChatBubble(Clone)":
                dialogue = Farmer.getDialogue();
                liveTime = Farmer.liveTime;
                break;
            case "BlacksmithChatBubble(Clone)":
                dialogue = Blacksmith.getDialogue();
                liveTime = Blacksmith.liveTime;
                break;
            case "BeekeeperChatBubble(Clone)":
                dialogue = Beekeeper.getDialogue();
                liveTime = Beekeeper.liveTime;
                break;
            case "RancherChatBubble(Clone)":
                dialogue = Rancher.getDialogue();
                liveTime = Rancher.liveTime;
                break;
            case "ShepherdChatBubble(Clone)":
                dialogue = Shepherd.getDialogue();
                liveTime = Shepherd.liveTime;
                break;
        }
        return dialogue;
    }
}
