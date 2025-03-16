using UnityEngine;
public class DialogueSpawnScript : MonoBehaviour
{
    public GameObject bubble;
    public float spawnRate;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnRate = 2;
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        }
        else {
            Vector2 clone_size = GetComponentInChildren<SpriteRenderer>().GetComponent<Renderer>().bounds.size;
            Vector2 parent_size = gameObject.GetComponentInChildren<Renderer>().bounds.size;
            GameObject clone = CreateChatBubble(new Vector3(transform.position[0] - parent_size[0], transform.position[1] + parent_size[1], 0));
            clone.transform.parent = transform;
            timer = 0;
        }
    }

    GameObject CreateChatBubble(Vector3 size) {
        GameObject clone = Instantiate(bubble, size, transform.rotation);
        clone.GetComponent<ChatBubble>().dialogues = new string[]{"hello", "bye"};
        return clone;
    }
}
