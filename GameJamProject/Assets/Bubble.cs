using UnityEngine;
using TMPro;

public class DeleteBubble : MonoBehaviour
{
    private float timer = 0;
    private const int liveTime = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Dialogue options
        string[] dialogues = {"Hello, my name is <b>Bob</b>!", "Hi, this is <b>Bob</b>", "Did you know that Bob wants veterinary supplies?"};

        // Sets the text in the chatBubble prefab. chatBubble -> TextMeshPro
        TextMeshPro textObject = GetComponentInChildren<TextMeshPro>();
        string dialogue = dialogues[Random.Range(0, dialogues.Length)];
        textObject.text = dialogue;
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
}
